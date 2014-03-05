//
//  HeadTail.cs
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

//TODO: make code less stack intensive by using do-while loops

namespace IdpGie.Utils.Logic {

    public sealed class HeadTail<T> : IList<T> {

        private readonly T head;
        private readonly IList<T> tail;

        public T Head {
            get {
                return this.head;
            }
        }

        public IList<T> Tail {
            get {
                return tail;
            }
        }

        #region ICollection implementation
        public int Count {
            get {
                int count = 0x01;
                if (this.tail != null) {
                    count += this.tail.Count;
                }
                return count;
            }
        }

        public bool IsReadOnly {
            get {
                return true;
            }
        }
        #endregion

        #region IList implementation
        public T this [int index] {
            get {
                if (index != 0x00) {
                    return this.tail [index - 0x01];
                } else {
                    return this.head;
                }
            }
            set {
                if (index > 0x00) {
                    this.tail [index - 0x01] = value;
                } else if (index == 0x00) {
                    throw new InvalidOperationException ("The specified part of the collection is read-only.");
                } else {
                    throw new IndexOutOfRangeException ("The index must be larger or equal to zero.");
                }
            }
        }
        #endregion

        private HeadTail (IEnumerator<T> values) {
            this.head = values.Current;
            if (values.MoveNext ()) {
                this.tail = new HeadTail<T> (values);
            }
        }

        public HeadTail (T head) : this(head,null) {
        }

        public HeadTail (T head, IList<T> tail) {
            this.head = head;
            this.tail = tail;
        }

        public HeadTail (IEnumerable<T> values) {
            if (values == null) {
                throw new ArgumentException ("The values must be effective.", "values");
            }
            IEnumerator<T> enumerator = values.GetEnumerator ();
            if (enumerator == null) {
                throw new ArgumentException ("Values produced a noneffective enumerator.", "values");
            }
            if (!enumerator.MoveNext ()) {
                throw new ArgumentException ("Values must contain at least one element.", "values");
            }
            this.head = enumerator.Current;
            if (enumerator.MoveNext ()) {
                this.tail = new HeadTail<T> (enumerator);
            }
        }

        #region ICollection implementation
        public void Add (T item) {
            if (this.tail == null) {
                throw new InvalidOperationException ("The specified part of the collection is read-only.");
            } else {
                this.tail.Add (item);
            }
        }

        public void Clear () {
            throw new InvalidOperationException ("At least a part of the collection is read-only and cannot be removed.");
        }

        public bool Contains (T item) {
            if (Object.Equals (this.head, item)) {
                return true;
            } else if (this.tail != null) {
                return this.tail.Contains (item);
            } else {
                return false;
            }
        }

        public void CopyTo (T[] array, int arrayIndex) {
            IEnumerator<T> enumerator = this.GetEnumerator ();
            for (int i = arrayIndex; enumerator.MoveNext() && i < array.Length; i++) {
                array [i] = enumerator.Current;
            }
        }

        public bool Remove (T item) {
            return (this.tail != null && this.tail.Remove (item));
        }
        #endregion

        #region IList implementation
        public int IndexOf (T item) {
            if (Object.Equals (this.head, item)) {
                return 0x00;
            } else if (this.tail != null) {
                int idx = this.tail.IndexOf (item);
                if (idx >= 0x00) {
                    return idx + 0x01;
                }
            }
            return -0x01;
        }

        public void Insert (int index, T item) {
            if (index > 0x00) {
                if (this.tail != null) {
                    this.tail.Insert (index - 0x01, item);
                } else {
                    throw new IndexOutOfRangeException ("The index must be smaller than the size of the collection.");
                }
            }
            if (index == 0x00) {
                throw new InvalidOperationException ("The specified part of the list is read-only.");
            } else {
                throw new IndexOutOfRangeException ("The index must be larger or equal to zero.");
            }
        }

        public void RemoveAt (int index) {
            if (index > 0x00) {
                if (this.tail != null) {
                    this.tail.RemoveAt (index - 0x01);
                } else {
                    throw new IndexOutOfRangeException ("The index must be smaller than the size of the collection.");
                }
            }
            if (index == 0x00) {
                throw new InvalidOperationException ("The specified part of the list is read-only.");
            } else {
                throw new IndexOutOfRangeException ("The index must be larger or equal to zero.");
            }
        }
        #endregion
        #region IEnumerable implementation
        IEnumerator IEnumerable.GetEnumerator () {
            return this.GetEnumerator ();
        }
        #endregion

        #region IEnumerable implementation
        public IEnumerator<T> GetEnumerator () {
            IList<T> current = this;
            do {
                HeadTail<T> ht = (HeadTail<T>)current;
                yield return ht.Head;
                current = ht.Tail;
            } while(current != null && current is HeadTail<T>);
            if (current != null) {
                foreach (T t in current) {
                    yield return t;
                }
            }
        }
        #endregion

        public override string ToString () {
            return string.Format ("[ {0} ]", string.Join (", ", (IEnumerable<T>)this));
        }

        public override bool Equals (object obj) {
            if (base.Equals (obj)) {
                return true;
            }
            if (obj != null && obj is HeadTail<T>) {
                HeadTail<T> htobj = (HeadTail<T>)obj;
                if (!Object.Equals (this.head, htobj.head)) {
                    return false;
                }
                if (this.tail != null) {
                    return this.tail.Equals (htobj.tail);
                } else {
                    return (htobj.tail == null);
                }
            }
            return false;
        }

        public override int GetHashCode () {
            int hash = 0x03;
            if (this.head != null) {
                hash += 0x07 * this.head.GetHashCode ();
            }
            if (this.tail != null) {
                hash += 0x0b * this.tail.GetHashCode ();
            }
            return hash;
        }

        public static HeadTail<T> FromIEnumerable (params T[] values) {
            return FromIEnumerable (values);
        }

        public static HeadTail<T> FromIEnumerable (IEnumerable<T> values) {
            if (values == null) {
                return null;
            }
            IEnumerator<T> enumerator = values.GetEnumerator ();
            if (enumerator == null || !enumerator.MoveNext ()) {
                return null;
            }
            return new HeadTail<T> (enumerator);
        }

        public static HeadTail<T> operator & (T head, HeadTail<T> tail) {
            return new HeadTail<T> (head, tail);
        }


    }

}