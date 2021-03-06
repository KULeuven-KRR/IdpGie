//
//  Integer.cs
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
using System.Text.RegularExpressions;

namespace IdpGie.Logic {

    public class FunctionIntegerInstance : FunctionVirtualInstance {

        private int value;

        #region implemented abstract members of IdpGie.IdpdVirtualFunctionInstance
        public override TermType Type {
            get {
                return TermType.Int;
            }
        }

        public override object Value {
            get {
                return value;
            }
        }
        #endregion

        public FunctionIntegerInstance (string text) {
            this.value = int.Parse (text);
        }

        public override string ToString () {
            return value.ToString ();
        }

        #region implemented abstract members of IdpGie.IdpVirtualFunctionInstance
        public override object ConvertedValue (TermType target) {
            switch (target) {
            case TermType.Int:
                return this.Value;
            case TermType.Float:
                return (double)this.value;
            default :
                throw new InvalidCastException ();
            }
        }
        #endregion

    }
}

