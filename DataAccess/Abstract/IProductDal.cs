using Entities.DTOs;

namespace DataAccess.Abstract
{
	public interface IProductDal
	{

		public List<ProductDto> GetProductDetails();
		public List<ProductDto> GetProductDetails(string CategoryName);
	}
}
