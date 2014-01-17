using System;
using Cairo;
using Gdk;
using System.Collections.Generic;
using GLSharp;
using OpenTK.Graphics.ES20;

namespace IdpGie {
	public class GLFrameWidget : GLWidget, IDrawTheorySensitive, IMediaObject {
		public DrawTheory Theory {
			get;
			set;
		}

		public GLFrameWidget (DrawTheory theory) {
			this.Theory = theory;
			this.Theory.Changed += HandleChanged;
			this.CanFocus = true;
			this.Activate ();
			this.Name = "glwidget1";
			this.SingleBuffer = false;
			this.ColorBPP = 0;
			this.AccumulatorBPP = 0;
			this.DepthBPP = 0;
			this.StencilBPP = 0;
			this.Samples = 0;
			this.Stereo = false;
			this.GlVersionMajor = 0;
			this.GlVersionMinor = 0;
			foreach (EventType type in theory.GetHookTypes ()) {
				this.AddEvents ((int)type);
			}
		}

		void HandleChanged (object sender, EventArgs e) {
		}

		[GLib.ConnectBefore]
		protected override bool OnKeyPressEvent (EventKey evnt) {
			this.Theory.FireHook (EventType.KeyPress, new List<ITerm> ());
			return base.OnKeyPressEvent (evnt);
		}

		protected override void OnSizeRequested (ref Gtk.Requisition requisition) {
			requisition.Height = 34;
			requisition.Width = 100;
		}

		public void Seek (double time) {
			this.Theory.Time = time;
		}

		protected override void OnRenderFrame () {
			GL.Clear (ClearBufferMask.ColorBufferBit);
			base.OnRenderFrame ();
		}

		public event EventHandler OnPlay;
		public event EventHandler OnPause;
		public event EventHandler OnRewind;
		public event EventHandler OnForward;
		public event EventHandler OnPreviousChapter;
		public event EventHandler OnNextChapter;
		public event EventHandler OnShuffle;
		public event EventHandler OnRepeat;
		public event EventHandler OnEject;
		public event EventHandler OnRecord;
		public event EventHandler OnStop;
		public event EventHandler OnSeek;

		public void Play () {
			throw new NotImplementedException ();
		}

		public void Pause () {
			throw new NotImplementedException ();
		}

		public void Rewind () {
			throw new NotImplementedException ();
		}

		public void Forward () {
			throw new NotImplementedException ();
		}

		public void PreviousChapter () {
			throw new NotImplementedException ();
		}

		public void NextChapter () {
			throw new NotImplementedException ();
		}

		public void Shuffle () {
			throw new NotImplementedException ();
		}

		public void Repeat () {
			throw new NotImplementedException ();
		}

		public void Eject () {
			throw new NotImplementedException ();
		}

		public void Record () {
			throw new NotImplementedException ();
		}

		public void Stop () {
			throw new NotImplementedException ();
		}

		public MediaButtons SupportedMedia {
			get {
				throw new NotImplementedException ();
			}
		}

		public double MinTime {
			get {
				return this.Theory.MinTime;
			}
		}

		public double MaxTime {
			get {
				return this.Theory.MaxTime;
			}
		}

		public double TimeSpan {
			get {
				return this.Theory.TimeSpan;
			}
		}

		public IEnumerable<double> Chapters {
			get {
				yield return this.MinTime;
				yield break;
			}
		}
	}
}

