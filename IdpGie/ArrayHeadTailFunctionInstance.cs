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
using System.Collections;
using System.Collections.Generic;

namespace IdpGie.Logic {

    public class ArrayHeadTailFunctionInstance : IArrayFunctionInstance {

        private readonly IFunctionInstance term;
        private readonly IArrayFunctionInstance tail;

        #region ICollection implementation
        public int Count {
            get {
                return 0x01 + this.tail.Count;
            }
        }

        public bool IsReadOnly {
            get {
                return true;
            }
        }
        #endregion

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

        public object Value {
            get {
                return this;
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

        #region ITerm implementation
        public IEnumerable<IFunctionInstance> Terms {
            get {
                yield return this.Term;
                yield return this.Tail;
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

        #region ITerm implementation
        public bool Equals (ITerm other) {
            return Object.Equals (other.Header, ArrayFunction.Instance) && this.Terms.AllDual (other.Terms, (x,y) => x.Equals (y));
        }
        #endregion

        #region IFunctionInstance implementation
        public bool CanConvert (TermType type) {
            return TypeSystem.CanConvert (this.Type, type);
        }
        #endregion

        #region implemented abstract members of IdpGie.IdpVirtualFunctionInstance
        public object ConvertedValue (TermType target) {
            return this;
        }
        #endregion

        public override int GetHashCode () {
            return 0x122de704 ^ (this.term.GetHashCode () << 0x03) ^ (this.tail.GetHashCode () << 0x06);
        }

        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator () {
            return this.GetEnumerator ();
        }
        #endregion

        #region IEnumerable implementation
        public IEnumerator<IFunctionInstance> GetEnumerator () {
            yield return this.term;
            IArrayFunctionInstance afi = this.tail;
            while (afi is ArrayHeadTailFunctionInstance) {
                ArrayHeadTailFunctionInstance ahfi = (ArrayHeadTailFunctionInstance)afi;
                yield return ahfi.term;
                afi = ahfi.tail;
            }
        }
        #endregion

        #region ICollection implementation
        public void Add (IFunctionInstance item) {
            throw new InvalidOperationException ("Collection is readonly.");
        }

        public void Clear () {
            throw new InvalidOperationException ("Collection is readonly.");
        }

        public bool Contains (IFunctionInstance item) {
            return Object.Equals (this.term, item) || this.tail.Contains (item);
        }

        public void CopyTo (IFunctionInstance[] array, int arrayIndex) {
            IEnumerator<IFunctionInstance> enumerator = this.GetEnumerator ();
            int n = array.Length;
            for (int i = arrayIndex; i < n && enumerator.MoveNext(); i++) {
                array [i] = enumerator.Current;
            }
        }

        public bool Remove (IFunctionInstance item) {
            throw new InvalidOperationException ("Collection is readonly.");
        }
        #endregion

        #region IArrayFunctionInstance implementation
        public IEnumerable<T> ValueEnumerable<T> (TermType target) {
            yield return (T)this.term.ConvertedValue (target);
            IArrayFunctionInstance afi = this.tail;
            while (afi is ArrayHeadTailFunctionInstance) {
                ArrayHeadTailFunctionInstance ahfi = (ArrayHeadTailFunctionInstance)afi;
                yield return (T)ahfi.term.ConvertedValue (target);
                afi = ahfi.tail;
            }
        }
        #endregion

    }

}