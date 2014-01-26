using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace IdpGie {
	public class RegexDevelopment {
		public static readonly RegexDevelopment IntegerRegex = @"[+-]?[0-9]+";
		public static readonly RegexDevelopment DoubleRegex = @"[+-]?[0-9]+(\.[0-9]*)?";
		private string regex = string.Empty;

		public string Regex {
			get {
				return this.regex;
			}
		}

		public RegexDevelopment (string regex) {
			this.regex = regex;
		}

		public RegexDevelopment (RegexDevelopment rd) {
			this.regex = rd.regex;
		}

		public static string Name (string name) {
			this.regex = string.Format ("(?<{0}>{1})", name, this.regex);
		}

		public static void Concat (params RegexDevelopment[] regexes) {
			this.regex += string.Join ("", regexes);
		}

		public void Or (params RegexDevelopment[] regexes) {
			this.regex = string.Format ("({0}|{1})", this.regex, string.Join ("|", regexes.Select (x => x.Regex)));
		}

		public void Kleene () {
			this.regex = string.Format ("({0})*", this.regex);
		}

		public Regex GetRegex () {
			return new Regex (this.regex, RegexOptions.Compiled);
		}
	}
}

