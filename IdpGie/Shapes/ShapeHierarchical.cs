using System;
using System.Collections.Generic;
using IdpGie.Logic;

namespace IdpGie.Shapes {

	public abstract class ShapeHierarchical<TShapeState> : Shape<TShapeState>, IShapeHierarchical where TShapeState : IShapeState, new() {

		private IShapeHierarchical parent;

		#region IShapeHierarchical implementation
		public IShapeHierarchical Parent {
			get {
				return this.parent;
			}
			set {
				IShapeHierarchical prnt = this.parent;
				this.parent = null;
				if (prnt != null) {
					prnt.UnregisterChild (this);
				}
				this.parent = value;
				if (value != null) {
					value.RegisterChild (this);
				}
			}
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

		#region IShapeHierarchical implementation
		public virtual void RegisterChild (IShapeHierarchical child) {
		}

		public virtual void UnregisterChild (IShapeHierarchical child) {
		}
		#endregion


	}
}

