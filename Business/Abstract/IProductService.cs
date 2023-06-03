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
		ApiResponse<List<ProductDto>> GetAll();
		ApiResponse<List<ProductDto>> GetAllByCategory(string categoryName);
	}
}
