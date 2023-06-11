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

			var getAllcachedResult = await _distributedCache.GetStringAsync(getAllCacheKey);

			if (!string.IsNullOrEmpty(getAllcachedResult))
			{
				var cachedResult = JsonConvert.DeserializeObject<ApiResponse<List<ProductDto>>>(getAllcachedResult);

				if (!string.IsNullOrEmpty(CategoryName))
				{
					cachedResult.Data = cachedResult.Data.Where(x => x.Category == CategoryName).ToList();
				}
					

				_logger.LogInformation("Ürünler önbellekten listelendi");
				return Ok(cachedResult);
			}
			else
			{
				var result = pm.GetAll();
				var serializedResult = JsonConvert.SerializeObject(result);
				await _distributedCache.SetStringAsync(getAllCacheKey, serializedResult, new DistributedCacheEntryOptions
				{
					AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(60)
				});
				if (!string.IsNullOrEmpty(CategoryName)) result.Data = result.Data.Where(x => x.Category == CategoryName).ToList();
				_logger.LogInformation("Ürünler listelendi");
				return Ok(result);
			}

		}
		
	}
}