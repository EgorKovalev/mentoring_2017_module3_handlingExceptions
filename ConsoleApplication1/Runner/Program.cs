using System;
using Domain.Entities;
using Domain.Exceptions;
using Services.Concrete;

namespace Runner
{
    class Program
    {
        static void Main()
        {
            var orderService = new OrderService();
            orderService.Add(new Order()
            {
                Description = "Test order 1",
                Price = 100
            });

            orderService.Add(new Order()
            {
                Description = "Test order 2",
                Price = 200
            });

            try
            {
                orderService.Update(new Order()
                {
                    Description = "Test order 3",
                    Price = 300
                });
            }
            catch (UpdateDbException)
            {
                Console.WriteLine("Can't update");
            }
            Console.ReadLine();
        }
    }
}
