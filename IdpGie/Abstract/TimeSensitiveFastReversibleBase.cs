//
//  TimeSensitiveFastReversibleBase.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// The basic implementation of a <see cref="ITimeSensitiveFastReversible"/> interface. This implementation is used
	/// as a convinient basic implementation.
	/// </summary>
	public abstract class TimeSensitiveFastReversibleBase : TimeSensitiveReversibleBase, ITimeSensitiveFastReversible {

		private double checkpoint;

        #region ITimeSensitiveFastReversible implementation
		/// <summary>
		///  The time of the first checkpoint on which fast reverse can be guaranteed. 
		/// </summary>
		/// <value>
		///  The first checkpoint on which fast reverse can be guaranteed. 
		/// </value>
		public virtual double Checkpoint {
			get {
				return this.checkpoint;
			}
			protected set {
				this.checkpoint = value;
			}
		}
        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.TimeSensitiveFastReversibleBase"/> class with a given time and checkpoint.
		/// </summary>
		/// <param name='time'>
		/// The time when the event will occur.
		/// </param>
		/// <param name='checkpoint'>
		/// The first checkpoint on which the instance can be reversed fast.
		/// </param>
		protected TimeSensitiveFastReversibleBase (double time = 0.0d, double checkpoint = double.NegativeInfinity) : base(time) {
			this.Checkpoint = checkpoint;
		}

        #region ITimeSensitiveFastReversible implementation
		/// <summary>
		///  Determines whether this instance can be fast reversed to the specified time. 
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance can fast reverse the specified time; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='time'>
		/// If set to <c>true</c> time.
		/// </param>
		public virtual bool CanFastReverse (double time) {
			return time >= this.checkpoint && time <= this.Time;
		}
        #endregion

	}

}