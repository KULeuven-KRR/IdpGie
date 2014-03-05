using System;
using IdpGie.Abstract;

namespace IdpGie.Interaction {
	public interface IAlterableReloadableChangeableStream<TCommand> : IAlterable<TCommand>, IReloadable, IChangeableStream {
	}
}

