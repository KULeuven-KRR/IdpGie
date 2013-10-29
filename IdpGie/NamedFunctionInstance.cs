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
                return this;
            }
        }

        public IEnumerable<IFunctionInstance> Terms {
            get {
                yield break;
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

        public object Value {
            get {
                return namedObject;
            }
        }

        #endregion

        public NamedFunctionInstance (object namedObject) {
            this.namedObject = namedObject;
        }

        #region ITermHeader implementation
        public string TermString (IEnumerable<IFunctionInstance> terms) {
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

        public bool CanConvert (TermType type) {
            return TypeSystem.CanConvert (this.Type, type);
        }
        #endregion

        public override string ToString () {
            return this.Name;
        }

        #region ITerm implementation
        public bool Equals (ITerm other) {
            return Object.Equals (this, other.Header);
        }
        #endregion

        #region IFunctionInstance implemention
        public object ConvertedValue (TermType target) {
            return this.Value;
        }
        #endregion

        public override int GetHashCode () {
            return this.namedObject.GetHashCode ();
        }

        #region IFunction implementation
        public IFunctionInstance CreateInstance (IEnumerable<IFunctionInstance> terms) {
            return this;
        }
        #endregion

        #region ITermHeader implementation
        ITerm ITermHeader.CreateInstance (IEnumerable<IFunctionInstance> terms) {
            return this.CreateInstance (terms);
        }
        #endregion


    }

}

