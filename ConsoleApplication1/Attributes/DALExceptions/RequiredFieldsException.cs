using System;

namespace Attributes.DALExceptions
{
    [Serializable]
    public class RequiredFieldsException : DLABaseException
    {
        private const string ExceptionMessage = 
            "All required fields must be initialized. For more details please see the log file";

        public RequiredFieldsException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}
