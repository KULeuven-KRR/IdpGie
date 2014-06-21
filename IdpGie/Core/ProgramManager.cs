//
//  ProgramManager.cs
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

using System;
using System.Collections.Generic;
using Mono.Unix;
using System.IO;
using Gtk;
using Mono.Options;
using IdpGie.Utils;
using System.Reflection;
using IdpGie.Geometry;
using IdpGie.Interaction;
using IdpGie.Interaction.Idp;
using IdpGie.OutputDevices;
using IdpGie.Shapes.Web;

namespace IdpGie.Core {
	/// <summary>
	/// The program manager that parses the input arguments and interacts with the domain space in the specified way.
	/// </summary>
	public class ProgramManager : IProgramManager {
		private string idpFile = null, idpdFile = null, aspFile = null, hookFile = null, outputFile = null,
			theory = "T", structure = "S", vocabulary = "V", serverFolder = ".", aspContent = null,
			hookContent = null, outputMode = "cairowindow";
		private readonly OptionSet options;
		private StripGeometry geometry = new StripGeometry ();
		private CanvasSize canvasSize = new CanvasSize ();

		/// <summary>
		/// Gets the full name of the program.
		/// </summary>
		/// <value>
		/// The full name of the program.
		/// </value>
		public static string FullProgramName {
			get {
				return Assembly.GetExecutingAssembly ().GetName ().FullName;
			}
		}

		/// <summary>
		/// Gets the name of the program.
		/// </summary>
		/// <value>
		/// The name of the program.
		/// </value>
		public static string ProgramName {
			get {
				return Assembly.GetExecutingAssembly ().GetName ().Name;
			}
		}

		/// <summary>
		/// Gets the version of the program.
		/// </summary>
		/// <value>
		/// The version of the program.
		/// </value>
		public static Version ProgramVersion {
			get {
				return Assembly.GetExecutingAssembly ().GetName ().Version;
			}
		}

		/// <summary>
		/// Gets the name and version of the program.
		/// </summary>
		/// <value>
		/// The name and version of the program.
		/// </value>
		public static string ProgramNameVersion {
			get {
				return string.Format ("{0} version {1}", ProgramManager.ProgramName, ProgramManager.ProgramVersion);
			}
		}
		#region IProgramManager implementation
		/// <summary>
		///  Gets or sets the geometry of the output. 
		/// </summary>
		/// <value>
		///  The geometry of the output. 
		/// </value>
		public StripGeometry Geometry {
			get {
				return this.geometry;
			}
			set {
				this.geometry = value;
			}
		}

		/// <summary>
		///  Gets a value indicating whether the program runs an interactive session. 
		/// </summary>
		/// <value>
		/// <c>true</c> if interactive; otherwise, <c>false</c>.
		/// </value>
		public bool Interactive {
			get {
				return this.IdpFile != null && this.AspFile != null;
			}
		}

		/// <summary>
		/// Gets or sets a the size of the canvas.
		/// </summary>
		/// <value>
		/// The <see cref="CanvasSize"/> with which the program runs, for instance the size of the window.
		/// </value>
		public CanvasSize CanvasSize {
			get {
				return this.canvasSize;
			}
			set {
				this.canvasSize = value;
			}
		}

		/// <summary>
		///  Gets an enumerable with the name of all input files. 
		/// </summary>
		/// <value>
		///  An enumerable containing all input files. 
		/// </value>
		public IEnumerable<string> InputFiles {
			get {
				yield return this.idpFile;
				yield return this.idpdFile;
				yield return this.aspFile;
				yield return this.hookFile;
			}
		}

