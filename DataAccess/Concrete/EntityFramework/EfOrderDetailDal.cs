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
	public class EfOrderDetailDal : IOrderDetailDal
	{
		public int AddOrder(OrderDetail orderDetail, int orderId)
		{
			using (Context context = new Context())
			{
				/*
				OrderDetail orderDetail = new OrderDetail();
				orderDetail.UnitPrice = cor.UnitPrice;
				orderDetail.ProductId = cor.ProductId;
				orderDetail.OrderId = productId;
				*/

				orderDetail.OrderId= orderId;
				var addedEntity2 = context.Entry(orderDetail);
				addedEntity2.State = EntityState.Added;
				context.SaveChanges();

				return orderDetail.Id;
			}
		}
	}
}
