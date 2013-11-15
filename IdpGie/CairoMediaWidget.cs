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

    public abstract class CairoMediaWidget : DrawingArea, IMediaObject, IHookSource {

        protected event EventHandler _OnPlay, _OnPause, _OnRewind, _OnForward, _OnPreviousChapter, _OnNextChapter,
            _OnShuffle, _OnRepeat, _OnEject, _OnRecord, _OnStop, _OnSeek;
        protected event EventHandler _Delete, _Destroy, _Expose, _MotionNotify, _ButtonPress, _TwoButtonPress,
            _ThreeButtonPress, _ButtonRelease, _KeyPress, _KeyRelease, _EnterNotify, _LeaveNotify, _FocusChange,
            _Configure, _Map, _Unmap, _PropertyNotify, _SelectionClear, _SelectionRequest, _SelectionNotify,
            _ProximityIn, _ProximityOut, _DragEnter, _DragLeave, _DragMotion, _DragStatus, _DropStart, _DropFinished,
            _ClientEvent, _VisibilityNotify, _NoExpose, _Scroll, _WindowState, _Setting, _OwnerChange, _GrabBroken;

        #region IHookSource implementation
        event EventHandler Delete {
            add {
                this._Delete += value;
            }
            remove {
                this._Delete -= value;
            }
        }
        event EventHandler Destroy {
            add {
                this._Destroy += value;
            }
            remove {
                this._Destroy -= value;
            }
        }
        event EventHandler Expose {
            add {
                this._Expose += value;
            }
            remove {
                this._Expose -= value;
            }
        }
        event EventHandler MotionNotify {
            add {
                this._MotionNotify += value;
            }
            remove {
                this._MotionNotify -= value;
            }
        }
        event EventHandler ButtonPress {
            add {
                this._ButtonPress += value;
            }
            remove {
                this._ButtonPress -= value;
            }
        }
        event EventHandler TwoButtonPress {
            add {
                this._TwoButtonPress += value;
            }
            remove {
                this._TwoButtonPress -= value;
            }
        }
        event EventHandler ThreeButtonPress {
            add {
                this._ThreeButtonPress += value;
            }
            remove {
                this._ThreeButtonPress -= value;
            }
        }
        event EventHandler ButtonRelease {
            add {
                this._ButtonRelease += value;
            }
            remove {
                this._ButtonRelease -= value;
            }
        }
        event EventHandler KeyPress {
            add {
                this._KeyPress += value;
            }
            remove {
                this._KeyPress -= value;
            }
        }
        event EventHandler KeyRelease {
            add {
                this._KeyRelease += value;
            }
            remove {
                this._KeyRelease -= value;
            }
        }
        event EventHandler EnterNotify {
            add {
                this._EnterNotify += value;
            }
            remove {
                this._EnterNotify -= value;
            }
        }
        event EventHandler LeaveNotify {
            add {
                this._LeaveNotify += value;
            }
            remove {
                this._LeaveNotify -= value;
            }
        }
        event EventHandler FocusChange {
            add {
                this._FocusChange += value;
            }
            remove {
                this._FocusChange -= value;
            }
        }
        event EventHandler Configure {
            add {
                this._Configure += value;
            }
            remove {
                this._Configure -= value;
            }
        }
        event EventHandler Map {
            add {
                this._Map += value;
            }
            remove {
                this._Map -= value;
            }
        }
        event EventHandler Unmap {
            add {
                this._Unmap += value;
            }
            remove {
                this._Unmap -= value;
            }
        }
        event EventHandler PropertyNotify {
            add {
                this._PropertyNotify += value;
            }
            remove {
                this._PropertyNotify -= value;
            }
        }
        event EventHandler SelectionClear {
            add {
                this._SelectionClear += value;
            }
            remove {
                this._SelectionClear -= value;
            }
        }
        event EventHandler SelectionRequest {
            add {
                this._SelectionRequest += value;
            }
            remove {
                this._SelectionRequest -= value;
            }
        }
        event EventHandler SelectionNotify {
            add {
                this._SelectionNotify += value;
            }
            remove {
                this._SelectionNotify -= value;
            }
        }
        event EventHandler ProximityIn {
            add {
                this._ProximityIn += value;
            }
            remove {
                this._ProximityIn -= value;
            }
        }
        event EventHandler ProximityOut {
            add {
                this._ProximityOut += value;
            }
            remove {
                this._ProximityOut -= value;
            }
        }
        event EventHandler DragEnter {
            add {
                this._DragEnter += value;
            }
            remove {
                this._DragEnter -= value;
            }
        }
        event EventHandler DragLeave {
            add {
                this._DragLeave += value;
            }
            remove {
                this._DragLeave -= value;
            }
        }
        event EventHandler DragMotion {
            add {
                this._DragMotion += value;
            }
            remove {
                this._DragMotion -= value;
            }
        }
        event EventHandler DragStatus {
            add {
                this._DragStatus += value;
            }
            remove {
                this._DragStatus -= value;
            }
        }
        event EventHandler DropStart {
            add {
                this._DropStart += value;
            }
            remove {
                this._DragStart -= value;
            }
        }
        event EventHandler DropFinished {
            add {
                this._DropFinished += value;
            }
            remove {
                this._DropFinished -= value;
            }
        }
        event EventHandler ClientEvent {
            add {
                this._ClientEvent += value;
            }
            remove {
                this._ClientEvent -= value;
            }
        }
        event EventHandler VisibilityNotify {
            add {
                this._VisibilityNotify += value;
            }
            remove {
                this._VisibilityNotify -= value;
            }
        }
        event EventHandler NoExpose {
            add {
                this._NoExpose += value;
            }
            remove {
                this._NoExpose -= value;
            }
        }
        event EventHandler Scroll {
            add {
                this._Scroll += value;
            }
            remove {
                this._Scroll -= value;
            }
        }
        event EventHandler WindowState {
            add {
                this._WindowState += value;
            }
            remove {
                this._WindowState -= value;
            }
        }
        event EventHandler Setting {
            add {
                this._Setting += value;
            }
            remove {
                this._Setting -= value;
            }
        }
        event EventHandler OwnerChange {
            add {
                this._OwnerChange += value;
            }
            remove {
                this._OwnerChange -= value;
            }
        }
        event EventHandler GrabBroken {
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

