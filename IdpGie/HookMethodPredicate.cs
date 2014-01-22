using System;
using System.Collections.Generic;
using System.Reflection;

namespace IdpGie {
	public class HookMethodPredicate : TypedClauseMethodPredicate {
		public HookMethodPredicate (string name, IList<TermType> termTypes, MethodInfo method, double priority = 1.0d) : base (name, termTypes, method, priority) {
		}

		public override void Execute (DrawTheory theory, IEnumerable<IFunctionInstance> arguments, IEnumerable<IAtom> body) {
			IHook hook = this.ExecuteResult (theory, arguments, body) as IHook;
			Console.WriteLine ("PRIOR HOOK " + string.Join (",", body));
			theory.AddHook (hook);
		}
	}
}

