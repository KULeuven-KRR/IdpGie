//
//  BlueprintMediabar.cs
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
using System.ComponentModel;
using System.Collections.Generic;
using Cairo;

namespace IdpGie {
	[ToolboxItem (true)]
	public class BlueprintMediabar : CairoMediaWidget {
		public const double Offset = 10.0d;
		public const double Epsilon = 1e-6;
		private const double xb = 2 * Offset + 36.0d;
		public const uint UpdateInterval = 0x28;
		private double min = 0.0d;
		private double max = 1.0d;
		private double current = 0.0d;
		private double speed = 1.0d;
		private double xtickS = 0.0d;
		private double xtickE = 0.0d;
		private MediaMode mode = MediaMode.Pause;
		private IEnumerable<double> chapters;

		private event Action<BlueprintMediabar,double> currentChanged;

		public double Min {
			get {
				return this.min;
			}
			set {
				this.min = Math.Min (value, this.max - Epsilon);
				this.QueueDraw ();
			}
		}

		public double Max {
			get {
				return this.max;
			}
			set {
				this.max = Math.Max (value, this.min + Epsilon);
				this.QueueDraw ();
			}
		}

		public IEnumerable<double> Chapters {
			get {
				return this.chapters;
			}
		}

		public double Current {
			get {
				return this.current;
			}
			set {
				this.current = Math.Max (this.min, Math.Min (max, value));
				this.handleCurrentChanged ();
				this.QueueDraw ();
			}
		}

		public double Speed {
			get {
				return this.speed;
			}
			set {
				this.speed = value;
			}
		}

		public MediaMode Mode {
			get {
				return this.mode;
			}
			set {
				this.mode = value;
				this.checkMode ();
				this.QueueDrawArea ((int)Math.Floor (Offset) - 1, 0, 35, 34);
			}
		}

		public event Action<BlueprintMediabar,double> CurrentChanged {
			add {
				this.currentChanged += value;
			}
			remove {
				this.currentChanged -= value;
			}
		}

		public BlueprintMediabar () : this (EnumerableUtils.Zero<double> ()) {
		}

		public BlueprintMediabar (IEnumerable<double> chapters) {
			this.AddEvents ((int)(Gdk.EventMask.PointerMotionMask | Gdk.EventMask.ButtonPressMask | Gdk.EventMask.ButtonReleaseMask));
			this.chapters = chapters;
		}

		public void SetMinCurrentMax (double min, double current, double max) {
			this.min = min;
			this.max = Math.Max (max, this.min);
			this.current = Math.Min (max, Math.Max (min, current));
			this.handleCurrentChanged ();
			this.QueueDraw ();
		}

		protected double XtoT (double x) {
			int w, h;
			this.GdkWindow.GetSize (out w, out h);
			double wb = w - Offset - xb - 4.0d;
			return (x - xb) * (max - min) / wb + min;
		}

		protected double TtoX (double t) {
			int w, h;
			this.GdkWindow.GetSize (out w, out h);
			double wb = w - Offset - xb - 4.0d;
			return wb * (t - min) / (max - min) + xb;
		}

		protected double BoundT (double t) {
			return Math.Min (Math.Max (this.min, t), this.max - Epsilon);
		}

		protected override bool OnMotionNotifyEvent (Gdk.EventMotion evnt) {
			double x = evnt.X, y = evnt.Y;
			if (this.mode == MediaMode.Seek) {
				this.Current = this.BoundT (this.XtoT (x));
			} else {
				if (y >= 1 && y <= 33 && ((x >= Offset && x <= Offset + 32) || (x >= xtickS && x <= xtickE))) {
					this.GdkWindow.Cursor = new Gdk.Cursor (Gdk.CursorType.Hand1);
				} else {
					this.GdkWindow.Cursor = new Gdk.Cursor (Gdk.CursorType.Arrow);
				}
			}
			return base.OnMotionNotifyEvent (evnt);
		}

		protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt) {
			if (this.Mode == MediaMode.Seek) {
				this.Mode = MediaMode.Pause;
			}
			return base.OnButtonReleaseEvent (evnt);
		}

		protected override bool OnButtonPressEvent (Gdk.EventButton ev) {
			double x = ev.X;
			int w, h;
			this.GdkWindow.GetSize (out w, out h);
			double wb = w - Offset - xb - 4.0d;
			double xbt = xb + wb * (current - min) / (max - min) - 4.0d;
			if (x >= Offset && x <= Offset + 32 && (int)this.Mode <= 0x01) {
				this.Mode = (MediaMode)(0x01 - this.Mode);
			} else if (x >= xbt && x <= xbt + 8.0d) {
				this.Mode = MediaMode.Seek;
			}
			return base.OnButtonPressEvent (ev);
		}

		private void checkMode () {
			if (this.mode == MediaMode.Play) {
				Gdk.Threads.AddTimeout (0, UpdateInterval, this.updateCurrent);
			}
		}

		private bool updateCurrent () {
			if (this.mode != MediaMode.Play) {
				return false;
			} else {
				this.current += 0.001d * UpdateInterval * this.speed;
				if (this.current >= this.max - Epsilon) {
					this.current = this.max - Epsilon;
					this.Mode = MediaMode.Pause;
				}
				this.QueueDraw ();
				this.handleCurrentChanged ();
				return true;
			}
		}

		private void handleCurrentChanged () {
			this.OnCurrentChanged ();
			if (currentChanged != null) {
				this.currentChanged (this, this.current);
			}
		}

		protected virtual void OnCurrentChanged () {
		}

		protected override void PaintWidget (Context ctx, int w, int h) {
			ctx.Rectangle (0.0d, 0.0d, w, h);
			ctx.SetFill (BlueprintStyle.BluePrint);
			double wb = w - Offset - xb - 4.0d;
			double xbt = wb * (current - min) / (max - min) - 4.0d;
			ctx.Fill ();
			switch (this.mode) {
			case MediaMode.Play:
				ctx.Rectangle (Offset + 2, 1.0d, 8.0d, 32.0d);
				ctx.Rectangle (Offset + 18, 1.0d, 8.0d, 32.0d);
				ctx.ClosePath ();
				break;
			default:
				ctx.MoveTo (Offset, 1.0d);
				ctx.RelLineTo (32.0d, 16.0d);
				ctx.RelLineTo (-32.0d, 16.0d);
				ctx.ClosePath ();
				break;
			}
			double xf = xb + xbt;
			double xt = xf + 8.0d;
			ctx.Rectangle (xf, 1.0d, 8.0d, 32.0d);
			this.xtickS = xf;
			this.xtickE = xt;
			ctx.SetFill (BlueprintStyle.FillPattern);
			ctx.FillPreserve ();
			ctx.SetFill (BlueprintStyle.HardWhite);
			if (xbt > 0.0d) {
				ctx.MoveTo (xb, 16.0d);
				ctx.LineTo (xf, 16.0d);
			}
			if (xf < w - Offset - 4.0d) {
				ctx.MoveTo (xt, 16.0d);
				ctx.LineTo (w - Offset - 4.0d, 16.0d);
			}
			foreach (double t in this.Chapters) {
				double x = this.TtoX (t);
				if (x < xf || x >= xt) {
					ctx.MoveTo (x, 0.0d);
					ctx.LineTo (x, 33.0d);
				}
			}
			ctx.Stroke ();
		}

		protected override void OnSizeRequested (ref Gtk.Requisition requisition) {
			requisition.Height = 34;
			requisition.Width = 100;
		}
	}
}

