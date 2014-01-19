using System;

namespace IdpGie.Utils {
	public static class StringUtils {
		public static string NonEmptyOrNull (string x) {
			if (x == string.Empty) {
				return null;
			} else {
				return x;
			}
		}

		public static string AlwaysEffective (string x) {
			return EffectiveOrDefault (x);
		}

		public static string EffectiveOrDefault (string x, string dflt = "") {
			if (x == null) {
				return dflt;
			} else {
				return x;
			}
		}
	}
}

