using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		OrderManager orderManager = new OrderManager(new EfOrderDal());

		[HttpPost("add")]
		public IActionResult GetAll(CreateOrderRequest cor)
		{
			orderManager.AddOrder(cor);
			
			return Ok();
		}

	}
}
