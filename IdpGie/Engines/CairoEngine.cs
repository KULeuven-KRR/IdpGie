using Cairo;
using IdpGie.Abstract;
using IdpGie.Core;
using IdpGie.Shapes;
using IdpGie.UserInterface;
using IdpGie.Utils;

namespace IdpGie.Engines {

	/// <summary>
	/// An <see cref="IRenderEngine"/> that produces Cairo graphics.
	/// </summary>
	public class CairoEngine : Engine, IRenderEngine {

		/// <summary>
		/// Gets or sets the context, the target on which the data is rendered.
		/// </summary>
		/// <value>
		/// The context, the target on which the data is rendered.
		/// </value>
		public Context Context {
			get;
			set;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.CairoEngine"/> class with a specified initial <see cref="IDrawTheory"/>.
		/// </summary>
		/// <param name='theory'>
		/// The initial <see cref="IDrawTheory"/> instance.
		/// </param>
		public CairoEngine (IDrawTheory theory) : this(theory,null) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.CairoEngine"/> class with a specified initial <see cref="IDrawTheory"/> and <see cref="Context"/>.
		/// </summary>
		/// <param name='theory'>
		/// The initial <see cref="IDrawTheory"/> instance.
		/// </param>
		/// <param name='context'>
		/// The initial <see cref="Context"/> to render <see cref="IdpGie.Shapes.IShape"/> instances to.
		/// </param>
		public CairoEngine (IDrawTheory theory, Context context) : base(theory) {
		}

		#region IRenderEngine implementation
		/// <summary>
		/// A method that specifies that the engine should convert the set of <see cref="IdpGie.Shapes.IShape"/> instances to graphical output.
		/// </summary>
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

