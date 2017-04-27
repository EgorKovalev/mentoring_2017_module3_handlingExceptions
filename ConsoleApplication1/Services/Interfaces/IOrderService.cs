using Domain.Entities;
using Domain.Models;

namespace Services.Abstract
{
    internal interface IOrderService
    {
		OrderModel Get(int id);
		OrderModel Add(OrderModel order);
		OrderModel Update(OrderModel order);
        bool Delete(int id);
    }
}
