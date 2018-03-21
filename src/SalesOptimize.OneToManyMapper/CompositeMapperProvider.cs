using SalesOptimize.OneToManyMapper.Composite;
using SalesOptimize.OneToManyMapper.Composite.Abstractions;
using SalesOptimize.OneToManyMapper.Models;
using SalesOptimize.OneToManyMapper.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace SalesOptimize.OneToManyMapper
{
	public class CompositeMapperProvider : IOneToManyMapper
	{
		ICollection<MapperComposite> Collection { get; } = new HashSet<MapperComposite>();

		public void Add(int parent, int child)
		{
			if (Collection.Any(a => a.Value == parent))
				throw new ExistingParentIdentifierException($"Parent {parent} already added.");

			var mParent = new MapperThree(new Value(parent));
			mParent.Add(new MapperLeaf(new Value(child)));

			this.Collection.Add(mParent);
		}

		public void RemoveParent(int parent)
		{
			var mParent = Collection.FirstOrDefault(a => a.Value == parent);

			if (mParent == null)
				throw new InvalidParentIdentifierException($"Parent identifier {parent} is invalid.");

			this.Collection.Remove(mParent);
		}

		// As this is a not 'strict' relational implementation, 
		// this could conflit as 'child' identifier could repeat accross parent
		// E.g.: parent | child
		//          1   |   1
		//          1   |   2
		//          2   |   1
		public void RemoveChild(int child)
		{
			var parents = from parent in Collection
						  where parent.Get().Any(a => a.Value == child)
						  select parent;

			foreach (var parent in parents)
			{
				parent.Remove(child);
			}
		}

		public IEnumerable<int> GetChildren(int parent)
		{
			var mParent = Collection.SingleOrDefault(a => a.Value == parent);

			if (mParent == null)
				throw new InvalidParentIdentifierException($"Parent identifier {parent} is invalid.");

			return mParent.Get().Select(a => a.Value.Self);
		}

		// As this is a not 'strict' relational implementation, 
		// this could conflit as 'child' identifier could repeat accross parent
		// E.g.: parent | child
		//          1   |   1
		//          1   |   2
		//          2   |   1
		public int GetParent(int child)
			=> Collection.FirstOrDefault(a => a.Get().Any(b => b.Value == child)).Value.Self;

		// Update would conflit as 'child' identifier could repeat accross parent
		public void UpdateParent(int oldParent, int newParent)
		{
			var mOldParent = Collection.SingleOrDefault(a => a.Value == oldParent);
			var mNewParent = Collection.SingleOrDefault(a => a.Value == newParent);

			foreach (var child in mOldParent.Get())
			{
				mNewParent.Add(child);
			}

			this.RemoveParent(oldParent);
		}

		// Update would conflit as 'child' identifier could repeat accross parent
		public void UpdateChild(int oldChild, int newChild)
		{
			var mOldChildParentId = this.GetParent(oldChild);
			var parents = Collection.Where(a => a.Get().Any(c => c.Value == oldChild));

			foreach (var parent in parents)
			{
				parent.Remove(oldChild);
				parent.Add(new MapperLeaf(new Value(newChild)));
			}
		}
	}
}
