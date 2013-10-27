//
//  ArrayTailFunction.cs
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
using System.Collections.Generic;

namespace IdpGie {

    public sealed class ArrayTailFunction : Function, IArrayFunctionInstance {

        public static readonly ArrayTailFunction Instance = new ArrayTailFunction ();

        #region IFunctionInstance implementation
        public IFunctionInstance this [int index] {
            get {
                throw new IndexOutOfRangeException ();
            }
        }

        public ITermHeader Header {
            get {
                return this;
            }
        }

        public object Value {
            get {
                return this;
            }
        }
        #endregion

        #region IFunctionInstance implementation
        public TermType Type {
            get {
                return TermType.All;
            }
        }

        public IFunction Function {
            get {
                return this;
            }
        }
        #endregion

        #region ITerm implementation
        public IEnumerable<IFunctionInstance> Terms {
            get {
                yield break;
            }
        }
        #endregion

        private ArrayTailFunction () : base("[]",0x00) {
        }

        public override string TermString (List<IFunctionInstance> terms) {
            return this.ToString ();
        }

        public override string ToString () {
            return "[]";
        }

        #region ITerm implementation
        public bool Equals (ITerm other) {
            return Object.Equals (this, other);
        }
        #endregion






    }
}

