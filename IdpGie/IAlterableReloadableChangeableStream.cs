using System;

namespace IdpGie {
	public interface IAlterableReloadableChangeableStream<TCommand> : IAlterable<TCommand>, IReloadable, IChangeableStream {
	}
}

