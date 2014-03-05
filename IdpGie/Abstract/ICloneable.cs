//
//  ICloneable.cs
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
	/// An interface to provide a more convenient <see cref="ICloneable.Clone"/> method with type bounds.
	/// </summary>
	/// <typeparam name="TResult">
	/// The type of the result of the clone.
	/// </typeparam>
	public interface ICloneable<TResult> : ICloneable where TResult : class {

		/// <summary>
		/// Creates a new instance with containing the same information as this object.
		/// </summary>
		new TResult Clone ();
	}
}

