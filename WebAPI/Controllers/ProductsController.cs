using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		ProductManager pm = new ProductManager(new EfProductDal());



		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = pm.GetAll();
			return Ok(result);
		}

		[HttpGet("getallbycategory")]
		public IActionResult GetAll(string CategoryName)
		{
			var result = pm.GetAllByCategory(CategoryName);
			return Ok(result);
		}


	}
}
