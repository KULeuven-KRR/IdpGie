using System;

namespace IdpGie.Abstract {
	public interface ICloneable<TResult> : ICloneable where TResult : class {
		new TResult Clone ();
	}
}

