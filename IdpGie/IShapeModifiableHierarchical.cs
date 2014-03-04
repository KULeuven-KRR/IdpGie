using System;

namespace IdpGie
{
	public interface IShapeModifiableHierarchical : IShapeHierarchical {

		void addChild (IShape child);

		void removeChild (IShape child);

	}
}

