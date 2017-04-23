using System;

namespace Domain.Exceptions
{
    public class OrderStatusException : Exception
    {
        private const string OrderStatusExceptionMessage = "Order status has not been set to correct value. For more details please see the log file";
        private const string Path = "E:/Test/Text2.txt";

        public OrderStatusException(string order)
            : base(OrderStatusExceptionMessage)
        {
            var log = new Logger();
            log.WriteExceptionToLog(Path, order);
        }
    }
}
