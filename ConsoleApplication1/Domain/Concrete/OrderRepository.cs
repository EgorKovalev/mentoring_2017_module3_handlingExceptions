using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Domain.Abstract;
using Domain.Entities;
using Domain.Exceptions;

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
		    if (!IsOrderValid(order))
		    {
		        throw new OrderValidException(order.ToString());
		    }
            order.Id = GetNextId();
			_dbContext.Add(order);
			return order;
		}

		public Order Update(Order order)
		{
            if (!IsOrderValid(order))
		    {
		        throw new OrderValidException(order.ToString());
		    }
			int index = _dbContext.FindIndex(item => item.Id == order.Id);
			if(index != -1)
			{
				_dbContext[index] = order;
				return order;
			}
            throw new UpdateDbException(order.ToString());
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

	    private bool IsOrderValid(Order order)
	    {
            return Validator.TryValidateObject(order, new ValidationContext(order, null, null), null, true);
	    }
	}
}
