using System;
using System.Collections.Generic;
using Gdk;

namespace IdpGie {
	[Mapper]
	public static class HookMapping {
		[HookMethod ("keydown", 1000.0d, TermType.Named)]
		public static IHook KeyDown (DrawTheory dt, IFunctionInstance key, IEnumerable<IAtom> body) {
			return new KeyHook (body, Key.A);
		}
	}
}