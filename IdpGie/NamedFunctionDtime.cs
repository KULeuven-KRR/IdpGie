using System;
using System.Collections.Generic;
using IdpGie.UserInterface;

namespace IdpGie.Logic {
	public class NamedFunctionDtime : IFunction, IFunctionInstance {
		public static readonly NamedFunctionDtime Instance = new NamedFunctionDtime ();
		private double time = 0.0d;

		#region IName implementation

		public string Name {
			get {
				return "dtime";
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
				return TermType.Float;
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
				return this.time;
			}
			set {
				if (value is int) {
					this.time = (int)value;
				}
			}
		}

		#endregion

		private NamedFunctionDtime () {
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
			return this.Name.GetHashCode ();
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

		public void SetValue (BlueprintMediabar sender, double value) {
			this.time = value;
		}

		public ITerm CreateInstance (params IFunctionInstance[] terms) {
			return this.CreateInstance ((IEnumerable<IFunctionInstance>)terms);
		}
	}
}

