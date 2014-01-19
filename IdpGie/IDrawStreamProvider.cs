using System;
using Gtk;
using System.IO;
using System.Runtime.InteropServices;

namespace IdpGie {
	public interface IDrawStreamProvider : IDisposable {
		event EventHandler Changed;

		bool CanRead {
			get;
		}

		bool CanSeek {
			get;
		}

		[ComVisible (false)]
		bool CanTimeout {
			get;
		}

		long Length {
			get;
		}

		long Position {
			get;
			set;
		}

		[ComVisible (false)]
		int ReadTimeout {
			get;
			set;
		}

		IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback callback, object state);

		void Close ();

		void CopyTo (Stream destination);

		void CopyTo (Stream destination, int bufferSize);

		int EndRead (IAsyncResult asyncResult);

		int Read (byte[] buffer, int offset, int count);

		int ReadByte ();

		long Seek (long offset, SeekOrigin origin);
	}
}

