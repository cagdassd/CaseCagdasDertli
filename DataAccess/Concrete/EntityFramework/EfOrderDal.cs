using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
