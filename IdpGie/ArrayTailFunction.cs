//
//  ArrayTailFunction.cs
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

	public sealed class ArrayTailFunction : Function, IArrayFunctionInstance {
		public static readonly ArrayTailFunction Instance = new ArrayTailFunction ();

		#region ICollection implementation

		public int Count {
			get {
				return 0x00;
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
				throw new IndexOutOfRangeException ();
			}
		}

		public ITermHeader Header {
			get {
				return this;
			}
		}

		public object Value {
			get {
				return this;
			}
		}

		#endregion

		#region IFunctionInstance implementation

		public TermType Type {
			get {
				return TermType.All;
			}
		}

		public IFunction Function {
			get {
				return this;
			}
		}

		#endregion

		#region ITerm implementation

		public IEnumerable<IFunctionInstance> Terms {
			get {
				yield break;
			}
		}

		#endregion

		private ArrayTailFunction () : base ("[]", 0x00) {
		}

		public override string TermString (IEnumerable<IFunctionInstance> terms) {
			return this.ToString ();
		}

		public override string ToString () {
			return "[]";
		}

		#region ITerm implementation

		public bool Equals (ITerm other) {
			return Object.Equals (this, other);
		}

		#endregion

		#region IFunctionInstance implementation

		public bool CanConvert (TermType type) {
			return TypeSystem.CanConvert (this.Type, type);
		}

		public object ConvertedValue (TermType target) {
			return this.Value;
		}

		#endregion

		public override int GetHashCode () {
			return 0x238ff745;
		}

		#region IEnumerable implementation

		IEnumerator IEnumerable.GetEnumerator () {
			yield break;
		}

		#endregion

		#region IEnumerable<> implementation

		public IEnumerator<IFunctionInstance> GetEnumerator () {
			yield break;
		}

		#endregion

		#region ICollection implementation

		public void Add (IFunctionInstance item) {
		}

		public void Clear () {
			throw new InvalidOperationException ("Readonly collection.");
		}

		public bool Contains (IFunctionInstance item) {
			return false;
		}

		public void CopyTo (IFunctionInstance[] array, int arrayIndex) {
		}

		public bool Remove (IFunctionInstance item) {
			throw new InvalidOperationException ("Readonly collection.");
		}

		#endregion

		#region IArrayFunctionInstance implementation

		public IEnumerable<T> ValueEnumerable<T> (TermType target) {
			yield break;
		}

		#endregion

		public void Replace (IEnumerable<Tuple<IVariable, IFunctionInstance>> replacement) {
		}

		public void Replace (IDictionary<IVariable, IFunctionInstance> replacement) {
		}
	}
}

