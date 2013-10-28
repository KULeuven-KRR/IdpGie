//
//  VirtualFunctionInstance.cs
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

    public abstract class IdpdVirtualFunctionInstance : IFunction, IFunctionInstance {

        private double priority;

        #region IFunctionInstance implementation
        public virtual ITermHeader Header {
            get {
                return this;
            }
        }

        public bool HasInstance {
            get {
                return false;
            }
        }

        public virtual IFunctionInstance this [int index] {
            get {
                throw new IndexOutOfRangeException ();
            }
        }

        public abstract object Value {
            get;
        }
        #endregion

        #region IName implementation
        public string Name {
            get {
                return this.ToString ();
            }
        }
        #endregion

        #region ITermHeader implementation
        public int Arity {
            get {
                return 0x00;
            }
        }

        public Tuple<string,int> Signature {
            get {
                return new Tuple<string, int> (this.Name, this.Arity);
            }
        }
        #endregion

        #region IPriority implementation
        public double Priority {
            get {
                return this.priority;
            }
            protected set {
                this.priority = value;
            }
        }
        #endregion

        #region IFunctionInstance implementation
        public abstract TermType Type {
            get;
        }

        public IFunction Function {
            get {
                return this;
            }
        }
        #endregion

        #region IFunction implementation
        public virtual TermType OutputType {
            get {
                return this.Type;
            }
        }
        #endregion

        #region ITerm implementation
        public virtual IEnumerable<IFunctionInstance> Terms {
            get {
                yield break;
            }
        }
        #endregion

        protected IdpdVirtualFunctionInstance (double priority = 1.0d) {
            this.Priority = priority;
        }

        #region IFunction implementation
        public TermType InputType (int index) {
            return TermType.None;
        }

        public virtual void WidenInput (TermType[] types, int termOffset = 0x00, int inputOffset = 0x00) {
        }

        public virtual void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
        }

        public virtual void WidenInput (IEnumerable<IFunctionInstance> terms) {
        }

        public bool CanConvert (TermType type) {
            return TypeSystem.CanConvert (this.Type, type);
        }

        public abstract object ConvertedValue (TermType target);
        #endregion

        #region ITermHeader implementation
        public string TermString (List<IFunctionInstance> terms) {
            return this.ToString ();
        }
        #endregion

        #region ITerm implementation
        public virtual bool Equals (ITerm other) {
            return Object.Equals (this, other);
        }
        #endregion




    }
}

