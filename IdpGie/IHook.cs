using System;
using System.Collections.Generic;
using Gdk;
using IdpGie.Core;

namespace IdpGie.Logic {
	public interface IHook {
		EventType HookType {
			get;
		}

		void Execute (DrawTheory dt, params object[] parameters);
	}
}

