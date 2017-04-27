using Domain.Entities;
using Domain.Models;

namespace Domain.Abstract
{
    public interface IOrderRepository
	{
		OrderModel Get(int id);
		OrderModel Add(OrderModel order);
		OrderModel Update(OrderModel order);
		bool Delete(int id);
	}
}
