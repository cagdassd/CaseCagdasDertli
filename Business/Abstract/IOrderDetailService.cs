﻿using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
	public interface IOrderDetailService
	{
		public int AddOrderDetail(CreateOrderRequest cor,int productId);
	}
}
