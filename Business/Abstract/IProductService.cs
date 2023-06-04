using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface IProductService
	{
		ApiResponse<List<ProductDto>> GetAll();
		ApiResponse<List<ProductDto>> GetAllByCategory(string categoryName);
	}
}
