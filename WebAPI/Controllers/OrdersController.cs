using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.RabbitMQ;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		OrderManager orderManager = new OrderManager(new EfOrderDal());
		OrderDetailManager orderDetailManager = new OrderDetailManager(new EfOrderDetailDal());
		private readonly ILogger<ProductsController> _logger;
		private readonly IMapper _mapper;
		private readonly RabbitMQService _rabbitMQService;
		private readonly string _rabbitMQConnectionUrl;
		private readonly IConfiguration _configuration;

		public OrdersController(ILogger<ProductsController> logger, IMapper mapper, IConfiguration configuration)
		{
			_logger = logger;
			_mapper = mapper;
			_configuration = configuration;
			_rabbitMQService = new RabbitMQService(_configuration.GetSection("RabbitMQConnection").Value);
		}



		[HttpPost("createorder")]
		public async Task<IActionResult> AddAsync(List<CreateOrderRequest> cor)
		{
			_logger.LogInformation("Order İşlemi Başlatıldı");

			List<int> orderDetailIds = new List<int>();

			foreach (var item in cor)
			{
				var orderInfo = _mapper.Map<Order>(item);
				var AddOrder = orderManager.AddOrder(orderInfo);
				_logger.LogInformation("Order Tablosuna Kayıt Başarıyla Gerçekleştirildi!");

				var orderDetailInfo = _mapper.Map<OrderDetail>(item);
				var OrderDetailId = orderDetailManager.AddOrderDetail(orderDetailInfo, AddOrder);
				orderDetailIds.Add(OrderDetailId);
				_logger.LogInformation("OrderDetail Tablosuna Kayıt Başarıyla Gerçekleştirildi!");

				MailModel mailModel = new MailModel();

				mailModel.Reciever = item.CustomerEmail;
				mailModel.Subject = "Sipariş Biliginiz";
				mailModel.Content = "Sayın " + item.CustomerName + ", Ürün numarası " + item.ProductId + ", Siparişinizin Fiyatı: " + item.UnitPrice + "'dır bizi tercih ettiğiniz icin teşekkür ederiz.";

				await Task.Run(() =>
					{
						_rabbitMQService.SendMailMessage(mailModel);
					}).ConfigureAwait(false);
				_logger.LogInformation("Mail Gönderim İşlemi Başarıyla Tamamlandı");
				

			}

			ApiResponse<List<int>> response = new ApiResponse<List<int>>();

			if (orderDetailIds.ToArray().Length > 0)
			{
				response.Status = Status.Success;
				response.Data = orderDetailIds.ToList();
				response.ResultMessage = "Başarılı işlem";
				return Ok(response);
			}
			response.Status = Status.Failed;
			response.ResultMessage = "Başarısız";
			response.ErrorCode = "400";
			return BadRequest(response);

		}

	}
}
