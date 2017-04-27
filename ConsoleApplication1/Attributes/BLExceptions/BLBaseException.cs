using System;

namespace Attributes.BLExceptions
{
    [Serializable]
    public abstract class BLBaseException : Exception
    {
		public string AdditionalDetails { get; set; }

        protected BLBaseException(string message, string ob)
            : base(message)
        {
			AdditionalDetails = ob;
		}
    }
}