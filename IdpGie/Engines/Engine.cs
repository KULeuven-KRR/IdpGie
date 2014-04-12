//
//  Engine.cs
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

using IdpGie.Core;

namespace IdpGie.Engines {

	/// <summary>
	/// A basic implementation of a <see cref="IEngine"/> that stores the <see cref="IDrawTheory"/> that feeds the <see cref="IEngine"/> with the set of <see cref="IdpGie.Shapes.IShape"/> instances.
	/// </summary>
	public abstract class Engine : DrawTheorySensitiveBase, IEngine {

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.Engine"/> class without an intial <see cref="IDrawTheory"/>.
		/// </summary>
		protected Engine () : base() {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.Engine"/> class with a given initial <see cref="IDrawTheory"/>.
		/// </summary>
		/// <param name='theory'>
		/// The given initial <see cref="IDrawTheory"/> that feeds the <see cref="IEngine"/> with <see cref="IdpGie.Shapes.IShape"/> instances.
		/// </param>
		protected Engine (IDrawTheory theory) : base(theory) {
		}

		#region IEngine implementation
		/// <summary>
		/// Converts the set of <see cref="IdpGie.Shapes.IShape"/> by converting it into a readable format.
		/// </summary>
		public abstract void Process ();
		#endregion

	}
}

