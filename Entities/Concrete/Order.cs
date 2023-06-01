using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class Order
	{
		[Key]
		public int Id { get; set; }
		public string CustomerName { get; set; }
		public string CustomerEmail { get; set; }
		public string CustomerGSM { get; set; }
		public int TotalAmount { get; set; }


		public List<OrderDetail> Details { get; set; }
	}
}
