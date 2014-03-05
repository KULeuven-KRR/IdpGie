using System;
using System.Collections.Generic;
using Gdk;
using IdpGie.Core;
using IdpGie.Logic;

namespace IdpGie.Mappers {
	[Mapper]
	public static class HookMapping {
		[HookMethod ("keydown", 1000.0d, TermType.String)]
		public static IHook KeyDown (DrawTheory dt, string key, IEnumerable<IAtom> body) {
			return new HookKey (body, key);
		}

		[HookMethod ("mousedownregion", 1000.0d, TermType.Float, TermType.Float, TermType.Float, TermType.Float)]
		public static IHook MouseDownRegion (DrawTheory dt, string key, IEnumerable<IAtom> body) {
			return new HookKey (body, key);
		}
	}
}