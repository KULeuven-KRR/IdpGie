//
//  LazyDictionary.cs
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
using System.Collections;
using Gdk;

namespace IdpGie.Utils {

	public class LazyDictionary<TKey,TValue> : IDictionary<TKey,TValue> {
		private readonly Dictionary<TKey,TValue> innerDictionary = new Dictionary<TKey,TValue> ();
		private IEnumerator<Tuple<TKey,TValue>> generator;

		public LazyDictionary (IEnumerable<Tuple<TKey,TValue>> generator) {
			this.generator = generator.GetEnumerator ();
		}

		private bool YieldUntilKey (object key, out TValue value) {
			value = default(TValue);
			if (this.generator != null) {
				Tuple<TKey,TValue> current;
				while (generator.MoveNext ()) {
					current = generator.Current;
					this.innerDictionary.Add (current.Item1, current.Item2);
					if (Object.Equals (current.Item1, key)) {
						value = current.Item2;
						return true;
					}
				}
			}
			return false;
		}

		private bool YieldAll () {
			if (this.generator != null) {
				Tuple<TKey,TValue> current;
				while (generator.MoveNext ()) {
					current = generator.Current;
					this.innerDictionary.Add (current.Item1, current.Item2);
				}
				this.generator = null;
			}
		}

		#region IDictionary implementation

		public void Add (TKey key, TValue value) {
			this.innerDictionary.Add (key, value);
		}

		public bool ContainsKey (TKey key) {
			TValue val;
			return this.innerDictionary.ContainsKey (key) || this.YieldUntilKey (key, out val);
		}

		public bool Remove (TKey key) {
			throw new NotImplementedException ();
		}

		public bool TryGetValue (TKey key, out TValue value) {
			return this.innerDictionary.TryGetValue (key, out value) || this.YieldUntilKey (key, out value);
		}

		public TValue this [TKey index] {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public ICollection<TKey> Keys {
			get {
				throw new NotImplementedException ();
			}
		}

		public ICollection<TValue> Values {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

		#region ICollection implementation

		public void Add (KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException ();
		}

		public void Clear () {
			this.generator = null;
			this.innerDictionary.Clear ();
		}

		public bool Contains (KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException ();
		}

		public void CopyTo (KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
			throw new NotImplementedException ();
		}

		public bool Remove (KeyValuePair<TKey, TValue> item) {
			throw new NotImplementedException ();
		}

		public int Count {
			get {
				this.YieldAll ();
				return this.innerDictionary.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return false;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator () {
			foreach (KeyValuePair<TKey,TValue> pair in this.innerDictionary) {
				yield return pair;
			}
			while (this.generator != null && this.generator.MoveNext ()) {
				Tuple<TKey,TValue> current = this.generator.Current;
				this.innerDictionary.Add (current.Item1, current.Item2);
				yield return current;
			}
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator () {
			return this.GetEnumerator ();
		}

		#endregion

	}
}

