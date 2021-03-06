//
//  TimeSensitiveReversibleBase.cs
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
	/// An implementation of the <see cref="ITimeSensitiveReversible"/> interface.
	/// </summary>
	public abstract class TimeSensitiveReversibleBase : TimeSensitiveBase, ITimeSensitiveReversible {

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.TimeSensitiveReversibleBase"/> class with a given time.
		/// </summary>
		/// <param name='time'>
		/// The time when the instance will occur.
		/// </param>
		protected TimeSensitiveReversibleBase (double time = 0.0d) : base(time) {
		}

        #region ITimeSensitiveReverseable implementation
		/// <summary>
		///  Determines whether this instance can be reversed to the specified time. 
		/// </summary>
		/// <returns>
		/// <c>true</c> if this instance can reverse the specified time; otherwise, <c>false</c>.
		/// </returns>
		/// <param name='time'>
		/// The given time to check for.
		/// </param>
		public virtual bool CanReverse (double time) {
			return false;
		}

		/// <summary>
		///  Reverses the instance to the specified time. 
		/// </summary>
		/// <param name='time'>
		///  The time to which we should reverse. 
		/// </param>
		/// <exception cref="ArgumentException">If the instance cannot be reversed to the given <paramref name="time"/>.</exception>
		public virtual void Reverse (double time) {
			if (!this.CanReverse (time)) {
				throw new ArgumentException ("time", "Cannot reverse to the given time point.");
			}
		}
        #endregion

	}

}