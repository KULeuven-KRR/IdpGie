using Cairo;
using IdpGie.Abstract;
using IdpGie.Core;
using IdpGie.Shapes;
using IdpGie.UserInterface;
using IdpGie.Utils;

namespace IdpGie.Engines {
	public class CairoEngine : IRenderEngine {
		public readonly DrawTheory Theory;

		public Context Context {
			get;
			set;
		}

		public CairoEngine (DrawTheory theory) {
			this.Theory = theory;
		}

		#region IRenderEngine implementation

		public void Render () {
			Context.Save ();
			Context.SetFill (0.0d, 0.0d, 0.0d);
			foreach (IShape obj in this.Theory.Objects<IShape> ().OrderBy (ZIndexComparator.Instance)) {
				obj.PaintObject (Context);
			}
			Context.Restore ();
		}

		#endregion

	}
}

