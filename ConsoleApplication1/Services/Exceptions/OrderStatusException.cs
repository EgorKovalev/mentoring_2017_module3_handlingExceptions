using System;

namespace Services.Exceptions
{
    [Serializable]
    public class OrderStatusException : BusinessLayerException
    {
        private const string ExceptionMessage = 
            "Order status has not been set to correct value. For more details please see the log file";
        
        public OrderStatusException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}
