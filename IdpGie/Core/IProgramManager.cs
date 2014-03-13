//
//  IProgramManager.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System.Collections.Generic;
using System.IO;
using IdpGie.Abstract;
using IdpGie.Geometry;

namespace IdpGie.Core {

	/// <summary>
	/// An interface defining the program manager, a manager that stores the arguments of the program and interacts with the user.
	/// </summary>
	public interface IProgramManager : IValidate {

		StripGeometry Geometry {
			get;
			set;
		}

		bool Interactive {
			get;
		}

		CanvasSize CanvasSize {
			get;
			set;
		}

		IEnumerable<string> InputFiles {
			get;
		}

		[RuntimeFlag("i|idp","Feed the system an .idp file. The program must be given an .asp file as well in order to paint something.")]
		string IdpFile {
			get;
			set;
		}

		[RuntimeFlag("T|time","The timeframe of the model to plot (interactive sessions will ignore this argument).")]
		double Time {
			get;
			set;
		}

		[RuntimeFlag("o|output", "The output file (to store for instance LaTeX files).")]
		string OutputFile {
			get;
			set;
		}

		[RuntimeFlag("H|idph",  "Feed the system a .idph file that contains the defined hooks.")]
		string HookFile {
			get;
			set;
		}

		[RuntimeFlag("t|theory",  "The theory to use in the .idp file, only for interactive mode.")]
		string Theory {
			get;
			set;
		}

		[RuntimeFlag("m|mode", "The output mode (cairo, latex, ...).")]
		string OutputMode {
			get;
			set;
		}

		[RuntimeFlag("s|structure","The structure to use in the .idp file, only for interactive mode.")]
		string Structure {
			get;
			set;
		}

		[RuntimeFlag("v|vocabulary","The vocabulary to use in the .idp file, only for interactive mode.")]
		string Vocabulary {
			get;
			set;
		}

		[RuntimeFlag("d|idpd","Feed the system a .idpd file. Limited interactive mode is enabled.")]
		string IdpdFile {
			get;
			set;
		}

		[RuntimeFlag("h|?|help", "Show this help manual and exit.")]
		bool ShowHelp {
			get;
			set;
		}

		[RuntimeFlag("list-devices", "List the output devices together with a description.")]
		bool ListDevices {
			get;
			set;
		}

		[RuntimeFlag("list-paints","List the paint predicates together with a description.")]
		bool ListPaints {
			get;
			set;
		}

		[RuntimeFlag("list-hooks","List the hooks that can be handled together with a description.")]
		bool ListHooks {
			get;
			set;
		}

		bool HelpOrLists {
			get;
		}

		[RuntimeFlag("a|asp","Feed the system an .asp file in order to convert an idp model into drawing instructions.")]
		string AspFile {
			get;
			set;
		}

		string AspContent {
			get;
		}

		string HookContent {
			get;
		}

		[RuntimeFlag("p|port","The port of the server (if applicable, by default 8080).")]
		int Port {
			get;
			set;
		}

		StripCanvasSize GenerateStripCanvasSize (int size);

		Stream GetIdpStream ();

		void Run (string[] args);

	}
}

