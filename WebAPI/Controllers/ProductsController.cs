using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		ProductManager pm = new ProductManager(new EfProductDal());

		private readonly ILogger<ProductsController> logger;

		public ProductsController(ILogger<ProductsController> Logger)
		{
			logger = Logger;
		}

		[HttpGet("getall")]
		public IActionResult GetAll(string CategoryName)
		{
			logger.LogCritical("GetAll metodu çağrıldı");
			
			if (String.IsNullOrEmpty(CategoryName))
			{
				var result = pm.GetAllByCategory(CategoryName);
				return Ok(result);
			}
			else
			{
				var result = pm.GetAll();
				return Ok(result);
			}
		}



	}
}
