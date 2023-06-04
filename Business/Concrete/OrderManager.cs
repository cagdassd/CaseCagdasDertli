using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class OrderManager : IOrderService
	{
		IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public int AddOrder(Order order)
		{

			return _orderDal.AddOrder(order);
		}
	}
}
