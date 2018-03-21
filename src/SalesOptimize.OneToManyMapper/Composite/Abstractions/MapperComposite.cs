using SalesOptimize.OneToManyMapper.Models;
using System.Collections.Generic;

namespace SalesOptimize.OneToManyMapper.Composite.Abstractions
{
	public abstract class MapperComposite
	{
		public Value Value { get; }

		protected ICollection<MapperComposite> Children { get; } = new HashSet<MapperComposite>();

		public MapperComposite(Value value)
		{
			Value = value;
		}

		public abstract void Add(MapperComposite mapper);

		public abstract void Remove(int identifier);

		public abstract ICollection<MapperComposite> Get();
	}
}
