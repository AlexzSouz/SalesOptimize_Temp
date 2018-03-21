using System;

namespace SalesOptimize.OneToManyMapper.Exceptions
{
	public class ExistingChildIdentifierException : Exception
	{
		public ExistingChildIdentifierException()
			: base ()
		{ }

		public ExistingChildIdentifierException(string message)
			: base(message)
		{ }

		public ExistingChildIdentifierException(string message, Exception ex)
			: base(message, ex)
		{ }
	}
}
