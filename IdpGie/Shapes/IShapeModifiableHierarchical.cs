using System;

namespace IdpGie.Shapes
{
	public interface IShapeModifiableHierarchical : IShapeHierarchical {

		void addChild (IShape child);

		void removeChild (IShape child);

	}
}

