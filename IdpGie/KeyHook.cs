using Gdk;
using System.Linq;
using System.Collections.Generic;

namespace IdpGie {
	public class KeyHook : HookBase {
		private readonly Key Key;

		public override EventType HookType {
			get {
				return EventType.KeyPress;
			}
		}

		public KeyHook (Body body, Key key) : base (body) {
			this.Key = key;
		}

		public KeyHook (IEnumerable<IAtom> body, Key key) : this (new Body (body), key) {
		}

		protected virtual void FilteredFire (DrawTheory theory, IList<ITerm> terms) {
			base.Execute (theory, terms);
		}

		#region IHook implementation

		public override void Execute (DrawTheory theory, IList<ITerm> parameters) {
			this.FilteredFire (theory, parameters);
		}

		#endregion

	}
}

