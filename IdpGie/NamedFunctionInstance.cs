//
//  NamedFunctionInstance.cs
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

    public class NamedFunctionInstance : IFunction, IFunctionInstance {

        private readonly object namedObject;

        #region IName implementation
        public string Name {
            get {
                return namedObject.ToString ().ToLower ().Trim ();
            }
        }
        #endregion

        #region IPriority implementation
        public double Priority {
            get {
                return 2.0d;
            }
        }
        #endregion

        #region ITermHeader implementation
        public int Arity {
            get {
                return 0x00;
            }
        }

        public Tuple<string, int> Signature {
            get {
                return new Tuple<string, int> (this.Name, this.Arity);
            }
        }
        #endregion

        #region ITerm implementation
        public IFunctionInstance this [int index] {
            get {
                throw new IndexOutOfRangeException ();
            }
        }

        public ITermHeader Header {
            get {
                throw new System.NotImplementedException ();
            }
        }
        #endregion

        #region IFunctionInstance implementation
        public TermType Type {
            get {
                return TermType.Named;
            }
        }

        public IFunction Function {
            get {
                return this;
            }
        }
        #endregion

        #region IFunction implementation
        public TermType OutputType {
            get {
                return this.Type;
            }
        }

        public bool HasInstance {
            get {
                return false;
            }
        }
        #endregion

        public NamedFunctionInstance (object namedObject) {
            this.namedObject = namedObject;
        }

        #region ITermHeader implementation
        public string TermString (List<IFunctionInstance> terms) {
            return this.Name;
        }
        #endregion

        #region IFunction implementation
        public TermType InputType (int index) {
            throw new IndexOutOfRangeException ("A named object has no arguments.");
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset) {
            throw new IndexOutOfRangeException ("A named object has no arguments.");
        }

        public void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
            throw new IndexOutOfRangeException ("A named object has no arguments.");
        }

        public void WidenInput (IEnumerable<IFunctionInstance> terms) {
            throw new IndexOutOfRangeException ("A named object has no arguments.");
        }
        #endregion

        public override string ToString () {
            return this.Name;
        }

    }

}
