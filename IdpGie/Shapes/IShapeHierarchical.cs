using System;
using System.Collections.Generic;

namespace IdpGie.Shapes {

	public interface IShapeHierarchical : IShape {

		IShapeHierarchical Parent {
			get;
		}

		IEnumerable<IShape> Children {
			get;
		}

		void RegisterChild (IShapeHierarchical child);

		void UnregisterChild (IShapeHierarchical child);

	}
}

