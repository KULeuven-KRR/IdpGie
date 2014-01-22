using Gdk;
using System.Linq;
using System.Collections.Generic;
using System;

namespace IdpGie {
	public class HookKey : HookBase {
		private readonly string Key;

		public override EventType HookType {
			get {
				return EventType.KeyPress;
			}
		}

		public HookKey (Body body, string key) : base (body) {
			this.Key = key.ToLower ();
		}

		public HookKey (IEnumerable<IAtom> body, string key) : this (new Body (body), key) {
		}

		#region IHook implementation

		public override void Execute (DrawTheory theory, params object[] parameters) {
			if (parameters.Length > 0x00) {
				EventKey ek = parameters [0x00] as EventKey;
				if (ek != null && ek.Key.ToString ().ToLower ().Equals (this.Key)) {
					Console.WriteLine ("FIRE!");
					base.Execute (theory, parameters);
				} else {
					//Console.Error.WriteLine (ek.Key.ToString ());
				}
			}
		}

		#endregion

	}
}

