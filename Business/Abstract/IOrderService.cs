using Entities.Concrete;

namespace Business.Abstract
{
	public interface IOrderService
	{
		public int AddOrder(Order order);
	}
}
