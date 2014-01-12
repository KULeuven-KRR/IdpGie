using System;
using System.IO;

namespace IdpGie {
	public class Scanner : IDisposable {
		public readonly TextReader Reader;

		public Scanner (TextReader reader) {
			this.Reader = reader;
		}

		#region IDisposable implementation

		public string NextLine () {
			return Reader.ReadLine ();
		}

		public bool HasNextLine () {
			return Reader.Peek () != -0x01;
		}

		public void Dispose () {
			this.Reader.Close ();
		}

		#endregion

	}
}

