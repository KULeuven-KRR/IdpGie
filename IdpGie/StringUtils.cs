using System;
using System.Collections.Generic;

namespace IdpGie.Utils {
	public static class StringUtils {
		public static string NonEmptyOrNull (string x) {
			if (x == string.Empty) {
				return null;
			} else {
				return x;
			}
		}

		public static string EffectiveOrDefault (string x, string dflt = "") {
			if (x == null) {
				return dflt;
			} else {
				return x;
			}
		}

		public static string EffectiveOrDefault (ref string target, string x) {
			EffectiveOrDefault (ref target, x, target);
		}

		public static string EffectiveOrDefault (ref string target, string x, string dflt) {
			if (x != null) {
				target = x;
			} else {
				target = dflt;
			}
		}

		public static string ReplaceDollar (string source, params Tuple<string,string>[] tuples) {
			return ReplaceDollar (source, (IEnumerable<Tuple<string,string>>)tuples);
		}

		public static string ReplaceDollar (string source, IEnumerable<Tuple<string,string>> tuples) {
			string copy = source;
			foreach (Tuple<string,string> tuple in tuples) {
				copy = copy.Replace (string.Format (@"$({0})", tuple.Item1), tuple.Item2);
			}
			return copy;
		}
	}
}

