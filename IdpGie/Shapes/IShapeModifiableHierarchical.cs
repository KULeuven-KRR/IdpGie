using System;

namespace IdpGie.Shapes {
	public interface IShapeModifiableHierarchical : IShapeHierarchical {

		void AddChild (IShape child);

		void RemoveChild (IShape child);

	}
}

