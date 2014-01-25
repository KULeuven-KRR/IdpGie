//
//  IdpdCairoOutputDevice.cs
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
using IdpGie;

namespace IdpGie {
	[OutputDevice ("cairo")]
	public class OutputCairoDevice : OutputDevice {
		private Context context;
		private TopWindow tw;

		public Context Context {
			get {
				return this.context;
			}
			set {
				this.context = value;
			}
		}

		public OutputCairoDevice (DrawTheory theory) : base (theory) {
		}

		#region implemented abstract members of IdpGie.IdpdOutputDevice

		public override void Run (ProgramManager manager) {
			this.CreateWindow ();
			OpenTab (this.Theory, new CairoFrameWidget (this.Theory));
			this.ShowWindow ();
		}

		public void CreateWindow () {
			tw = new TopWindow ();
		}

		public void ShowWindow () {
			Application.Run ();
		}

		#region IDisposable implementation

		public override void Dispose () {
			if (tw != null) {
				tw.Dispose ();
			}
		}

		#endregion

		public void OpenTab<T> (DrawTheory dt, T widget) where T : Widget, IMediaObject {
			this.tw.CreateTab<T> (dt, widget);
		}

		#endregion

	}
}