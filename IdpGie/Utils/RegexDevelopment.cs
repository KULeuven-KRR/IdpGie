using System;
using System.Text.RegularExpressions;
using System.Linq;

namespace IdpGie.Utils {
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

		public void Name (string name) {
			this.regex = string.Format ("(?<{0}>{1})", name, this.regex);
		}

		public void Concat (RegexDevelopment regex) {
			this.regex += regex.Regex;
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

		public static implicit operator RegexDevelopment (string regex) {
			return new RegexDevelopment (regex);
		}

		public static implicit operator Regex (RegexDevelopment regex) {
			return new Regex (regex.Regex, RegexOptions.Compiled);
		}

		public static RegexDevelopment operator | (RegexDevelopment rd1, RegexDevelopment rd2) {
			return new RegexDevelopment (string.Format ("({0}|{1})", rd1.Regex, rd2.Regex));
		}

		public static RegexDevelopment operator + (RegexDevelopment rd1, RegexDevelopment rd2) {
			return new RegexDevelopment (string.Format ("{0}{1}", rd1.Regex, rd2.Regex));
		}

		public static RegexDevelopment operator / (RegexDevelopment rd, string name) {
			return new RegexDevelopment (string.Format ("(?<{0}>{1})", name, rd.regex));
		}

		public static RegexDevelopment operator ~ (RegexDevelopment rd) {
			return new RegexDevelopment (string.Format ("({0})?", rd.Regex));
		}

		public static RegexDevelopment operator ! (RegexDevelopment rd) {
			return new RegexDevelopment (string.Format ("({0})*", rd.Regex));
		}
	}
}

