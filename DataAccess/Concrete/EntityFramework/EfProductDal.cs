
using DataAccess.Abstract;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : IProductDal
	{

		public EfProductDal()
		{

		}

		public List<ProductDto> GetProductDetails()
		{
			




			using (Context context = new Context())
			{
				var result = from p in context.Products
							 select new ProductDto
							 {
								 ProductId = p.Id,
								 ProductDescription = p.ProductDescription,
								 Category = p.Category,
								 Unit = p.Unit,
								 UnitPrice = p.UnitPrice
							 };


				return result.ToList();
			}
		}






		public List<ProductDto> GetProductDetails(string CategoryName)
		{
			using (Context context = new Context())
			{
				var result = from p in context.Products
							 select new ProductDto
							 {
								 ProductId = p.Id,
								 ProductDescription = p.ProductDescription,
								 Category = p.Category,
								 Unit = p.Unit,
								 UnitPrice = p.UnitPrice
							 };
				return result.Where(x=>x.Category == CategoryName).ToList();
			}
		}
	}
}
