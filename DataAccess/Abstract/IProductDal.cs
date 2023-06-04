using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
	public interface IProductDal
	{

		public List<ProductDto> GetProductDetails();
		public List<ProductDto> GetProductDetails(string CategoryName);




		public void Add(Product product);
	}
}
