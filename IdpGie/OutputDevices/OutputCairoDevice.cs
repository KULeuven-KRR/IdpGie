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
using IdpGie.Core;
using IdpGie.UserInterface;

namespace IdpGie.OutputDevices {
	[OutputDevice ("cairowindow", "The content is plotted in an interactive window using Cairo graphics as 2d vector graphics engine.")]
	public class OutputCairoDevice : OutputWindowDevice {
		public OutputCairoDevice (DrawTheory theory, IProgramManager manager) : base (theory,manager) {
		}

		#region implemented abstract members of IdpGie.IdpdOutputDevice

		public override void Run () {
			this.CreateWindow ();
			OpenTab (this.Theory, new CairoFrameWidget (this.Theory));
			this.ShowWindow ();
		}

		#endregion

	}
}