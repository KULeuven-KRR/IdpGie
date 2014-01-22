using System;
using System.IO;

namespace IdpGie {
	public class AlterableContentChangeableStreamBase<TStream,TCommand> : ContentChangeableStreamBase<TStream>, IAlterableReloadableChangeableStream<TCommand> where TStream : Stream {
		public AlterableContentChangeableStreamBase (TStream stream) : base (stream) {
		}

		public virtual void Alter (TCommand command) {
		}

		public virtual void Reload () {
		}
	}
}

