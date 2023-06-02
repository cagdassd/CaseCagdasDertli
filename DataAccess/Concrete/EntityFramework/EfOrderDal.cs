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
		public int AddOrder(CreateOrderRequest cor)
		{
			using (Context context = new Context())
			{
				Order order = new Order();
				order.CustomerGSM = cor.CustomerGSM;
				order.CustomerEmail = cor.CustomerEmail;
				order.CustomerName = cor.CustomerName;
				order.TotalAmount = cor.Amount;

				var addedEntity = context.Entry(order);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();

				return order.Id;
			}
		}
	}
}
