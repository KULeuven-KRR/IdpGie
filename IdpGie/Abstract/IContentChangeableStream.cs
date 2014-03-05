using System;
using System.IO;

namespace IdpGie.Abstract {
	public interface IChangeableStream {
		Stream Stream {
			get;
		}

		event EventHandler Changed;
	}
}