using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class ProductDto
	{
		public int ProductId { get; set; }
		public string ProductDescription { get; set; }
		public string Category { get; set; }
		public int Unit { get; set; }
		public int UnitPrice { get; set; }
	}
}
