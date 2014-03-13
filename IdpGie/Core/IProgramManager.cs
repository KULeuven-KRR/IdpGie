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

		/// <summary>
		/// Gets or sets the geometry of the output.
		/// </summary>
		/// <value>
		/// The geometry of the output.
		/// </value>
		/// <remarks>
		/// <para>The geometry determines how the different windows should be positioned. This property is relevant if the theory is time sensitive and is printed to a device that is not time sensitive.</para>
		/// </remarks>
		StripGeometry Geometry {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether the program runs an interactive session.
		/// </summary>
		/// <value>
		/// <c>true</c> if the session is interactive; otherwise, <c>false</c>.
		/// </value>
		bool Interactive {
			get;
		}

		/// <summary>
		/// Gets or sets a the size of the canvas.
		/// </summary>
		/// <value>
		/// The <see cref="CanvasSize"/> with which the program runs, for instance the size of the window.
		/// </value>
		CanvasSize CanvasSize {
			get;
			set;
		}

		/// <summary>
		/// Gets an enumerable with the name of all input files.
		/// </summary>
		/// <value>
		/// An enumerable containing all input files.
		/// </value>
		IEnumerable<string> InputFiles {
			get;
		}

		/// <summary>
		/// Gets or sets the idp file that is used to generate models and modify in an interactive session.
		/// </summary>
		/// <value>
		/// The idp file that is used to generate models and modify in an interactive session.
		/// </value>
		[RuntimeFlag("i|idp","Feed the system an .idp file. The program must be given an .asp file as well in order to paint something.")]
		string IdpFile {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the time in theory space that should be drawn or the initial time of which the corresponding state should be painted.
		/// </summary>
		/// <value>
		/// The time in theory space that should be drawn or the initial time of which the corresponding state should be painted.
		/// </value>
		[RuntimeFlag("T|time","The timeframe of the model to plot (interactive sessions will ignore this argument).")]
		double Time {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the specified output file to store output to. For instance the LaTeX file.
		/// </summary>
		/// <value>
		/// The output file to store output to. For instance the LaTeX file.
		/// </value>
		[RuntimeFlag("o|output", "The output file (to store for instance LaTeX files).")]
		string OutputFile {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the hook file.
		/// </summary>
		/// <value>
		/// The name of the hook file.
		/// </value>
		[RuntimeFlag("H|idph",  "Feed the system a .idph file that contains the defined hooks.")]
		string HookFile {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the theory.
		/// </summary>
		/// <value>
		/// The name of the theory.
		/// </value>
		[RuntimeFlag("t|theory",  "The theory to use in the .idp file, only for interactive mode.")]
		string Theory {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the output mode of the program: the device that should handle the theory and draw file.
		/// </summary>
		/// <value>
		/// The output mode of the program: the device that should handle the theory and draw file.
		/// </value>
		[RuntimeFlag("m|mode", "The output mode (cairo, latex, ...).")]
		string OutputMode {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the structure to process.
		/// </summary>
		/// <value>
		/// The name of the structure to process.
		/// </value>
		[RuntimeFlag("s|structure","The structure to use in the .idp file, only for interactive mode.")]
		string Structure {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the vocabulary to process.
		/// </summary>
		/// <value>
		/// The name of the vocabulary to process.
		/// </value>
		[RuntimeFlag("v|vocabulary","The vocabulary to use in the .idp file, only for interactive mode.")]
		string Vocabulary {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the idpd file to process. In case such file is given, only limited interactive mode is enabled.
		/// </summary>
		/// <value>
		/// The name of the idpd file.
		/// </value>
		[RuntimeFlag("d|idpd","Feed the system a .idpd file. Limited interactive mode is enabled.")]
		string IdpdFile {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the program should show help.
		/// </summary>
		/// <value>
		/// <c>true</c> if the program should show help; otherwise, <c>false</c>.
		/// </value>
		[RuntimeFlag("h|?|help", "Show this help manual and exit.")]
		bool ShowHelp {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the program must list all the devices.
		/// </summary>
		/// <value>
		/// <c>true</c> if the program should list all the devices; otherwise, <c>false</c>.
		/// </value>
		[RuntimeFlag("list-devices", "List the output devices together with a description.")]
		bool ListDevices {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the program should list all paint predicates.
		/// </summary>
		/// <value>
		/// <c>true</c> if the program should list all paint predicates; otherwise, <c>false</c>.
		/// </value>
		[RuntimeFlag("list-paints","List the paint predicates together with a description.")]
		bool ListPaints {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the program should list all hook predicates.
		/// </summary>
		/// <value>
		/// <c>true</c> if the program should list all hook predicates; otherwise, <c>false</c>.
		/// </value>
		[RuntimeFlag("list-hooks","List the hooks that can be handled together with a description.")]
		bool ListHooks {
			get;
			set;
		}

		/// <summary>
		/// Gets a value indicating whether the program should only output info about the program.
		/// </summary>
		/// <value>
		/// <c>true</c> if only info should be printed; otherwise, <c>false</c>.
		/// </value>
		bool HelpOrLists {
			get;
		}

		/// <summary>
		/// Gets or sets the asp file to process.
		/// </summary>
		/// <value>
		/// The asp file to process.
		/// </value>
		[RuntimeFlag("a|asp","Feed the system an .asp file in order to convert an idp model into drawing instructions.")]
		string AspFile {
			get;
			set;
		}

		/// <summary>
		/// Gets the content of the asp file.
		/// </summary>
		/// <value>
		/// The content of the asp file.
		/// </value>
		string AspContent {
			get;
		}

		/// <summary>
		/// Gets the content of the hook file.
		/// </summary>
		/// <value>
		/// The content of the hook file.
		/// </value>
		string HookContent {
			get;
		}

		/// <summary>
		/// Gets or sets the port on which the webserver should run.
		/// </summary>
		/// <value>
		/// The port on which the webserver should run.
		/// </value>
		[RuntimeFlag("p|port","The port of the server (if applicable, by default 8080).")]
		int Port {
			get;
			set;
		}

		/// <summary>
		/// Generates a <see cref="StripCanvasSize"/> with the given number of windows.
		/// </summary>
		/// <returns>
		/// A <see cref="StripCanvasSize"/> based on the given number of windows.
		/// </returns>
		/// <param name='size'>
		/// The given number of windows.
		/// </param>
		StripCanvasSize GenerateStripCanvasSize (int size);

		/// <summary>
		/// Gets the stream of the idp file.
		/// </summary>
		/// <returns>
		/// The idp file stream.
		/// </returns>
		Stream GetIdpStream ();

		/// <summary>
		/// Run the program with the specified args.
		/// </summary>
		/// <param name='args'>
		/// The specified arguments to run the program with.
		/// </param>
		void Run (string[] args);

	}
}

