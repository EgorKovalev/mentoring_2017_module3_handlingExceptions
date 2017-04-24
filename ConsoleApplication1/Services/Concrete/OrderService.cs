using System;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using Domain.Exceptions;
using Services.Abstract;
using Services.Exceptions;

namespace Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService()
        {
            _repository = OrderRepository.GetInstance();
        }

        public Order Get(int id)
        {
            return _repository.Get(id);
        }

        public Order Add(Order order)
        {
            if (order.Price <= 0)
            {
                throw new PriceValueException(order.ToString());
            }
            if (order.Status != Status.New)
            {
                throw new OrderStatusException(order.ToString());
            }
            order.LastModification = DateTime.Now;
            return _repository.Add(order);
        }

        public Order Update(Order order)
        {
            if (order.Price <= 0)
            {
                throw new PriceValueException(order.ToString());
            }
            Order o = _repository.Get(order.Id);
            if (o != null)
            {
                Status st = o.Status;
                if (order.Status != st.Next() ||
                    order.Status != st.Prev() ||
                    order.Status != st)
                {
                    throw new OrderStatusException(order.ToString());
                }
            }

            try
            {
                return _repository.Update(order);
            }
            catch (UpdateDbException)
            {
                return order; //return an object without update
            }
        }

        public bool Delete(int id)
        {
            Order order = _repository.Get(id);
            if (order.Status == Status.Paid || order.Status == Status.InProgress)
            {
                throw new OrderStatusException(order.ToString());
            }
            return _repository.Delete(id);
        }
    }
}
