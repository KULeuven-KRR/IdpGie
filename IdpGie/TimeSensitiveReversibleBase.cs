//
//  TimeSensitiveReversibleBase.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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

namespace IdpGie.Utils {
	public abstract class TimeSensitiveReversibleBase : TimeSensitiveBase, ITimeSensitiveReversible {
		protected TimeSensitiveReversibleBase (double time = 0.0d) : base (time) {
		}

		#region ITimeSensitiveReverseable implementation

		public virtual bool CanReverse (double time) {
			return false;
		}

		public virtual void Reverse (double time) {
			if (!this.CanReverse (time)) {
				throw new ArgumentException ("time", "Cannot reverse to the given time point.");
			}
		}

		#endregion

	}
}

