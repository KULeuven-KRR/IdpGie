using System;

namespace IdpGie {
	public interface ICloneable<TResult> : ICloneable where TResult : class {
		new TResult Clone ();
	}
}