		/// <summary>
		///  Gets or sets the idp file that is used to generate models and modify in an interactive session. 
		/// </summary>
		/// <value>
		///  The idp file that is used to generate models and modify in an interactive session. 
		/// </value>
		public string IdpFile {
			get {
				return this.idpFile;
			}
			set {
				this.idpFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		/// <summary>
		///  Gets or sets the time in theory space that should be drawn or the initial time of which the corresponding state
		/// should be painted. 
		/// </summary>
		/// <value>
		///  The time in theory space that should be drawn or the initial time of which the corresponding state should be
		/// painted. 
		/// </value>
		public double Time {
			get;
			set;
		}

		/// <summary>
		///  Gets or sets the specified output file to store output to. For instance the LaTeX file. 
		/// </summary>
		/// <value>
		///  The output file to store output to. For instance the LaTeX file. 
		/// </value>
		public string OutputFile {
			get {
				return this.outputFile;
			}
			set {
				this.outputFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		/// <summary>
		///  Gets or sets the name of the hook file. 
		/// </summary>
		/// <value>
		///  The name of the hook file. 
		/// </value>
		public string HookFile {
			get {
				return this.hookFile;
			}
			set {
				this.hookFile = StringUtils.NonEmptyOrNull (value);
				this.hookContent = null;
			}
		}

		/// <summary>
		///  Gets or sets the name of the theory. 
		/// </summary>
		/// <value>
		///  The name of the theory. 
		/// </value>
		public string Theory {
			get {
				return this.theory;
			}
			set {
				this.theory = StringUtils.EffectiveOrDefault (value, this.theory);
			}
		}

		/// <summary>
		///  Gets or sets the output mode of the program: the device that should handle the theory and draw file. 
		/// </summary>
		/// <value>
		///  The output mode of the program: the device that should handle the theory and draw file. 
		/// </value>
		public string OutputMode {
			get {
				return this.outputMode;
			}
			set {
				StringUtils.EffectiveOrDefault (ref this.outputMode, value);
			}
		}

		/// <summary>
		///  Gets or sets the name of the structure to process. 
		/// </summary>
		/// <value>
		///  The name of the structure to process. 
		/// </value>
		public string Structure {
			get {
				return this.structure;
			}
			set {
				this.structure = StringUtils.EffectiveOrDefault (value, this.structure);
			}
		}

		/// <summary>
		///  Gets or sets the name of the vocabulary to process. 
		/// </summary>
		/// <value>
		///  The name of the vocabulary to process. 
		/// </value>
		public string Vocabulary {
			get {
				return this.vocabulary;
			}
			set {
				this.vocabulary = StringUtils.EffectiveOrDefault (value, this.vocabulary);
			}
		}

		/// <summary>
		///  Gets or sets the name of the idpd file to process. In case such file is given, only limited interactive mode is
		/// enabled. 
		/// </summary>
		/// <value>
		///  The name of the idpd file. 
		/// </value>
		public string IdpdFile {
			get {
				return this.idpdFile;
			}
			set {
				this.idpdFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		/// <summary>
		///  Gets or sets a value indicating whether the program should show help. 
		/// </summary>
		/// <value>
		/// <c>true</c> if show help; otherwise, <c>false</c>.
		/// </value>
		public bool ShowHelp {
			get;
			set;
		}

		/// <summary>
		///  Gets or sets a value indicating whether the program must list all the devices. 
		/// </summary>
		/// <value>
		/// <c>true</c> if list devices; otherwise, <c>false</c>.
		/// </value>
		public bool ListDevices {
			get;
			set;
		}

		/// <summary>
		///  Gets or sets a value indicating whether the program should list all paint predicates. 
		/// </summary>
		/// <value>
		/// <c>true</c> if list paints; otherwise, <c>false</c>.
		/// </value>
		public bool ListPaints {
			get;
			set;
		}

		/// <summary>
		///  Gets or sets a value indicating whether the program should list all hook predicates. 
		/// </summary>
		/// <value>
		/// <c>true</c> if list hooks; otherwise, <c>false</c>.
		/// </value>/
		public bool ListHooks {
			get;
			set;
		}

		/// <summary>
		///  Gets a value indicating whether the program should only output info about the program. 
		/// </summary>
		/// <value>
		/// <c>true</c> if help or lists; otherwise, <c>false</c>.
		/// </value>
		public bool HelpOrLists {
			get {
				return this.ShowHelp || this.ListDevices || this.ListHooks || this.ListPaints;
			}
		}

		/// <summary>
		///  Gets or sets the asp file to process. 
		/// </summary>
		/// <value>
		///  The asp file to process. 
		/// </value>
		public string AspFile {
			get {
				return this.aspFile;
			}
			set {
				this.aspFile = StringUtils.NonEmptyOrNull (value);
				this.aspContent = null;
			}
		}

		/// <summary>
		///  Gets the content of the asp file. 
		/// </summary>
		/// <value>
		///  The content of the asp file. 
		/// </value>
		public string AspContent {
			get {
				return this.generateAspContent ();
			}
		}

		/// <summary>
		///  Gets the content of the hook file. 
		/// </summary>
		/// <value>
		///  The content of the hook file. 
		/// </value>
		public string HookContent {
			get {
				return this.generateHookContent ();
			}
		}

		/// <summary>
		///  Gets or sets the port on which the webserver should run. 
		/// </summary>
		/// <value>
		///  The port on which the webserver should run. 
		/// </value>
		public int Port {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the root of the folder of the web server.
		/// </summary>
		/// <value>
		/// The root of the folder of the web server.
		/// </value>
		public string ServerFolder {
			get {
				return this.serverFolder;
			}
			set {
				this.serverFolder = value;
			}
		}
		#endregion
		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Core.ProgramManager"/> class.
		/// </summary>
		public ProgramManager () {
			this.Time = 0.0d;
			this.Port = 8080;
			this.options = new OptionSet () { {
					"a|asp=",
					"Feed the system an .asp file in order to convert an idp model into drawing instructions.",
					x => this.AspFile = x
				}, {
					"i|idp=",
					"Feed the system an .idp file. The program must be given an .asp file as well in order to paint something.",
					x => this.IdpFile = x
				},
				{ "d|idpd=",  "Feed the system a .idpd file. Limited interactive mode is enabled.", x => this.IdpdFile = x },
				{ "H|idph=",  "Feed the system a .idph file that contains the defined hooks.", x => this.HookFile = x },
				{ "t|theory=",  "The theory to use in the .idp file, only for interactive mode.", x => this.Theory = x },
				{ "s|structure=","The structure to use in the .idp file, only for interactive mode.",x => this.Structure = x }, {
					"v|vocabulary=",
					"The vocabulary to use in the .idp file, only for interactive mode.",
					x => this.Vocabulary = x
				},
				{ "o|output=", "The output file (to store for instance LaTeX files).", x => this.OutputFile = x }, {
					"T|time=",
					"The timeframe of the model to plot (interactive sessions will ignore this argument).",
					x => this.Time = double.Parse (x)
				},
				{ "m|mode=", "The output mode (cairo, latex, ...).", x => this.OutputMode = x },
				{ "h|?|help", "Show this help manual and exit.",x => this.ShowHelp = (x != null) },
				{ "list-devices", "List the output devices together with a description.",x => this.ListDevices = (x != null) }, {
					"list-paints",
					"List the paint predicates together with a description.",
					x => this.ListPaints = (x != null)
				}, {
					"list-hooks",
					"List the hooks that can be handled together with a description.",
					x => this.ListHooks = (x != null)
				}, {
					"canvas-size=",
					"The size of the document (for instance the size of the resulting pdf).",
					x => this.CanvasSize = CanvasSize.Parse (x)
				}, {
					"g|geometry=",
					"The geometry of the document (in case one works with chapters).",
					x => this.Geometry = StripGeometry.Parse (x)
				}, {
					"p|port=",
					"The port of the server (if applicable, by default 8080).",
					x => this.Port = int.Parse (x)
				}, {"serverfolder","The root of the folder of the web server.", x => this.ServerFolder = x}
			};
		}
		#region IProgramManager implementation
		/// <summary>
		/// Generates a <see cref="StripCanvasSize"/> with the given number of windows.
		/// </summary>
		/// <returns>
		/// A <see cref="StripCanvasSize"/> based on the given number of windows.
		/// </returns>
		/// <param name='size'>
		/// The given number of windows.
		/// </param>
		public StripCanvasSize GenerateStripCanvasSize (int size) {
			return new StripCanvasSize (this.CanvasSize, this.Geometry, size);
		}

		private string generateAspContent () {
			if (this.aspContent == null && this.aspFile != null) {
				using (FileStream fs = File.Open (this.aspFile, FileMode.Open, FileAccess.Read)) {
					using (TextReader tr = new StreamReader (fs)) {
						this.aspContent = tr.ReadToEnd ();
					}
				}
			}
			return this.aspContent;
		}

		private string generateHookContent () {
			if (this.hookContent == null) {
				if (this.hookFile != null) {
					using (FileStream fs = File.Open (this.hookFile, FileMode.Open, FileAccess.Read)) {
						using (TextReader tr = new StreamReader (fs)) {
							this.hookContent = tr.ReadToEnd ();
						}
					}
				} else {
					this.hookContent = string.Empty;
				}
			}
			return this.hookContent;
		}

		/// <summary>
		///  Validates the state of this instance.  This means that no two conficting flags can be active at the same time.
		/// </summary>
		public bool Validate () {
			if (this.HelpOrLists) {
				return true;
			}
			if (this.idpFile == null && this.aspFile == null && this.idpdFile == null) {
				throw new IdpGieException ("No files are given.");
			} else if (this.idpdFile == null) {
				if (this.idpFile == null) {
					throw new IdpGieException ("Interactive mode but the .idp file is missing.");
				} else if (this.aspFile == null) {
					throw new IdpGieException ("Interactive mode but the .asp file is missing.");
				}
			}
			foreach (string file in this.InputFiles) {
				if (file != null && !File.Exists (file)) {
					throw new IdpGieException ("Cannot find file \"{0}\".", file);
				}
			}
			return true;
		}

		/// <summary>
		///  Gets the stream of the idp file. 
		/// </summary>
		/// <returns>
		///  The idp file stream. 
		/// </returns>
		public Stream GetIdpStream () {
			if (this.Interactive) {
				return File.Open (this.idpFile, FileMode.Open, FileAccess.ReadWrite);
			} else {
				throw new IdpGieException ("Cannot alter the Idp file, running the program in noninteractive mode.");
			}
		}

		/// <summary>
		///  Run the program with the specified args. 
		/// </summary>
		/// <param name='args'>
		///  The specified arguments to run the program with. 
		/// </param>
		public void Run (string[] args) {
			options.Parse (args);
			this.Validate ();

			if (this.HelpOrLists) {
				if (this.ShowHelp) {
					Console.Error.WriteLine (ProgramManager.ProgramNameVersion);
					Console.Error.WriteLine ("Usage: idpgie [Options]+");
					Console.Error.WriteLine ("IDP-GIE is a Graphical Interactive Environment (GIE) for the IDP system.");
					Console.Error.WriteLine ();
					Console.Error.WriteLine ("Options:");
					options.WriteOptionDescriptions (Console.Error);
					Console.Error.WriteLine ();
					Console.Error.WriteLine ("Authors:");
					Console.Error.WriteLine (" idpgie is maintained by Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>");
					Console.Error.WriteLine (" idp is a program of the KRR Research Group of the KU Leuven <krr@cs.kuleuven.be>.");
					Console.Error.WriteLine ();
					Console.Error.WriteLine ("License:");
					Console.Error.WriteLine (" Copyright (c) 2014 Willem Van Onsem\n\n This program is free software: you can redistribute it and/or modify\n it under the terms of the GNU General Public License as published by\n the Free Software Foundation, either version 3 of the License, or\n (at your option) any later version.");
				} else if (this.ListDevices) {
					foreach (Tuple<string,string> ss in OutputDevice.ListDevices ()) {
						Console.Error.WriteLine ("{0}\t{1}", ss.Item1, ss.Item2);
					}
				}

			} else {
				//Application.Init ("idpgie", ref args);
				IAlterableReloadableChangeableStream<string> strm;
				string filename;
				if (this.Interactive) {
					strm = new IdpInteractiveStream (this.IdpFile, this.Theory, this.Structure, this.Vocabulary, this.AspContent, this.HookContent);
					filename = this.IdpFile;
				} else {
					strm = new AlterableContentChangeableStreamBase<FileStream,string> (new FileStream (this.IdpdFile, FileMode.Open));
					filename = this.IdpdFile;
				}
				DrawTheory dt = new DrawTheory (filename, strm);
				OutputDevice dev = OutputDevice.CreateDevice (this.OutputMode, dt, this);
				dev.Run ();
				Application.Quit ();
			}
		}
		#endregion
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		/// <param name='args'>
		/// The command-line arguments.
		/// </param>
		/// <returns>
		/// The exit code that is given to the operating system after the program ends.
		/// </returns>
		public static int Main (string[] args) {
			Catalog.Init ("IdpGie", "./locale");
			OutputDevice.AnalyzeAssembly (Assembly.GetExecutingAssembly ());
			WebShapeBase.AnalyzeAssembly (Assembly.GetExecutingAssembly ());
			ProgramManager manager = new ProgramManager ();
			try {
				manager.Run (args);
			} catch (Exception e) {
				Console.Error.Write ("ERROR: ");
				Console.Error.WriteLine (e.Message);
				Console.Error.WriteLine (e.StackTrace);
				Console.Error.WriteLine ("Try `idpgie --help' for more information.");
				return 0x01;
			}
			return 0x00;
		}
	}
}