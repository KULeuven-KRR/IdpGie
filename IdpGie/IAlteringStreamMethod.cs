using System;
using System.IO;

namespace IdpGie {
	public interface IAlteringStreamMethod {
		void Execute (Stream stream);
	}
}

