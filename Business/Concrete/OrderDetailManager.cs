using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		IOrderDetailDal _orderDetailDal;

		public OrderDetailManager(IOrderDetailDal OrderDetailDal)
		{
			_orderDetailDal = OrderDetailDal;
		}



		public int AddOrderDetail(OrderDetail orderDetail, int orderId)
		{
			return _orderDetailDal.AddOrder(orderDetail, orderId);
		}
	}
}
