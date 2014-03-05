using System;
using System.Collections.Generic;
using IdpGie.Logic;

namespace IdpGie.Shapes {

	public abstract class ShapeHierarchical : Shape<ShapeState>, IShapeHierarchical {

		#region IShapeHierarchical implementation
		public IShapeHierarchical Parent {
			get;
			set;
		}

		public abstract IEnumerable<IShape> Children {
			get;
		}
		#endregion

		protected ShapeHierarchical (IFunctionInstance name) : this(name,null) {
		}

		protected ShapeHierarchical (IFunctionInstance name, IShapeHierarchical parent) : base(name) {
			this.Parent = parent;
		}

	}
}

