using System;
using System.IO;

namespace IdpGie {
	public class FileDrawStreamProvider : IDrawStreamProvider {
		private readonly Stream internalStream;

		public FileDrawStreamProvider (Stream internalStream) {
			this.internalStream = internalStream;
		}

		#region IDrawStreamProvider implementation

		public event EventHandler Changed {
			add {
			}
			remove {
			}
		}

		public IAsyncResult BeginRead (byte[] buffer, int offset, int count, AsyncCallback callback, object state) {
			return this.internalStream.BeginRead (buffer, offset, count, callback, state);
		}

		public void Close () {
			this.internalStream.Close ();
		}

		public void CopyTo (Stream destination) {
			this.internalStream.CopyTo (destination);
		}

		public void CopyTo (Stream destination, int bufferSize) {
			this.internalStream.CopyTo (destination, bufferSize);
		}

		public int EndRead (IAsyncResult asyncResult) {
			return this.internalStream.EndRead (asyncResult);
		}

		public int Read (byte[] buffer, int offset, int count) {
			return this.internalStream.Read (buffer, offset, count);
		}

		public int ReadByte () {
			return this.internalStream.ReadByte ();
		}

		public long Seek (long offset, SeekOrigin origin) {
			return this.internalStream.Seek (offset, origin);
		}

		public bool CanRead {
			get {
				return this.internalStream.CanRead;
			}
		}

		public bool CanSeek {
			get {
				return this.internalStream.CanSeek;
			}
		}

		public bool CanTimeout {
			get {
				return this.internalStream.CanTimeout;
			}
		}

		public long Length {
			get {
				return this.internalStream.Length;
			}
		}

		public long Position {
			get {
				return this.internalStream.Position;
			}
			set {
				this.internalStream.Position = value;
			}
		}

		public int ReadTimeout {
			get {
				return this.internalStream.ReadTimeout;
			}
			set {
				this.internalStream.ReadTimeout = value;
			}
		}

		#endregion

		#region IDisposable implementation

		public void Dispose () {
			this.internalStream.Dispose ();
		}

		#endregion

	}
}

