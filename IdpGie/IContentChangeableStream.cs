using System;
using System.IO;

namespace IdpGie {
	public interface IChangeableStream {
		Stream Stream {
			get;
		}

		event EventHandler Changed;
	}
}