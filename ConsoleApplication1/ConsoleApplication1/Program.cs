using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Order order = new Order();

			var isValid = Validator.TryValidateObject(order, new ValidationContext(order, null, null), null, true);
		}
	}
}
