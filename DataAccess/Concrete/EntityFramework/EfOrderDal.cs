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
		public void AddOrder(CreateOrderRequest cor)
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


				OrderDetail orderDetail = new OrderDetail();
				orderDetail.UnitPrice = cor.UnitPrice;
				orderDetail.ProductId = cor.ProductId;
				orderDetail.OrderId = order.Id;



				var addedEntity2 = context.Entry(orderDetail);
				addedEntity2.State = EntityState.Added;
				context.SaveChanges();
			}
		}
	}
}
