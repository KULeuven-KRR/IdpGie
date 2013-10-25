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
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace IdpGie {

    public sealed class ArrayFunction : Function {

        public static readonly ArrayFunction Instance = new ArrayFunction ();

        private ArrayFunction () : base("[]",2) {
        }

        public static IArrayFunctionInstance ToInstance (IEnumerable<IFunctionInstance> enumerable) {
            IArrayFunctionInstance tail = ArrayTailFunction.Instance;
            foreach (IFunctionInstance t in enumerable.Reverse()) {
                tail = new ArrayHeadTailFunctionInstance (t, tail);
            }
            return tail;
        }

        private void generateRestTermString (StringBuilder sb, ITerm tail) {
            while (tail != null) {
                if (this.Equals (tail.Header)) {
                    sb.Append (',');
                    sb.Append (tail [0x00]);
                    tail = tail [0x01];
                } else if (!ArrayTailFunction.Instance.Equals (tail.Header)) {
                    sb.Append ('|');
                    sb.Append (tail);
                    tail = null;
                } else {
                    tail = null;
                }
            }
        }

        public override string TermString (List<IFunctionInstance> terms) {
            ITerm tail = terms [0x01];
            StringBuilder sb = new StringBuilder ("[");
            sb.Append (terms [0x00]);
            this.generateRestTermString (sb, tail);
            sb.Append ("]");
            return sb.ToString ();
        }

        public string TermString (IArrayFunctionInstance instance) {
            StringBuilder sb = new StringBuilder ("[");
            if (this.Equals (instance.Header)) {
                ArrayHeadTailFunctionInstance ahtfi = (ArrayHeadTailFunctionInstance)instance;
                sb.Append (ahtfi.Term);
                instance = ahtfi.Tail;
            }
            this.generateRestTermString (sb, instance);
            sb.Append ("]");
            return sb.ToString ();
        }

    }

}

