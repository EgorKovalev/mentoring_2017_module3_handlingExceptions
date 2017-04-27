using System;

namespace Attributes.BLExceptions
{
	[Serializable]
	public class PriceValueException : BLBaseException
	{
		private const string ExceptionMessage = "Price value is not correct";

		public PriceValueException(string order)
            : base(ExceptionMessage, order)
        { }
	}
}
