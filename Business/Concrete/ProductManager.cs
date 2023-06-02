using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
		

		public ProductManager(IProductDal productDal)
		{
			_productDal = productDal;	
		}

		public ApiResponse<List<ProductDto>> GetAll()
		{

			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data = _productDal.GetProductDetails();

			return response;
		}

		public ApiResponse<List<ProductDto>> GetAllByCategory(string categoryName)
		{
			ApiResponse<List<ProductDto>> response = new ApiResponse<List<ProductDto>>();
			response.Data =_productDal.GetProductDetails(categoryName);

			return response;
		}
	}
}
