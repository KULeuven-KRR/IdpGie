//
//  TermBase.cs
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

    public class TermBase : NameBase {

        private int arity;

        public int Arity {
            get {
                return this.arity;
            }
        }

        public TermBase (string name, int arity) : base(name) {
            this.arity = arity;
        }

        public override bool Equals (object obj) {
            if (obj != null && obj is NameBase) {
                TermBase nb = (TermBase)obj;
                return this.arity == nb.arity && this.GetType ().Equals (nb.GetType ()) && base.Equals (obj);
            } else {
                return false;
            }
        }

        public override int GetHashCode () {
            return base.GetHashCode () ^ this.arity.GetHashCode () ^ this.GetType ().GetHashCode ();
        }

        public override string ToString () {
            return string.Format ("{0}/{1}", this.Name, this.Arity);
        }

    }
}

