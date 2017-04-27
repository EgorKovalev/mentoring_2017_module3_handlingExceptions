using System;
using Attributes.BLExceptions;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using Domain.Models;
using Services.Abstract;

namespace Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService()
        {
            _repository = OrderRepository.GetInstance();
        }

        public OrderModel Get(int id)
        {
            return _repository.Get(id);
        }

		public OrderModel Add(OrderModel order)
        {
			ValidatePrice(order);
			ValidateStatus(order);
           
            return _repository.Add(order);
        }

		public OrderModel Update(OrderModel order)
        {
			ValidatePrice(order);

			OrderModel o = _repository.Get(order.Id);
            if (o != null)
            {
                Status st = o.Status;
                if (order.Status != st.Next() || order.Status != st.Prev() || order.Status != st)
                {
                    throw new OrderStatusException(order.ToString());
                }
            }
			
			return _repository.Update(order);
        }

        public bool Delete(int id)
        {
			OrderModel order = _repository.Get(id);
            if (order.Status == Status.Paid || order.Status == Status.InProgress)
            {
                throw new OrderStatusException(order.ToString());
            }
            return _repository.Delete(id);
        }

		private void ValidatePrice(OrderModel order)
		{
			if (order.Price <= 0)
			{
				throw new PriceValueException(order.ToString());
			}
		}

		private void ValidateStatus(OrderModel order)
		{
			if (order.Status != Status.New)
			{
				throw new OrderStatusException(order.ToString());
			} 
		}
    }
}
