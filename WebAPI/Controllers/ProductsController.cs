using AutoMapper;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		ProductManager pm = new ProductManager(new EfProductDal());
		private readonly ILogger<ProductsController> _logger;
		private readonly IDistributedCache _distributedCache;

		public ProductsController(ILogger<ProductsController> logger, IDistributedCache distributedCache)
		{
			_logger = logger;
			_distributedCache = distributedCache;
		}

		[HttpGet("getproducts")]
		public async Task<IActionResult> GetAll(string? CategoryName)
		{
			_logger.LogInformation("GetAll metodu çağrıldı");
			string getAllCacheKey = "AllProducts";
			string getAllByCategoryCacheKey = "GetAllProductsByCategory";


			var getAllcachedResult = await _distributedCache.GetStringAsync(getAllCacheKey);
			var GetAllByCategoryCachedResult = await _distributedCache.GetStringAsync(getAllByCategoryCacheKey);

			
			if (!string.IsNullOrEmpty(CategoryName))
			{
				if (string.IsNullOrEmpty(GetAllByCategoryCachedResult))
				{
					
					var cachedResult = JsonConvert.DeserializeObject<ApiResponse<List<ProductDto>>>(GetAllByCategoryCachedResult);
					_logger.LogInformation("Ürünler önbellekten listelendi");
					return Ok(cachedResult);
				}

				var result = pm.GetAllByCategory(CategoryName);
				var serializedResult = JsonConvert.SerializeObject(result);
				await _distributedCache.SetStringAsync(getAllByCategoryCacheKey, serializedResult, new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
				});

				_logger.LogInformation("Ürünler listelendi");
				return Ok(result);
			}
			else
			{
				if (!string.IsNullOrEmpty(getAllcachedResult))
				{
					
					var cachedResult = JsonConvert.DeserializeObject<ApiResponse<List<ProductDto>>>(getAllcachedResult);
					_logger.LogInformation("Ürünler önbellekten listelendi");
					return Ok(cachedResult);
				}
				var result = pm.GetAll();
				var serializedResult = JsonConvert.SerializeObject(result);
				await _distributedCache.SetStringAsync(getAllCacheKey, serializedResult, new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
				});

				_logger.LogInformation("Ürünler listelendi");
				return Ok(result);
			}
		}
	}
}