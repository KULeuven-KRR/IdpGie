using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace IdpGie {
	public class TypedClauseMethodPredicate : TypedMethodPredicate {
		public TypedClauseMethodPredicate (string name, IList<TermType> termTypes, MethodInfo method, double priority = 1.0d) : base (name, termTypes, method, priority) {
		}

		public override void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments, IEnumerable<IAtom> body) {
			Console.WriteLine ("whee");
			object[] val = EnumerableUtils.HeadTail (theory, TypeSystem.GetArguments (arguments, this.TermTypes, this.Method.GetParameters ().Skip (0x01).Select (x => x.ParameterType))).ToArray ();
			try {
				this.Method.Invoke (null, val);
				base.Execute (theory, arguments);
			} catch (Exception) {
				Console.WriteLine ("Could not execute the {0} atom.", this.TermString (arguments));
				//Console.WriteLine (e);
			}
		}
	}
}

