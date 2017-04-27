using System;

namespace Attributes.DALExceptions
{
    [Serializable]
    public class RequiredFieldsException : DLABaseException
    {
        private const string ExceptionMessage = "Not all required fields have been initialized";

        public RequiredFieldsException(string order)
            : base(ExceptionMessage, order)
        { }
    }
}
