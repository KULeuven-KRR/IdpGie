using System;

namespace IdpGie {
	[Mapper]
	public static class HookMapping {
		[HookMethod ("keydown", 1000.0d, TermType.Named)]
		public static IHook KeyDown (DrawTheory dt, IFunctionInstance key) {
			return null;
		}
	}
}