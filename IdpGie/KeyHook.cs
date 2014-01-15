using Gdk;
using System.Linq;
using System.Collections.Generic;

namespace IdpGie {
	public class KeyHook : IHook {
		private readonly Keys Key;

		public EventType HookType {
			get {
				return EventType.KeyPress;
			}
		}

		public KeyHook (Keys key) {
			this.Key = key;
		}

		protected virtual void FilteredFire (DrawTheory theory, IList<ITerm> terms) {
		}

		#region IHook implementation

		public void Execute (DrawTheory theory, IList<ITerm> parameters) {
			NamedFunctionInstance term = parameters.FirstOrDefault () as NamedFunctionInstance;
			if (term != null && term.Name == Key.ToString ()) {
				this.FilteredFire (theory, parameters);
			}
		}

		#endregion

	}
}

