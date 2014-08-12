//
//  ITimeSensitiveFastReversible.cs
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
	/// An interface that states that besides being time sensitive and reversible, there is a checkpoint on which the object can be reversed fast.
	/// </summary>
	public interface ITimeSensitiveFastReversible : ITimeSensitiveReversible {

		/// <summary>
		/// The time of the first checkpoint on which fast reverse can be guaranteed.
		/// </summary>
		/// <value>
		/// The first checkpoint on which fast reverse can be guaranteed.
		/// </value>
		/// <remarks>
		/// <para>In case no such checkpoint exists, the value ise <see cref="Double.NegativeInfinity"/> or <see cref="Double.NaN"/>.</para>
		/// </remarks>
		double Checkpoint {
			get;
		}

		/// <summary>
		/// Determines whether this instance can be fast reversed to the specified time.
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance can be fast reversed to the specified time; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='time'>
		/// The time to which the object should be reversed.
		/// </param>
		bool CanFastReverse (double time);
	}
}

