
using DataAccess.Abstract;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfProductDal : IProductDal
	{

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
		/*
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
				return result.Where(x => x.Category == CategoryName).ToList();
			}
		}

		*/
	}
}
