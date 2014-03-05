using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IdpGie.Core;
using IdpGie.Utils;

namespace IdpGie.Logic {
	public class TypedClauseMethodPredicate : TypedMethodPredicate {
		public TypedClauseMethodPredicate (string name, IList<TermType> termTypes, MethodInfo method, double priority = 1.0d) : base (name, termTypes, method, priority) {
		}

		public override object ExecuteResult (DrawTheory theory, IEnumerable<IFunctionInstance> arguments, IEnumerable<IAtom> body) {
			object[] val = EnumerableUtils.FirstsLast (EnumerableUtils.HeadTail (theory, TypeSystem.GetArguments (arguments, this.TermTypes, this.Method.GetParameters ().Skip (0x01).SkipLast (0x01).Select (x => x.ParameterType))), body).ToArray ();
			try {
				return this.Method.Invoke (null, val);
			} catch (Exception e) {
				Console.Error.WriteLine ("Could not execute the {0} atom.", this.TermString (arguments));
				Console.Error.WriteLine (string.Join (" ; ", val.Select (x => x.GetType ())));
				Console.Error.WriteLine (e);
				return null;
			}
		}
	}
}

