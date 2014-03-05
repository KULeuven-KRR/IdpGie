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
using IdpGie.Abstract;

namespace IdpGie.Shapes.Modifiers {

    public class ShapeStateModifier : TimeSensitiveBase, IShapeStateModifier {

        private readonly Action<ShapeState> action, reverseAction;

        #region IShapeStateModifier implementation
        public bool Reversible {
            get {
                return this.reverseAction != null;
            }
        }

        public Action<ShapeState> Action {
            get {
                return this.action;
            }
        }

        public Action<ShapeState> ReverseAction {
            get {
                return this.reverseAction;
            }
        }
        #endregion

        public ShapeStateModifier (double time, Action<ShapeState> action, Action<ShapeState> reverseAction = null) : base(time) {
            if (action != null) {
                this.action = action;
            } else {
                throw new ArgumentNullException ("action", "Action must be effective.");
            }
            this.reverseAction = reverseAction;
        }

		public ShapeStateModifier (double time, string key, object value) : this(time,x => x.SetElement(key,value)) {
		}

        public override string ToString () {
            return string.Format ("<{0}:{1}:{2}>", this.Time, Action, this.reverseAction);
        }

        public override int CompareTo (ITimesensitive other) {
            int comp = base.CompareTo (other);
            if (comp != 0x00) {
                return comp;
            } else if (other is ShapeStateModifier) {
                ShapeStateModifier mod = (ShapeStateModifier)other;
                comp = this.action.GetHashCode ().CompareTo (mod.action.GetHashCode ());
                if (comp != 0x00) {
                    return comp;
                } else if (this.reverseAction != null && mod.reverseAction != null) {
                    return this.reverseAction.GetHashCode ().CompareTo (mod.reverseAction.GetHashCode ());
                }
            }
            return 0x00;
        }

    }

}

