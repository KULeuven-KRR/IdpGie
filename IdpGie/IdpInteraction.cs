using System;
using System.Diagnostics;

namespace IdpGie {
	public class IdpInteraction {
		public const string IDP_EXECUTABLE = @"/home/kommusoft/idp/bin/idp";

		public IdpInteraction () {
		}

		public void Runfile (string file) {
			Process p = Process.Start (IDP_EXECUTABLE, file);
			p.WaitForExit ();
		}
	}
}