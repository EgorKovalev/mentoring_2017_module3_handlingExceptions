using System;

namespace Domain.Exceptions
{
    [Serializable]
    public abstract class DataLayerException : Exception
    {
        private const string FileName = @"\DataExceptions.txt";

        protected DataLayerException(string message, string ob) : base(message)
        {
            new Logger().WriteExceptionToLog(FileName, ob);
        }
    }
}
