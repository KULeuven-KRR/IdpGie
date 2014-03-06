//
//  TimeSensitiveBase.cs
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

namespace IdpGie.Abstract {

    public abstract class TimeSensitiveBase : ITimeSensitive {

        private double time;

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

        protected TimeSensitiveBase (double time = 0.0d) {
            this.Time = time;
        }

        #region IComparable implementation
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