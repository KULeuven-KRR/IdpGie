using System;
using System.Collections.Generic;

namespace IdpGie {
	public interface IHook {
		void Fire (IList<ITerm> parameters);
	}
}

