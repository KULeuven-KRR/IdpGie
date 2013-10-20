//
//  ArrayFunction.cs
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
using System.Text;
using System.Collections.Generic;

namespace IdpGie {

    public sealed class ArrayFunction : Function {

        public static readonly ArrayFunction Function = new ArrayFunction ();

        private ArrayFunction () : base("_arr",2) {
        }

        public override string TermString (List<IFunctionInstance> terms) {
            IFunctionInstance tail = terms [0x01];
            StringBuilder sb = new StringBuilder ("[");
            sb.Append (terms [0x00]);
            while (tail != null) {
                if (tail.Header is ArrayFunction) {
                    sb.Append (',');
                    tail = tail [0x00];
                    sb.Append (tail [0x00]);
                } else if (!(tail.Header is ArrayTailFunction)) {
                    sb.Append ('|');
                    sb.Append (tail);
                    tail = null;
                } else {
                    tail = null;
                }
            }
            sb.Append ("]");
            return sb.ToString ();
        }

    }

}

