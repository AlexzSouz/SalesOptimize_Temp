using System;

namespace SalesOptimize.OneToManyMapper.Exceptions
{
	public class ExistingParentIdentifierException : Exception
	{
		public ExistingParentIdentifierException()
			: base()
		{ }

		public ExistingParentIdentifierException(string message)
			: base(message)
		{ }

		public ExistingParentIdentifierException(string message, Exception ex)
			: base(message, ex)
		{ }
	}
}
