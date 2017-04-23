using System;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
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

        public Order Get(int id)
        {
            return _repository.Get(id);
        }

        public Order Add(Order order)
        {
            if (order.Price <= 0)
            {
                throw new Exception();
            }
            if (order.Status != Status.New)
            {
                throw new Exception();
            }
            order.LastModification = DateTime.Now;
            return _repository.Add(order);
        }

        public Order Update(Order order)
        {
            if (order.Price <= 0)
            {
                throw new Exception();
            }
            Status st = _repository.Get(order.Id).Status;
            if (order.Status != st.Next() ||
                order.Status != st.Prev() ||
                order.Status != st)
            {
                throw new Exception();
            }
            return _repository.Update(order);
        }

        public bool Delete(int id)
        {
            Order order = _repository.Get(id);
            if (order.Status == Status.Paid || order.Status == Status.InProgress)
            {
                throw new Exception();
            }
            return _repository.Delete(id);
        }
    }
}
