//
//  ITimesensitive.cs
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
	/// An interface specifying that the object is sensitive to time.
	/// </summary>
	/// <remarks>
	/// <para>This interface inherits the <see cref="IComparable{ITimeSensitive}"/> so that the objects can be
	/// ranked according to the time events.</para>
	/// </remarks>
	public interface ITimeSensitive : IComparable<ITimeSensitive> {

		/// <summary>
		/// Gets the tick when the event will take place.
		/// </summary>
		/// <value>
		/// The tick when the event will take place.
		/// </value>
		/// <remarks>
		/// <para>The unit of this interface is arbitrary, although we advise to use seconds.</para>
		/// </remarks>
		double Time {
			get;
		}

	}
}

