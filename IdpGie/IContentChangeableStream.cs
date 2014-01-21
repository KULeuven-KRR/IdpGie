using System;
using System.IO;

namespace IdpGie {
	public interface IContentChangeableStream {
		Stream Stream {
			get;
		}

		event EventHandler Changed;
	}
}

