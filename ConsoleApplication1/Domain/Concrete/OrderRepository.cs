using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
	public class OrderRepository : IOrderRepository
	{
	    private readonly List<Order> _dbContext;
	    private static OrderRepository _instance;

	    private OrderRepository()
	    {
	        _dbContext = new List<Order>();
	    }

	    public static OrderRepository GetInstance()
	    {
	        return _instance ?? (_instance = new OrderRepository());
	    }

		public Order Get(int id)
		{
			return _dbContext.FirstOrDefault(item => item.Id == id);
		}

		public Order Add(Order order)
		{
			order.Id = GetNextId();
			_dbContext.Add(order);
			return order;
		}

		public Order Update(Order order)
		{
			int index = _dbContext.FindIndex(item => item.Id == order.Id);
			if(index != -1)
			{
				_dbContext[index] = order;
				return order;
			}
			throw new Exception();
		}

		public bool Delete(int id)
		{
			Order order = _dbContext.FirstOrDefault(item => item.Id == id);
			return (order != null) && _dbContext.Remove(order);
		}

		private int GetNextId()
		{
			return _dbContext.Count + 1;
		}
	}
}
