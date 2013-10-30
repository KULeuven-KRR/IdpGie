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
using Gtk;
using Cairo;

namespace IdpGie {

    public abstract class CairoMediaWidget : DrawingArea, IMediaObject {

        #region IMediaObject implementation
        public MediaButtons SupportedMedia {
            get {
                return MediaButtons.None;
            }
        }
        #endregion

        protected virtual void PaintWidget (Context ctx, int w, int h) {
        }

        protected override bool OnExposeEvent (Gdk.EventExpose ev) {
            Context ctx = Gdk.CairoHelper.Create (this.GdkWindow);
            ctx.FillRule = FillRule.EvenOdd;
            int w, h;
            this.GdkWindow.GetSize (out w, out h);
            this.PaintWidget (ctx, w, h);
            ((IDisposable)ctx.Target).Dispose ();
            ((IDisposable)ctx).Dispose ();
            return base.OnExposeEvent (ev);
        }

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

    }

}

