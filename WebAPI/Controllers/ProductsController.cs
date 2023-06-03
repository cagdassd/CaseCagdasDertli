using AutoMapper;
using Business.Concrete;
using Core.Aspects.Autofac.Caching;
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

		private readonly ILogger<ProductsController> _logger;
		private readonly IMapper _mapper;

		public ProductsController(IMapper mapper, ILogger<ProductsController> logger)
		{

			_logger = logger;
			_mapper = mapper;
		}



		[HttpGet("getall")]
		public IActionResult GetAll( string? CategoryName)
		{
			_logger.LogCritical("GetAll metodu çağrıldı");

			

			if (!string.IsNullOrEmpty(CategoryName))
			{
				var result = pm.GetAllByCategory(CategoryName);
				
				//var productInfo= _mapper.Map<ProductDto>(result);

				return Ok(result);
			}
			else
			{
				var result = pm.GetAll();

				//var productInfo = _mapper.Map<ProductDto>(result);

				return Ok(result);
			}
		}



	}
}
 