using System;
using System.IO;

namespace IdpGie {
	public class IdpiSession : IContentChangeableStream {
		public IdpiSession () {
		}

		#region IContentChangeableStream implementation

		public event EventHandler Changed;

		public Stream Stream {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		#endregion

	}
}

