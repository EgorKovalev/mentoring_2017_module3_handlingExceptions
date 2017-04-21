using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
	interface IOrderRepository
	{
		Order Get(int id);
		Order Add(Order order);
		Order Update(Order order);
		bool Delete(int id);
	}
}
