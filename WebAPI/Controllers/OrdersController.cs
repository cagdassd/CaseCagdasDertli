using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebAPI.RabbitMQ;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		OrderManager orderManager = new OrderManager(new EfOrderDal());
		OrderDetailManager orderDetailManager = new OrderDetailManager(new EfOrderDetailDal());
		private readonly ILogger<ProductsController> logger;
		private readonly IMapper _mapper;

		public OrdersController(ILogger<ProductsController> Logger, IMapper mapper)
		{
			logger = Logger;
			_mapper = mapper;
		}



		[HttpPost("createorderrequest")]
		public IActionResult Add(List<CreateOrderRequest> cor)
		{
			logger.LogCritical("Order İşlemi Başlatıldı");

			List<int> orderDetailIds = new List<int>();

			foreach (var item in cor)
			{


				var orderInfo = _mapper.Map<Order>(item);
				var AddOrder = orderManager.AddOrder(orderInfo);

				var orderDetailInfo = _mapper.Map<OrderDetail>(item);
				var OrderDetailId = orderDetailManager.AddOrderDetail(orderDetailInfo, AddOrder);

				orderDetailIds.Add(OrderDetailId);



				string rabbitMQConnectionUrl = "amqps://pfrxyapi:bfeX09-lnmiLAHZzeRDltpcFswm_z8zv@cow.rmq2.cloudamqp.com/pfrxyapi";
				RabbitMQService rabbitMQService = new RabbitMQService(rabbitMQConnectionUrl);
				
				string receiver = item.CustomerEmail;
				string subject = "Sipariş Biliginiz";
				string content = "Bizi tercih ettiğiniz için teşekkür ederiz.";

				rabbitMQService.SendMailMessage(receiver, subject, content);

				
			}
			
			return Ok(orderDetailIds.ToArray());
		}

	}
}
