using System;

namespace Domain.Exceptions
{
    [Serializable]
    public class OrderValidException : DataLayerException
    {
        private const string ExceptionMessage = 
            "All required fields must be initialized. For more details please see the log file";

        public OrderValidException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}
