using System;
using System.Collections.Generic;
using Gdk;

namespace IdpGie {
	public abstract class HookBase : IHook {
		private readonly Body body;

		#region IHook implementation

		public abstract EventType HookType {
			get;
		}

		#endregion

		public Body Body {
			get {
				return this.body;
			}
		}

		protected HookBase (Body body) {
			this.body = body;
		}

		protected HookBase (IEnumerable<IAtom> body) : this (new Body (body)) {
		}

		public virtual void FilteredExecute (DrawTheory theory) {
			this.body.Execute (theory);
		}

		#region IHook implementation

		public virtual void Execute (DrawTheory theory, params object[] parameters) {
			this.FilteredExecute (theory);
		}

		#endregion

	}
}

