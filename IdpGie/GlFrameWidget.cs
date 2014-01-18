using System;
using Gdk;
using System.Collections.Generic;
using GLSharp;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace IdpGie {
	public class GLFrameWidget : GLWidget, IDrawTheorySensitive, IMediaObject {
		public DrawTheory Theory {
			get;
			set;
		}

		public bool GLinit = false;

		public GLFrameWidget (DrawTheory theory) : base (GraphicsMode.Default, 0x03, 0x00, GraphicsContextFlags.Debug) {
			this.Theory = theory;
			this.Theory.Changed += HandleChanged;
			this.CanFocus = true;
			this.Activate ();
			foreach (EventType type in theory.GetHookTypes ()) {
				this.AddEvents ((int)type);
			}
			this.SingleBuffer = true;
			this.DoubleBuffered = true;
		}

		void HandleChanged (object sender, EventArgs e) {
		}
		//[GLib.ConnectBefore]
		protected override bool OnKeyPressEvent (EventKey evnt) {
			this.Theory.FireHook (EventType.KeyPress, new List<ITerm> ());
			return base.OnKeyPressEvent (evnt);
		}

		public void Seek (double time) {
			this.Theory.Time = time;
		}

		protected override void OnRenderFrame () {
			GL.ClearColor (0.0f, 0.3647f, 0.5882f, 0.0f);
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

