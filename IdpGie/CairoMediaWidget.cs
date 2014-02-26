//
//  CairoWidget.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using Gtk;
using Cairo;

namespace IdpGie {
	public abstract class CairoMediaWidget : DrawingArea, IMediaObject {
		protected event EventHandler _OnPlay, _OnPause, _OnRewind, _OnForward, _OnPreviousChapter, _OnNextChapter, _OnShuffle, _OnRepeat, _OnEject, _OnRecord, _OnStop, _OnSeek;

		#region IMediaObject implementation

		public virtual event EventHandler OnPlay {
			add {
				this._OnPlay += value;
			}
			remove {
				this._OnPlay -= value;
			}
		}

		public virtual event EventHandler OnPause {
			add {
				this._OnPause += value;
			}
			remove {
				this._OnPause -= value;
			}
		}

		public virtual event EventHandler OnRewind {
			add {
				this._OnRewind += value;
			}
			remove {
				this._OnRewind -= value;
			}
		}

		public virtual event EventHandler OnForward {
			add {
				this._OnForward += value;
			}
			remove {
				this._OnForward -= value;
			}
		}

		public virtual event EventHandler OnPreviousChapter {
			add {
				this._OnPreviousChapter += value;
			}
			remove {
				this._OnPreviousChapter -= value;
			}
		}

		public virtual event EventHandler OnNextChapter {
			add {
				this._OnNextChapter += value;
			}
			remove {
				this._OnNextChapter -= value;
			}
		}

		public virtual event EventHandler OnShuffle {
			add {
				this._OnShuffle += value;
			}
			remove {
				this._OnShuffle -= value;
			}
		}

		public virtual event EventHandler OnRepeat {
			add {
				this._OnRepeat += value;
			}
			remove {
				this._OnRepeat -= value;
			}
		}

		public virtual event EventHandler OnEject {
			add {
				this._OnEject += value;
			}
			remove {
				this._OnEject -= value;
			}
		}

		public virtual event EventHandler OnRecord {
			add {
				this._OnRecord += value;
			}
			remove {
				this._OnRecord -= value;
			}
		}

		public virtual event EventHandler OnStop {
			add {
				this._OnStop += value;
			}
			remove {
				this._OnStop -= value;
			}
		}

		public virtual event EventHandler OnSeek {
			add {
				this._OnSeek += value;
			}
			remove {
				this._OnSeek -= value;
			}
		}

		public virtual MediaButtons SupportedMedia {
			get {
				return MediaButtons.None;
			}
		}

		public virtual double MinTime {
			get {
				return 0.0d;
			}
		}

		public virtual double MaxTime {
			get {
				return 0.0d;
			}
		}

		public virtual double TimeSpan {
			get {
				return this.MaxTime - this.MinTime;
			}
		}

		public virtual IEnumerable<double> Chapters {
			get {
				yield return this.MinTime;
				yield break;
			}
		}

		#endregion

		protected virtual void PaintWidget (Context ctx, int w, int h) {
		}

		protected override bool OnExposeEvent (Gdk.EventExpose ev) {
			base.OnExposeEvent (ev);
			// Insert drawing code here.
			Context ctx = Gdk.CairoHelper.Create (this.GdkWindow);
			ctx.FillRule = FillRule.EvenOdd;
			int w, h;
			this.GdkWindow.GetSize (out w, out h);
			this.PaintWidget (ctx, w, h);
			((IDisposable)ctx.Target).Dispose ();
			((IDisposable)ctx).Dispose ();
			return true;
		}

		#region IMediaObject implementation

		public virtual void Play () {
		}

		public virtual void Pause () {
		}

		public virtual void Rewind () {
		}

		public virtual void Forward () {
		}

		public virtual void PreviousChapter () {
		}

		public virtual void NextChapter () {
		}

		public virtual void Shuffle () {
		}

		public virtual void Repeat () {
		}

		public virtual void Eject () {
		}

		public virtual void Record () {
		}

		public virtual void Stop () {
		}

		public virtual void Seek (double time) {
		}

		#endregion

	}
}

