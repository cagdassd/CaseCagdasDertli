using Entities.Concrete;

namespace DataAccess.Abstract
{
	public interface IOrderDetailDal
	{
		public int AddOrder(OrderDetail orderDetail, int orderId);


	}
}
