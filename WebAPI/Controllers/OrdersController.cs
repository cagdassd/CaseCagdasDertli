using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
			}
			
			return Ok(orderDetailIds.ToArray());
		}

	}
}
