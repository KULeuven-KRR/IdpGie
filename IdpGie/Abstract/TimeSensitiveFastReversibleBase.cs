//
//  TimeSensitiveFastReversibleBase.cs
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

    public abstract class TimeSensitiveFastReversibleBase : TimeSensitiveReversibleBase, ITimeSensitiveFastReversible {

        private double checkpoint;

        #region ITimeSensitiveFastReversible implementation
        public virtual double Checkpoint {
            get {
                return this.checkpoint;
            }
            protected set {
                this.checkpoint = value;
            }
        }
        #endregion

        protected TimeSensitiveFastReversibleBase (double time = 0.0d, double checkpoint = double.NegativeInfinity) : base(time) {
            this.Checkpoint = checkpoint;
        }

        #region ITimeSensitiveFastReversible implementation
        public virtual bool CanFastReverse (double time) {
            return time >= this.checkpoint && time <= this.Time;
        }
        #endregion

    }

}