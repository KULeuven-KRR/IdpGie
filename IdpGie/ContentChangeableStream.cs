using System;
using System.IO;

namespace IdpGie {
	public class ContentChangeableStream : IContentChangeableStream {
		private Stream stream;

		private event EventHandler changed;

		public Stream Stream {
			get {
				return this.stream;
			}
			set {
				if (value != null && value != this.stream) {
					this.stream = value;
					this.trigger_changed ();
				}
			}
		}

		public event EventHandler Changed {
			add {
				this.changed += value;
			}
			remove {
				this.changed -= value;
			}
		}

		public ContentChangeableStream (Stream stream) {
			this.stream = stream;
		}

		private void trigger_changed () {
			EventArgs e = new EventArgs ();
			this.OnChanged (e);
			if (this.changed != null) {
				this.changed (this, e);
			}
		}

		protected virtual void OnChanged (EventArgs e) {
		}
	}
}