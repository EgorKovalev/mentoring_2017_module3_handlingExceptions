using System;

namespace Attributes.BLExceptions
{
    [Serializable]
    public abstract class BLBaseException : Exception
    {
        protected BLBaseException(string message, string ob)
            : base(message)
        { }
    }
}