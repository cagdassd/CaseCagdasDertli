using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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

		public OrdersController(ILogger<ProductsController> Logger)
		{
			logger = Logger;
		}

		[HttpPost("createorderrequest")]
		public IActionResult Add(CreateOrderRequest cor)
		{
			logger.LogCritical("Order İşlemi Başlatıldı");

			var AddOrder = orderManager.AddOrder(cor);

			var OrderDetailId = orderDetailManager.AddOrderDetail(cor,AddOrder);
			
			return Ok(OrderDetailId);
		}

	}
}
