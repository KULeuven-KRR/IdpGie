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
			if (x == null) {
				return string.Empty;
			} else {
				return x;
			}
		}
	}
}

