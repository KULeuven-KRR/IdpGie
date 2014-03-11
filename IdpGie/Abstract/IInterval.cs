//
//  IInterval.cs
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
	/// An interface to specify an interval.
	/// </summary>
	/// <typeparam name="T"> the type objects described by the interval.
	/// <remarks>
	/// <para>A interval contains a <see cref="IInterval{T}.Min"/>, <see cref="IInterval{T}.Max"/> and <see cref="IInterval{T}.Contains(T)"/>.</para>
	/// </remarks>
	public interface IInterval<T> {

		/// <summary>
		/// Gets or sets the minimum of the interval.
		/// </summary>
		/// <value>
		/// The minimum of the interval.
		/// </value>
		T Min {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the maximum of the interval.
		/// </summary>
		/// <value>
		/// The maximum of the interval.
		/// </value>
		T Max {
			get;
			set;
		}

		/// <summary>
		/// Checks if the interval contains the specified value.
		/// </summary>
		/// <param name='value'>
		/// The given item to check if it is an element of this interval.
		/// </param>
		/// <returns>
		/// <c>true</c> if the <see cref="IInterval{T}"/> contains the given <paramref name="value"/>, <c>false</c> otherwise.
		/// </returns>
		bool Contains (T value);

	}
}

