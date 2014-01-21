using System;

namespace IdpGie {
	public interface IAlterableContentChangeableStream<TCommand> : IAlterable<TCommand>, IContentChangeableStream {
	}
}

