using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IProductService
	{
		ApiResponse<List<ProductDto>> GetAll2();
		ApiResponse<List<ProductDto>> GetAllByCategory2(string categoryName);
		List<ProductDto> GetAll();
		List<ProductDto> GetAllByCategory(string categoryName);
	}
}
