using System;
using System.Collections.Generic;

namespace IdpGie {

	public interface IShapeHierarchical : IShape {

		IShapeHierarchical Parent {
			get;
		}

		IEnumerable<IShape> Children {
			get;
		}

	}
}

