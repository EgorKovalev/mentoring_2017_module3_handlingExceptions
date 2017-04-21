using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;

namespace Domain.Concrete
{
	public class OrderRepository : IOrderRepository
	{
		private readonly List<Order> DBContext = new List<Order>();

		public Order Get(int id)
		{
			return DBContext.FirstOrDefault(item => item.Id == id);
		}

		public Order Add(Order order)
		{
			order.Id = GetNextId();
			
			DBContext.Add(order);
			
			return order;
		}

		public Order Update(Order order)
		{
			int index = DBContext.FindIndex(item => item.Id == order.Id);

			if(index != -1)
			{
				DBContext[index] = order;
				return order;
			}

			throw new Exception();
		}

		public bool Delete(int id)
		{
			Order order = DBContext.FirstOrDefault(item => item.Id == id);

			return (order != null) ? DBContext.Remove(order) : false;
		}

		private int GetNextId()
		{
			return DBContext.Count + 1;
		}
	}
}
