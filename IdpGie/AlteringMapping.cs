using System;

namespace IdpGie {
	public static class AlteringMapping {
		public static void Execute (DrawTheory dt, string command) {
			dt.Source.Alter (command);
		}
	}
}

