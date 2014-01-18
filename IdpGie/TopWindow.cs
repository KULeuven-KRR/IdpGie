//
//  TopWindow.cs
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

namespace IdpGie {
	public partial class TopWindow : Gtk.Window {
		private readonly Dictionary<Widget,DrawTheory> sheets = new Dictionary<Widget,DrawTheory> ();
		private Widget current = null;

		public TopWindow () : base (WindowType.Toplevel) {
			this.Build ();
			this.mediabar.CurrentChanged += NamedFunctionItime.Instance.SetValue;
			this.mediabar.CurrentChanged += NamedFunctionDtime.Instance.SetValue;
			this.Show ();
		}

		private void SetCurrent<T> (T current) where T : Widget, IMediaObject {
			if (this.current != null) {
				this.current.Hide ();
				this.mediabar.CurrentChanged -= (x, y) => current.Seek (y);
			}
			this.current = current;
			if (this.current != null) {
				DrawTheory dt = this.sheets [this.current];
				this.mediabar.Min = dt.MinTime;
				this.mediabar.Max = dt.MaxTime + 1.0d;
				this.mediabar.CurrentChanged += (x, y) => current.Seek (y);
				this.current.Show ();
			} else {
				this.mediabar.Mode = MediaMode.Pause;
				this.mediabar.SetMinCurrentMax (0.0d, 0.0d, 0.0d);
			}
		}

		public void CreateTab<T> (DrawTheory dt, T widget) where T : Widget, IMediaObject {
			string name = dt.Name;
			this.mainhierarchy.Add (widget);
			Box.BoxChild w = ((Box.BoxChild)(this.mainhierarchy [widget]));
			w.Position = 0;
			w.Expand = true;
			w.Fill = true;
			this.sheets.Add (widget, dt);
			this.SetCurrent (widget);
			widget.HasFocus = true;
			this.tabcontrol.Open (name);
		}

		protected override bool OnDeleteEvent (Gdk.Event evnt) {
			Application.Quit ();
			return base.OnDeleteEvent (evnt);
		}

		protected void Quit (object sender, EventArgs e) {
			this.Destroy ();
			Application.Quit ();
		}
	}
}

