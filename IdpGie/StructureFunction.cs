//
//  StructureFunction.cs
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
    public class StructureFunction : NamePriorityArityBase, IFunction {

        #region IPriority implementation
        public double Priority {
            get {
                throw new System.NotImplementedException ();
            }
        }
        #endregion

        #region ITermHeader implementation
        public string TermString (IEnumerable<IFunctionInstance> terms) {
            throw new System.NotImplementedException ();
        }

        public int Arity {
            get {
                throw new System.NotImplementedException ();
            }
        }

        public Tuple<string, int> Signature {
            get {
                throw new System.NotImplementedException ();
            }
        }
        #endregion

        #region IFunction implementation
        public TermType InputType (int index) {
            throw new System.NotImplementedException ();
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset) {
            throw new System.NotImplementedException ();
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
            throw new System.NotImplementedException ();
        }

        public void WidenInput (IEnumerable<IFunctionInstance> terms) {
            throw new System.NotImplementedException ();
        }

        public TermType OutputType {
            get {
                throw new System.NotImplementedException ();
            }
        }

        public bool HasInstance {
            get {
                throw new System.NotImplementedException ();
            }
        }
        #endregion

        public StructureFunction () {
        }
    }
}

