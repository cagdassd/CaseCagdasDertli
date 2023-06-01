using Business.Abstract;
using DataAccess.Abstract;
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

		public List<ProductDto> GetAll()
		{
			return _productDal.GetProductDetails();
		}

		public List<ProductDto> GetAllByCategory(string categoryName)
		{
			return _productDal.GetProductDetails(categoryName);		
		}
	}
}
