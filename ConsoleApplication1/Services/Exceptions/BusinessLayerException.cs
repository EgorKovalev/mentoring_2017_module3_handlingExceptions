using System;
using Domain.Exceptions;

namespace Services.Exceptions
{
    [Serializable]
    public abstract class BusinessLayerException : Exception
    {
        private const string FileName = @"\BusinessExceptions.txt";

        protected BusinessLayerException(string message, string ob)
            : base(message)
        {
            new Logger().WriteExceptionToLog(FileName, ob);
        }
    }
}
