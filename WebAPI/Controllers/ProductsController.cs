using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
		public IActionResult GetAll(string? CategoryName)
		{
			_logger.LogInformation("GetAll metodu çağrıldı");
			string cacheKey = "AllProducts";
			if (_cache.TryGetValue(cacheKey, out var cachedResult))
			{
				_logger.LogInformation("Ürünler Önbellekten Listelendi");
				return Ok(cachedResult);

			}
			if (!string.IsNullOrEmpty(CategoryName))
			{
				var result = pm.GetAllByCategory(CategoryName);

				_cache.Set(cacheKey, result, TimeSpan.FromMinutes(60));
				_logger.LogInformation("Ürünler Listelendi");
				return Ok(result);
			}
			else
			{
				var result = pm.GetAll();
				_logger.LogInformation("Ürünler Listelendi");
				_cache.Set(cacheKey, result, TimeSpan.FromMinutes(60));

				return Ok(result);
			}
		}
	}
}
