using System;
using Gtk;

namespace IdpGie {
	public abstract class OutputWindowDevice : OutputDevice {
		private TopWindow tw;

		protected OutputWindowDevice (DrawTheory theory) : base (theory) {
		}

		protected void CreateWindow () {
			tw = new TopWindow ();
		}

		protected void ShowWindow () {
			Application.Run ();
		}

		#region IDisposable implementation

		public override void Dispose () {
			if (tw != null) {
				tw.Dispose ();
			}
		}

		#endregion

		protected void OpenTab<T> (DrawTheory dt, T widget) where T : Widget, IMediaObject {
			this.tw.CreateTab<T> (dt, widget);
		}
	}
}

