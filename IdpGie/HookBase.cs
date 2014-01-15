using System;
using System.Collections.Generic;
using Gdk;

namespace IdpGie {
	public class HookBase : IHook {
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

		public HookBase (Body body) {
			this.body = body;
		}

		#region IHook implementation

		public void Execute (DrawTheory theory, IList<ITerm> parameters) {
			this.body.Execute (theory);
		}

		#endregion

	}
}

