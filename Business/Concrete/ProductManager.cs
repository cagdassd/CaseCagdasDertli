using Business.Abstract;
using Core.Aspects.Autofac.Caching;
using Core.CrossCuttingConcerns.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class ProductManager : IProductService
	{
		IProductDal _productDal;
		private readonly ICacheManager _cacheManager;

		public ProductManager(IProductDal productDal/*, ICacheManager cacheManager*/)
		{
			_productDal = productDal;	
//			_cacheManager = cacheManager;
		}

		

		
		[CacheAspect]
		public List<ProductDto> GetAll()
		{
			/*
			if (_cacheManager.IsAdd("GetAll"))
			{
				return _cacheManager.Get<List<ProductDto>>("GetAll");
			}
			else
			{
				_cacheManager.Add("GetAll", List<ProductDto>, 25);
			}
			*/

			


			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data = _productDal.GetProductDetails();
			
			return _productDal.GetProductDetails();
		}


		public ApiResponse<List<ProductDto>> GetAll2()
		{
			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data = _productDal.GetProductDetails();
			response.Errorcode = "200";
			response.Status = 200;
			response.Message = "OK";
			return response;
			
		}
		public List<ProductDto> GetAllByCategory(string categoryName)
		{
			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data =_productDal.GetProductDetails(categoryName);
			
			return _productDal.GetProductDetails(categoryName);
		}

		public ApiResponse<List<ProductDto>> GetAllByCategory2(string categoryName)
		{
			throw new NotImplementedException();
		}
	}
}
