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

		#region IHook implementation

		public virtual void Execute (DrawTheory theory, IList<ITerm> parameters) {
			this.body.Execute (theory);
		}

		#endregion

	}
}

