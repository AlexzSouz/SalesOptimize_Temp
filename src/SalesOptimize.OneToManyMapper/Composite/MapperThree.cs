using SalesOptimize.OneToManyMapper.Composite.Abstractions;
using SalesOptimize.OneToManyMapper.Models;
using SalesOptimize.OneToManyMapper.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesOptimize.OneToManyMapper.Composite
{
	public class MapperThree : MapperComposite
	{
		public MapperThree(Value value)
			: base(value)
		{ }

		public override void Add(MapperComposite mapper)
		{
			if (this.Children.Any(a => a.Value.Equals(mapper.Value)))
				throw new ExistingChildIdentifierException($"Child with identifier {mapper.Value} already added.");

			this.Children.Add(mapper);
		}

		public override void Remove(int identifier)
		{
			var child = Children.SingleOrDefault(a => a.Value == identifier);
			if (child == null)
				throw new InvalidChildIdentifierException($"Child identifier {identifier} is invalid.");

			this.Children.Remove(child);
		}

		public override ICollection<MapperComposite> Get()
		{
			return this.Children;
		}
	}
}
