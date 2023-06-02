using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
	public class ApiResponse<T>
	{
		public T Data;
		public string Errorcode;
		public string Message;
		public int Status;


		
	}

	public enum ApiResponseStatusEnum
	{
		Success =200,
		Fail =500
	}
}
