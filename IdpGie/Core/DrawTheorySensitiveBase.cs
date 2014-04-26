//
//  DrawTheorySensitiveBase.cs
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

namespace IdpGie.Core {

	/// <summary>
	/// An implementation of the <see cref="IDrawTheorySensitive"/> interface.
	/// </summary>
	public abstract class DrawTheorySensitiveBase : IDrawTheorySensitive {

		#region IDrawTheorySensitive implementation
		/// <summary>
		/// Gets or sets the theory to which the <see cref="IDrawTheorySensitive"/> is sensitive to.
		/// </summary>
		/// <value>
		/// The theory to which the <see cref="IDrawTheorySensitive"/> is sensitive to.
		/// </value>
		public IDrawTheory Theory {
			get;
			set;
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Core.DrawTheorySensitiveBase"/> class without an initial <see cref="IDrawTheory"/>.
		/// </summary>
		protected DrawTheorySensitiveBase () : this(null) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Core.DrawTheorySensitiveBase"/> class with a given initial <see cref="IDrawTheory"/> instance.
		/// </summary>
		/// <param name='theory'>
		/// The initial draw theory.
		/// </param>
		protected DrawTheorySensitiveBase (IDrawTheory theory) {
			this.Theory = theory;
		}

	}
}

