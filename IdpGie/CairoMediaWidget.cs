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
using IdpGie.Hooks;

namespace IdpGie.GUI {

	public abstract class CairoMediaWidget : DrawingArea, IMediaObject, IHookSource {
		protected event EventHandler _OnPlay, _OnPause, _OnRewind, _OnForward, _OnPreviousChapter, _OnNextChapter,
            _OnShuffle, _OnRepeat, _OnEject, _OnRecord, _OnStop, _OnSeek;
		protected event EventHandler _Delete, _Destroy, _Expose, _MotionNotify, _ButtonPress, _TwoButtonPress,
            _ThreeButtonPress, _ButtonRelease, _KeyPress, _KeyRelease, _EnterNotify, _LeaveNotify, _FocusChange,
            _Configure, _Map, _Unmap, _PropertyNotify, _SelectionClear, _SelectionRequest, _SelectionNotify,
            _ProximityIn, _ProximityOut, _DragEnter, _DragLeave, _DragMotion, _DragStatus, _DropStart, _DropFinished,
            _ClientEvent, _VisibilityNotify, _NoExpose, _Scroll, _WindowState, _Setting, _OwnerChange, _GrabBroken;

		#region IHookSource implementation

		public event EventHandler DeleteHook {
			add {
				this._Delete += value;
			}
			remove {
				this._Delete -= value;
			}
		}

		public event EventHandler DestroyHook {
			add {
				this._Destroy += value;
			}
			remove {
				this._Destroy -= value;
			}
		}

		public event EventHandler ExposeHook {
			add {
				this._Expose += value;
			}
			remove {
				this._Expose -= value;
			}
		}

		public event EventHandler MotionNotifyHook {
			add {
				this._MotionNotify += value;
			}
			remove {
				this._MotionNotify -= value;
			}
		}

		public event EventHandler ButtonPressHook {
			add {
				this._ButtonPress += value;
			}
			remove {
				this._ButtonPress -= value;
			}
		}

		public event EventHandler TwoButtonPressHook {
			add {
				this._TwoButtonPress += value;
			}
			remove {
				this._TwoButtonPress -= value;
			}
		}

		public event EventHandler ThreeButtonPressHook {
			add {
				this._ThreeButtonPress += value;
			}
			remove {
				this._ThreeButtonPress -= value;
			}
		}

		public event EventHandler ButtonReleaseHook {
			add {
				this._ButtonRelease += value;
			}
			remove {
				this._ButtonRelease -= value;
			}
		}

		public event EventHandler KeyPressHook {
			add {
				this._KeyPress += value;
			}
			remove {
				this._KeyPress -= value;
			}
		}

		public event EventHandler KeyReleaseHook {
			add {
				this._KeyRelease += value;
			}
			remove {
				this._KeyRelease -= value;
			}
		}

		public event EventHandler EnterNotifyHook {
			add {
				this._EnterNotify += value;
			}
			remove {
				this._EnterNotify -= value;
			}
		}

		public event EventHandler LeaveNotifyHook {
			add {
				this._LeaveNotify += value;
			}
			remove {
				this._LeaveNotify -= value;
			}
		}

		public event EventHandler FocusChangeHook {
			add {
				this._FocusChange += value;
			}
			remove {
				this._FocusChange -= value;
			}
		}

		public event EventHandler ConfigureHook {
			add {
				this._Configure += value;
			}
			remove {
				this._Configure -= value;
			}
		}

		public event EventHandler MapHook {
			add {
				this._Map += value;
			}
			remove {
				this._Map -= value;
			}
		}

		public event EventHandler UnmapHook {
			add {
				this._Unmap += value;
			}
			remove {
				this._Unmap -= value;
			}
		}

		public event EventHandler PropertyNotifyHook {
			add {
				this._PropertyNotify += value;
			}
			remove {
				this._PropertyNotify -= value;
			}
		}

		public event EventHandler SelectionClearHook {
			add {
				this._SelectionClear += value;
			}
			remove {
				this._SelectionClear -= value;
			}
		}

		public event EventHandler SelectionRequestHook {
			add {
				this._SelectionRequest += value;
			}
			remove {
				this._SelectionRequest -= value;
			}
		}

		public event EventHandler SelectionNotifyHook {
			add {
				this._SelectionNotify += value;
			}
			remove {
				this._SelectionNotify -= value;
			}
		}

		public event EventHandler ProximityInHook {
			add {
				this._ProximityIn += value;
			}
			remove {
				this._ProximityIn -= value;
			}
		}

		public event EventHandler ProximityOutHook {
			add {
				this._ProximityOut += value;
			}
			remove {
				this._ProximityOut -= value;
			}
		}

		public event EventHandler DragEnterHook {
			add {
				this._DragEnter += value;
			}
			remove {
				this._DragEnter -= value;
			}
		}

		public event EventHandler DragLeaveHook {
			add {
				this._DragLeave += value;
			}
			remove {
				this._DragLeave -= value;
			}
		}

		public event EventHandler DragMotionHook {
			add {
				this._DragMotion += value;
			}
			remove {
				this._DragMotion -= value;
			}
		}

		public event EventHandler DragStatusHook {
			add {
				this._DragStatus += value;
			}
			remove {
				this._DragStatus -= value;
			}
		}

		public event EventHandler DropStartHook {
			add {
				this._DropStart += value;
			}
			remove {
				this._DropStart -= value;
			}
		}

		public event EventHandler DropFinishedHook {
			add {
				this._DropFinished += value;
			}
			remove {
				this._DropFinished -= value;
			}
		}

		public event EventHandler ClientEventHook {
			add {
				this._ClientEvent += value;
			}
			remove {
				this._ClientEvent -= value;
			}
		}

		public event EventHandler VisibilityNotifyHook {
			add {
				this._VisibilityNotify += value;
			}
			remove {
				this._VisibilityNotify -= value;
			}
		}

		public event EventHandler NoExposeHook {
			add {
				this._NoExpose += value;
			}
			remove {
				this._NoExpose -= value;
			}
		}

		public event EventHandler ScrollHook {
			add {
				this._Scroll += value;
			}
			remove {
				this._Scroll -= value;
			}
		}

		public event EventHandler WindowStateHook {
			add {
				this._WindowState += value;
			}
			remove {
				this._WindowState -= value;
			}
		}

		public event EventHandler SettingHook {
			add {
				this._Setting += value;
			}
			remove {
				this._Setting -= value;
			}
		}

		public event EventHandler OwnerChangeHook {
			add {
				this._OwnerChange += value;
			}
			remove {
				this._OwnerChange -= value;
			}
		}

		public event EventHandler GrabBrokenHook {
			add {
				this._GrabBroken += value;
			}
			remove {
				this._GrabBroken -= value;
			}
		}

		#endregion

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
			((IDisposable)ctx.GetTarget ()).Dispose ();
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

