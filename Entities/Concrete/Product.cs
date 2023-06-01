﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Product
	{
		[Key]
		public int Id  { get; set; }
		public string ProductDescription { get; set; }
		public string Category { get; set; }
		public int Unit { get; set; }
		public int UnitPrice { get; set; }
		public bool ProductStatus { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime UpdateDate { get; set; }


		public List<OrderDetail> Details { get; set; }
	}
}
