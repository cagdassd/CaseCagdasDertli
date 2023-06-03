using AutoMapper;
using Business.Concrete;
using Core.Aspects.Autofac.Caching;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		ProductManager pm = new ProductManager(new EfProductDal());

		private readonly ILogger<ProductsController> _logger;
		private readonly IMapper _mapper;
		private readonly IMemoryCache _cache;


		public ProductsController(IMapper mapper, ILogger<ProductsController> logger, IMemoryCache cache)
		{

			_logger = logger;
			_mapper = mapper;
			_cache = cache;
		}



		[HttpGet("getall")]
		public IActionResult GetAll( string? CategoryName)
		{
			_logger.LogCritical("GetAll metodu çağrıldı");
			string cacheKey = "AllProducts";
			if (_cache.TryGetValue(cacheKey, out var cachedResult))
			{
				// Önbellekte veri varsa, önbellekten dönün
				return Ok(cachedResult);
			}
			if (!string.IsNullOrEmpty(CategoryName))
			{
				var result = pm.GetAllByCategory2(CategoryName);

				_cache.Set(cacheKey, result, TimeSpan.FromMinutes(60));

				return Ok(result);
			}
			else
			{
				var result = pm.GetAll2();

				_cache.Set(cacheKey, result, TimeSpan.FromMinutes(60));

				return Ok(result);
			}
		}



	}
}
 