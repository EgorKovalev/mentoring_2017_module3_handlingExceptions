using System;

namespace Attributes.DALExceptions
{
    [Serializable]
    public abstract class DLABaseException : Exception
    {
		public string AdditionalDetails { get; set; }

        protected DLABaseException(string message, string ob) : base(message)
        {
			AdditionalDetails = ob;
		}
    }
}