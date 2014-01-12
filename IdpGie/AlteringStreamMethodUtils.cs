using System;
using System.IO;

namespace IdpGie {
	public static class AlteringStreamMethodUtils {
		public static void Execute (this IAlteringStreamMethod asm, string filename) {
			using (Stream fs = File.Open (filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)) {
				asm.Execute (fs);
			}
		}
	}
}

