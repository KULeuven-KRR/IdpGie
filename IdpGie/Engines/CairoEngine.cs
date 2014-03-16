//
//  CairoEngine.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

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

		#region IEngine implementation
		/// <summary>
		/// A method that specifies that the engine should convert the set of <see cref="IdpGie.Shapes.IShape"/> instances to graphical output.
		/// </summary>
		public override void Process () {
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

