using System;

namespace SalesOptimize.OneToManyMapper.Exceptions
{
	public class InvalidParentIdentifierException : Exception
	{
		public InvalidParentIdentifierException()
			: base()
		{ }

		public InvalidParentIdentifierException(string message)
			: base(message)
		{ }

		public InvalidParentIdentifierException(string message, Exception ex)
			: base(message, ex)
		{ }
	}
}
