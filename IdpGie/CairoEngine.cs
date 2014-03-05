using System;
using Cairo;
using IdpGie.Core;

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
			foreach (IShape obj in this.Theory.Objects ().OrderBy (ZIndexComparator.Instance)) {
				obj.PaintObject (Context);
			}
			Context.Restore ();
		}

		#endregion

	}
}

