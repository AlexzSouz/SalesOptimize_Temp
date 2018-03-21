using System;

namespace SalesOptimize.OneToManyMapper.Exceptions
{
	public class InvalidChildIdentifierException : Exception
	{
		public InvalidChildIdentifierException()
			: base ()
		{ }

		public InvalidChildIdentifierException(string message)
			: base(message)
		{ }

		public InvalidChildIdentifierException(string message, Exception ex)
			: base(message, ex)
		{ }
	}
}
