using System;
using System.Collections.Generic;

namespace SalesOptimize.OneToManyMapper
{
	// Docorator patterns user to provide a extensibility point
	// as we could use some other 'underline' one to many mapper
	public class MapperDecorator : IOneToManyMapper
	{
		readonly IOneToManyMapper _oneToManyMapper;

		public MapperDecorator(IOneToManyMapper oneToManyMapper)
		{
			_oneToManyMapper = oneToManyMapper ?? throw new ArgumentException(nameof(oneToManyMapper));
		}

		public void Add(int parent, int child)
		{
			_oneToManyMapper.Add(parent, child);
		}

		public IEnumerable<int> GetChildren(int parent)
		{
			return _oneToManyMapper.GetChildren(parent);
		}

		public int GetParent(int child)
		{
			return _oneToManyMapper.GetParent(child);
		}

		public void RemoveChild(int child)
		{
			_oneToManyMapper.RemoveChild(child);
		}

		public void RemoveParent(int parent)
		{
			_oneToManyMapper.RemoveParent(parent);
		}

		public void UpdateChild(int oldChild, int newChild)
		{
			_oneToManyMapper.UpdateChild(oldChild, newChild);
		}

		public void UpdateParent(int oldParent, int newParent)
		{
			_oneToManyMapper.UpdateParent(oldParent, newParent);
		}
	}
}
