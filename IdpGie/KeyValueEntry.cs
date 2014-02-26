using System;

namespace IdpGie
{
	[FunctionStructure("kv",TermType.KeyValue)]
	public struct KeyValueEntry {

		private string key;
		private string value;

		public string Key {
			get {
				return this.key;
			}
			set {
				this.key = value;
			}
		}

		public string Value {
			get {
				return this.value;
			}
			set {
				this.value = value;
			}
		}

		[FunctionStructureConstructor(TermType.String,TermType.String)]
		public KeyValueEntry (string key, string value) {
			this.key = key;
			this.value = value;
		}

	}

}