using IdpGie.Abstract;
using IdpGie.Logic;

namespace IdpGie.Shapes {
	public class ShapePage : ShapeModifiableHierarchical<ShapeState>, ITitle {

		public string Title {
			get;
			private set;
		}

		public ShapePage (IFunctionInstance name) : this(name,string.Empty) {
		}

		public ShapePage (IFunctionInstance name, IShapeHierarchical parent) : this(name,parent,string.Empty) {
		}

		public ShapePage (IFunctionInstance name, string title) : base(name) {
			this.Title = title;
		}

		public ShapePage (IFunctionInstance name, IShapeHierarchical parent, string title) : base(name,parent) {
			this.Title = title;
		}

	}
}

