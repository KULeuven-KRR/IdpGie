using System;
using System.IO;

namespace IdpGie {
	public interface IContentChangeableStream {
		Stream Stream {
			get;
			set;
		}

		event EventHandler Changed;
	}
}

