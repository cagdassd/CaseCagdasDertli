using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Caching;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		ProductManager pm = new ProductManager(new EfProductDal());

		private readonly ILogger<ProductsController> _logger;
		private readonly IMapper _mapper;
		ICacheManager _cacheManager;


		public ProductsController(IMapper mapper, ILogger<ProductsController> logger, ICacheManager cacheManager)
		{

			_logger = logger;
			_mapper = mapper;
			_cacheManager = cacheManager;
		}


		[HttpGet("deneme")]
		public IActionResult GetAll2(string? CategoryName)
		{
			
				var result = pm.GetAll2();

				//var productInfo = _mapper.Map<ProductDto>(result.Data);

				return Ok(result);
			



		}

			[HttpGet("getall")]
		public IActionResult GetAll( string? CategoryName)
		{
			_logger.LogCritical("GetAll metodu çağrıldı");

			if (_cacheManager.IsAdd("getall"))
			{
				var products = _cacheManager.Get<List<ProductDto>>("Business.Abstract.IProductService.Getall()");
				return Ok(products);
			}
			

			if (!string.IsNullOrEmpty(CategoryName))
			{
				var result = pm.GetAllByCategory(CategoryName);
				
				//var productInfo= _mapper.Map<ProductDto>(result);

				return Ok(result);
			}
			else
			{
				var result = pm.GetAll();

				var productInfo = _mapper.Map<ProductDto>(result);

				return Ok(result);
			}
		}



	}
}
 