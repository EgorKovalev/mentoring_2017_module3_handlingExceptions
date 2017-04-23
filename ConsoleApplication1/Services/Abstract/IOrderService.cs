using Domain.Entities;

namespace Services.Abstract
{
    internal interface IOrderService
    {
        Order Get(int id);
        Order Add(Order order);
        Order Update(Order order);
        bool Delete(int id);
    }
}
