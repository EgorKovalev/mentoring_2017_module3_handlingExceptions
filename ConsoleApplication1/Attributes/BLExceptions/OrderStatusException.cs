using System;

namespace Attributes.BLExceptions
{
    [Serializable]
    public class OrderStatusException : BLBaseException
    {
        private const string ExceptionMessage = "Order status has not been set to a correct value";
        
        public OrderStatusException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}