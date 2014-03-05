using System;
using System.IO;

namespace IdpGie.Interaction {
	public class ContentChangeableStreamBase<T> : IChangeableStream where T : Stream {
		private T stream;

		private event EventHandler changed;

		Stream IChangeableStream.Stream {
			get {
				return this.stream;
			}
		}

		public T Stream {
			get {
				return this.stream;
			}
			protected set {
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

		public ContentChangeableStreamBase (T stream) {
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