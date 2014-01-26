using System;
using System.Text.RegularExpressions;

namespace IdpGie {
	public static class RegexUtils {
		public const string IntegerRegex = @"[+-]?[0-9]+";
		public const string DoubleRegex = @"[+-]?[0-9]+(\.[0-9]*)?";

		public static string NameRegex (string name, string regex) {
			return string.Format ("(?<{0}>{1})", name, regex);
		}

		public static string Concat (params string[] regexes) {
			return string.Join ("", regexes);
		}

		public static string Or (params string[] regexes) {
			return string.Format ("({0})", string.Join ("|", regexes));
		}

		public static string Kleene (string regex) {
			return string.Format ("({0})*", regex);
		}

		public static Regex GetRegex (string regex) {
			return new Regex (regex, RegexOptions.Compiled);
		}
	}
}

