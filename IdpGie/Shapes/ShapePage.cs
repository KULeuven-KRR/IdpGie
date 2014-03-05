using System;
using IdpGie.Logic;

namespace IdpGie.Shapes {
	public class ShapePage : ShapeModifiableHierarchical<ShapeState> {

		protected ShapePage (IFunctionInstance name) : base(name) {
		}

		protected ShapePage (IFunctionInstance name, IShapeHierarchical parent) : base(name,parent) {
		}

	}
}

