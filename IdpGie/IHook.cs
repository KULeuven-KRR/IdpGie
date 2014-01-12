using System;
using System.Collections.Generic;
using Gdk;

namespace IdpGie {
	public interface IHook {
		EventType HookType {
			get;
		}

		void Fire (IList<ITerm> parameters);
	}
}

