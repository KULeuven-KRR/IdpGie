using System;
using IdpGie.Core;
using IdpGie.Logic;

namespace IdpGie.Mappers {
	[Mapper]
	public static class AlteringMapping {
		[AlterMethodAttribute ("execute", TermType.String)]
		public static void Execute (DrawTheory dt, string command) {
			dt.Source.Alter (command);
		}

		[AlterMethodAttribute ("reload")]
		public static void Execute (DrawTheory dt) {
			dt.Source.Reload ();
		}
	}
}
