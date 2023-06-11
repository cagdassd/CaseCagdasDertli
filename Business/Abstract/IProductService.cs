using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
	public interface IProductService
	{
		ApiResponse<List<ProductDto>> GetAll();
	}
}
