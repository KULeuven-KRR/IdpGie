using System;
using Gtk;
using OpenTK.Graphics;
using IdpGie.Core;

namespace IdpGie.OutputDevices {
	public abstract class OutputWindowDevice : OutputDevice {
		private TopWindow tw;

		protected OutputWindowDevice (DrawTheory theory) : base (theory) {
		}

		protected void CreateWindow () {
			string[] args = new string[0x00];
			Application.Init ("idpgie", ref args);
			GraphicsContext.ShareContexts = false;
			GraphicsContext.DirectRendering = true;
			Gdk.Threads.Init ();
			tw = new TopWindow ();
		}

		protected void ShowWindow () {
			this.tw.Show ();
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

