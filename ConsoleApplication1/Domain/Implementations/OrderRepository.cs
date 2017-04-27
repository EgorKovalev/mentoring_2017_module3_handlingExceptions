using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Attributes.DALExceptions;
using Domain.Abstract;
using Domain.Entities;
using Domain.Models;

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

		public OrderModel Get(int id)
		{
			Order order = _dbContext.FirstOrDefault(item => item.Id == id);
			return new OrderModel(order);
		}

		public OrderModel Add(OrderModel order)
		{
			ValidateRequiredFields(order);
            			
			order.Id = GetNextId();
			ValidateOrderId(order);
			
			_dbContext.Add(new Order(order));
			return order;
		}

		public OrderModel Update(OrderModel order)
		{
			ValidateRequiredFields(order);

			int index = _dbContext.FindIndex(item => item.Id == order.Id);
			if(index != -1)
			{
				_dbContext[index] = new Order(order);
				return order;
			}
            throw new KeyNotFoundException("Order is not present in the DB");
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

	    private void ValidateRequiredFields(OrderModel order)
	    {			
            bool isValid = Validator.TryValidateObject(order, new ValidationContext(order, null, null), null, true);
			if(!isValid)
			{
				throw new RequiredFieldsException(order.ToString());
			}
	    }

		private void ValidateOrderId(OrderModel order)
		{
			if (_dbContext.Any(item => item.Id == order.Id))
			{
				throw new OrderExistException(order.ToString());
			}
		}
	}
}
