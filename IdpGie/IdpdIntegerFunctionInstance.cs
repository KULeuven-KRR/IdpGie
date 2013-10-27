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

namespace IdpGie {

    public class IdpdIntegerFunctionInstance : IdpdVirtualFunctionInstance {

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

        public IdpdIntegerFunctionInstance (string text) {
            this.value = int.Parse (text);
        }

        public override string ToString () {
            return value.ToString ();
        }

    }
}

