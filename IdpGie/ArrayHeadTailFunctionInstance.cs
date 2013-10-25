//
//  ArrayFunctionInstance.cs
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

    public class ArrayHeadTailFunctionInstance : IArrayFunctionInstance {

        private readonly IFunctionInstance term;
        private readonly IArrayFunctionInstance tail;

        #region IFunctionInstance implementation
        public IFunctionInstance this [int index] {
            get {
                switch (index) {
                case 0x00:
                    return this.term;
                case 0x01:
                    return this.tail;
                default :
                    throw new IndexOutOfRangeException ("An array head-tail function has only two arguments.");
                }
            }
        }

        public ITermHeader Header {
            get {
                return ArrayFunction.Instance;
            }
        }
        #endregion

        public IFunctionInstance Term {
            get {
                return this.term;
            }
        }

        public IArrayFunctionInstance Tail {
            get {
                return this.tail;
            }
        }

        #region IFunctionInstance implementation
        public TermType Type {
            get {
                return TermType.All;
            }
        }

        public IFunction Function {
            get {
                return ArrayFunction.Instance;
            }
        }
        #endregion



        public ArrayHeadTailFunctionInstance (IFunctionInstance term, IArrayFunctionInstance tail) {
            this.term = term;
            this.tail = tail;
        }

        public override string ToString () {
            //return String.Format ("[{0}|{1}]", this.term, this.tail);
            return ArrayFunction.Instance.TermString (this);
        }

    }

}