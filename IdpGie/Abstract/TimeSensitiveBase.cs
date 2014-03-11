//
//  TimeSensitiveBase.cs
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
	/// A basic implementation of the <see cref="ITimeSensitive"/> interface. This class is used as a convinient basic implementation.
	/// </summary>
	public abstract class TimeSensitiveBase : ITimeSensitive {

		private double time;

		/// <summary>
		///  Gets the tick when the event will take place. 
		/// </summary>
		/// <value>
		///  The tick when the event will take place.
		/// </value>
		/// <remarks>
		/// <para>The value is never equal to <see cref="Double.NaN"/>, <see cref="Double.NegativeInfinity"/> and <see cref="Double.PositiveInfinity"/> are allowed.</para>
		/// </remarks>
		public virtual double Time {
			get {
				return this.time;
			}
			protected set {
				if (!double.IsNaN (value)) {
					this.time = value;
				} else {
					throw new ArgumentException ("Time must be a number different from NaN.", "time");
				}
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.TimeSensitiveBase"/> class with the given tick when the event will take place.
		/// </summary>
		/// <param name='time'>
		/// The tick when the event will take place.
		/// </param>
		protected TimeSensitiveBase (double time = 0.0d) {
			this.Time = time;
		}

		#region IComparable implementation
		/// <summary>
		/// Compares this <see cref="ITimeSensitive"/> instance with the given one.
		/// </summary>
		/// <returns>
		/// A value smaller than zero if this instance will take place before the given one, a value larger than zero if this event
		/// will take place after the given one, zero if both events will be triggered at the same time.
		/// </returns>
		/// <param name='other'>
		/// The <see cref="ITimeSensitive"/> instance to compare with.
		/// </param>
		/// <remarks>
		/// <para>In case the given <see cref="ITimeSensitive"/> is not effective, a negative value is returned.</para>
		/// </remarks>
		public virtual int CompareTo (ITimeSensitive other) {
			if (other != null) {
				return this.time.CompareTo (other.Time);
			} else {
				return -0x01;
			}
		}
		#endregion

	}

}