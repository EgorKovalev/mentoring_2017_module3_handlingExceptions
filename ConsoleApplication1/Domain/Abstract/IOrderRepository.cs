using Domain.Entities;

namespace Domain.Abstract
{
    public interface IOrderRepository
	{
		Order Get(int id);
		Order Add(Order order);
		Order Update(Order order);
		bool Delete(int id);
	}
}
