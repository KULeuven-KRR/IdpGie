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
using Gtk;

namespace IdpGie {
    public partial class TopWindow : Gtk.Window {

        private TopWindow () : base(WindowType.Toplevel) {
            this.Build ();
            this.Show ();
        }

        public void LoadTab (string title, Widget widget) {
            /*this.mainhierarchy.Add (widget);
            global::Gtk.Box.BoxChild w = ((global::Gtk.Box.BoxChild)(this.mainhierarchy [widget]));
            w.Position = 0;
            w.Expand = true;
            w.Fill = true;
            if ((this.Child != null)) {
                this.Child.ShowAll ();
            }*/
            this.tabcontrol.Open ("Test.idpd");
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

