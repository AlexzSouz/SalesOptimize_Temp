using SalesOptimize.OneToManyMapper.Composite.Abstractions;
using SalesOptimize.OneToManyMapper.Models;
using System;
using System.Collections.Generic;

namespace SalesOptimize.OneToManyMapper.Composite
{
	public class MapperLeaf : MapperComposite
	{
		public MapperLeaf(Value value)
			: base(value)
		{ }

		public override void Add(MapperComposite identifier)
		{
			throw new NotImplementedException();
		}

		public override void Remove(int identifier)
		{
			throw new NotImplementedException();
		}

		public override ICollection<MapperComposite> Get()
		{
			return null;
		}
	}
}
