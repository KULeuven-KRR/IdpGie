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

namespace IdpGie {

    public abstract class TimeSensitiveBase : ITimesensitive {

        private double time;

        public double Time {
            get {
                return this.time;
            }
            protected set {
                this.time = value;
            }
        }

        protected TimeSensitiveBase (double time) {
            this.time = time;
        }

        #region IComparable implementation
        public int CompareTo (ITimesensitive other) {
            if (other != null) {
                return this.time.CompareTo (other.Time);
            } else {
                return -0x01;
            }
        }
        #endregion

    }

}