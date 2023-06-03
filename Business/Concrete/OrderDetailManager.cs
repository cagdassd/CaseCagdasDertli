using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		IOrderDetailDal _orderDetailDal;

		public OrderDetailManager(IOrderDetailDal OrderDetailDal)
		{
			_orderDetailDal= OrderDetailDal;
		}



		public int AddOrderDetail(OrderDetail orderDetail, int ProductId)
		{
			return _orderDetailDal.AddOrder(orderDetail, ProductId);
		}
	}
}
