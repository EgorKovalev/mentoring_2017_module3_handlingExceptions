using System;

namespace Domain.Exceptions
{
    [Serializable]
    public class UpdateDbException : DataLayerException
    {
        private const string ExceptionMessage = 
            "An exception has been threw while updating database. For more details please see the log file";
        
        public UpdateDbException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}
