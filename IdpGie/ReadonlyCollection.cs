using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace IdpGie {
	public class ReadonlyCollection<T> : ICollection<T> {
		private readonly ICollection<T> collection;

		public ReadonlyCollection (ICollection<T> collection) {
			this.collection = collection;
		}

		#region ICollection implementation

		public void Add (T item) {
			throw new ReadOnlyException ();
		}

		public void Clear () {
			throw new ReadOnlyException ();
		}

		public bool Contains (T item) {
			return this.collection.Contains (item);
		}

		public void CopyTo (T[] array, int arrayIndex) {
			this.collection.CopyTo (array, arrayIndex);
		}

		public bool Remove (T item) {
			throw new ReadOnlyException ();
		}

		public int Count {
			get {
				return this.collection.Count;
			}
		}

		public bool IsReadOnly {
			get {
				return true;
			}
		}

		#endregion

		#region IEnumerable implementation

		public IEnumerator<T> GetEnumerator () {
			return this.collection.GetEnumerator ();
		}

		#endregion

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator () {
			return this.collection.GetEnumerator ();
		}

		#endregion

	}
}

