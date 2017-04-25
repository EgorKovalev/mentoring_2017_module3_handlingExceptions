using System;
using Domain.Entities;
using Domain.Exceptions;
using Services.Concrete;
using Services.Exceptions;

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

            //Update DB exception will be generated and handled here
            orderService.Update(new Order()
            {
                Description = "Test order 3",
                Price = 300
            });

            //Price value exception will be generated and handled here
            try
            {
                orderService.Add(new Order()
                {
                    Description = "Test order 4",
                    Price = -20
                });
            }
            catch (PriceValueException)
            {
                Console.WriteLine("Can't add order to DB - price is not correct. For more information please see the log file");
            }

            //Order status exception will be generated and handled here
            try
            {
                orderService.Add(new Order()
                {
                    Description = "Test order 5",
                    Price = 100,
                    Status = Status.Completed
                });
            }
            catch (OrderStatusException)
            {
                Console.WriteLine("Can't add order to DB - status is not correct. For more information please see the log file");
            }

            //Price value exception will be generated and handled here
            try
            {
                orderService.Add(new Order()
                {
                    Price = 10
                });
            }
            catch (OrderValidException)
            {
                Console.WriteLine("All required fields must be initialized. For more information please see the log file");
            }

            //System exception will be generated and handled here
            try
            {

            }
            catch (SystemException)
            {
                new Logger().WriteExceptionToLog("System exception has been generated while adding new order");
                Console.WriteLine("System exception has been generated. For more information please see the log file");
            }

            Console.WriteLine("Press any key to finish...");
            Console.ReadLine();
        }
    }
}
