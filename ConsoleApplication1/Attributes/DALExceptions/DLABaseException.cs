using System;

namespace Attributes.DALExceptions
{
    [Serializable]
    public abstract class DLABaseException : Exception
    {
        protected DLABaseException(string message, string ob) : base(message)
        { }
    }
}
