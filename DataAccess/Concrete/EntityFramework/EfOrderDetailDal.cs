using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOrderDetailDal : IOrderDetailDal
	{
		public int AddOrder(OrderDetail orderDetail, int orderId)
		{
			using (Context context = new Context())
			{
				orderDetail.OrderId = orderId;
				var addedEntity2 = context.Entry(orderDetail);
				addedEntity2.State = EntityState.Added;
				context.SaveChanges();

				return orderDetail.Id;
			}
		}
	}
}
