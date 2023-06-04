using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfOrderDal : IOrderDal
	{
		public int AddOrder(Order order)
		{
			using (Context context = new Context())
			{

				var addedEntity = context.Entry(order);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();

				return order.Id;
			}
		}
	}
}
