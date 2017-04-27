using System;

namespace Attributes.BLExceptions
{
    [Serializable]
    public class OrderStatusException : BLBaseException
    {
        private const string ExceptionMessage = 
            "Order status has not been set to correct value. For more details please see the log file";
        
        public OrderStatusException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}