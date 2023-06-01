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
		List<ProductDto> GetAll();
		List<ProductDto> GetAllByCategory(string categoryName);
	}
}
