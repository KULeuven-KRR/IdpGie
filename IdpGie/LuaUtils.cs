using System;

namespace IdpGie {
	public class LuaUtils {
		public static string Skolemize (string input) {
			return input.Replace ("$dtime", NamedFunctionDtime.Instance.Value.ToString ()).Replace ("$dtime", NamedFunctionDtime.Instance.Value.ToString ());
		}
	}
}

