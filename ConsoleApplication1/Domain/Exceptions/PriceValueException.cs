using System;

namespace Domain.Exceptions
{
    public class PriceValueException : Exception
    {
        private const string PriceValueExceptionMessage = "Price should be more than 0. For more details please see the log file";
        private const string Path = "E:/Test/Text2.txt";

        public PriceValueException(string order)
            : base(PriceValueExceptionMessage)
        {
            var log = new Logger();
            log.WriteExceptionToLog(Path, order);
        }
    }
}
