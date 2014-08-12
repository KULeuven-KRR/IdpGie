//
//  CloneableBase.cs
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

using System;

namespace IdpGie.Abstract {
	/// <summary>
	/// An implementation of the <see cref="ICloneable{TResult}"/> interface.
	/// </summary>
	/// <typeparam name="TResult">
	/// The type of the resulting clone.
	/// </typeparam>
	public abstract class CloneableBase<TResult> : ICloneable<TResult> where TResult : class {
		/// <summary>
		/// Initializes a new instance of the <see cref="T:CloneableBase`1"/> class.
		/// </summary>
		protected CloneableBase () {
		}
		#region ICloneable implementation
		/// <summary>
		/// Clone this instance into a new object containing the same data.
		/// </summary>
		public abstract TResult Clone ();
		#endregion
		#region ICloneable implementation
		/// <summary>
		/// Clone this instance.
		/// </summary>
		/// <remarks>
		/// <para>This method is the <see cref="ICloneable"/> method, and is only used when the program
		/// accesses this object through this interface.</para>
		/// </remarks>
		object ICloneable.Clone () {
			return this.Clone ();
		}
		#endregion
	}
}

