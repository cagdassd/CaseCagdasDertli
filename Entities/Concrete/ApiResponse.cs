using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public enum Status
	{

		Success = 200,
		Failed = 500
		
	}

	public class ApiResponse<T>
	{
		public Status Status { get; set; }
		public string ResultMessage { get; set; }
		public string ErrorCode { get; set; }
		public T Data { get; set; }
	}
}
