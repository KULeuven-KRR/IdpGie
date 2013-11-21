//
//  Variable.cs
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
using IdpGie.Utils;

namespace IdpGie.Logic {

	public class Variable : NameBase, IVariable {
		private static uint idDispatcher = 0x00;
		private readonly uint id;
		private object value;

		#region ITerm implementation

		public TermConcept Concept {
			get {
				return TermConcept.Variable;
			}
		}

		public TermConcept ContainingConcepts {
			get {
				return TermConcept.Variable;
			}
		}

		#endregion

		#region IFunction implementation

		public TermType OutputType {
			get {
				return TermType.All;
			}
		}

		public bool HasInstance {
			get {
				return false;
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

		public object Value {
			get {
				return this.value;
			}
			set {
				this.value = value;
			}
		}

		#endregion

		#region IPriority implementation

		public double Priority {
			get {
				return double.PositiveInfinity;
			}
		}

		#endregion

		#region IArity implementation

		public int Arity {
			get {
				return 0x00;
			}
		}

		#endregion

		#region ITermHeader implementation

		public Tuple<string, int> Signature {
			get {
				return new Tuple<string, int> (this.Name, this.Arity);
			}
		}

		#endregion

		#region ITerm implementation

		public IFunctionInstance this [int index] {
			get {
				throw new IndexOutOfRangeException ("A variable does not contain parameters.");
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

		internal Variable (string name) : base (name) {
			this.id = idDispatcher++;
		}

		#region ITerm implementation

		public bool Equals (ITerm other) {
			return Object.ReferenceEquals (this, other);
		}

		#endregion

		#region ITermHeader implementation

		public string TermString (IEnumerable<IFunctionInstance> terms) {
			return this.Name;
		}

		public ITerm CreateInstance (IEnumerable<IFunctionInstance> terms) {
			return this;
		}

		#endregion

		#region IFunctionInstance implementation

		public bool CanConvert (TermType target) {
			return true;
		}

		public object ConvertedValue (TermType target) {
			return this.Value;
		}

		#endregion

		#region IFunction implementation

		public TermType InputType (int index) {
			throw new IndexOutOfRangeException ();
		}

		public void WidenInput (TermType[] types, int termOffset, int inputOffset) {
		}

		public void WidenInput (TermType[] types, int termOffset, int inputOffset, int inputLength) {
		}

		public void WidenInput (IEnumerable<IFunctionInstance> terms) {
		}

		IFunctionInstance IFunction.CreateInstance (IEnumerable<IFunctionInstance> terms) {
			return this;
		}

		#endregion

		#region ITerm implementation

		public void Replace (IEnumerable<Tuple<IVariable, IFunctionInstance>> replacement) {
		}

		public void Replace (IDictionary<IVariable, IFunctionInstance> replacement) {
		}

		#endregion

		#region ITerm implementation

		public bool ContainsConcepts (TermConcept concept) {
			return (concept & this.ContainsConcepts) == concept;
		}

		public bool IsConcept (TermConcept concept) {
			return (concept & this.Concept) == concept;
		}

		#endregion

		public override string ToString () {
			return this.Name;
		}

		public override int GetHashCode () {
			return this.id.GetHashCode ();
		}

		public override bool Equals (object obj) {
			return Object.ReferenceEquals (this, obj);
		}
	}
}

