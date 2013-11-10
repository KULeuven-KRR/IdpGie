//
//  IdpdObjectTimeStateModifier.cs
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

    public class IdpdObjectTimeStateModifier : TimeSensitiveBase {

        private readonly Action<IdpdObjectTimeState> action;

        public Action<IdpdObjectTimeState> Action {
            get {
                return this.action;
            }
        }

        public IdpdObjectTimeStateModifier (double time, Action<IdpdObjectTimeState> action) : base(time) {
            this.action = action;
        }

        public override string ToString () {
            return string.Format ("<{0}:{1}>", this.Time, Action);
        }

        public override int CompareTo (ITimesensitive other) {
            int comp = base.CompareTo (other);
            if (comp != 0x00) {
                return comp;
            } else if (other is IdpdObjectTimeStateModifier) {
                IdpdObjectTimeStateModifier mod = (IdpdObjectTimeStateModifier)other;
                return this.action.GetHashCode ().CompareTo (mod.action.GetHashCode ());
            } else {
                return 0x00;
            }
        }

    }

}

