using Entities.Concrete;

namespace Business.Abstract
{
	public interface IOrderDetailService
	{
		public int AddOrderDetail(OrderDetail orderDetail, int orderId);
	}
}
