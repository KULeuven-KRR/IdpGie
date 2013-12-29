using System;
using System.Collections.Generic;

namespace IdpGie {
	public interface IHook {
		HookType HookType {
			get;
		}

		void Fire (IList<ITerm> parameters);
	}
}

