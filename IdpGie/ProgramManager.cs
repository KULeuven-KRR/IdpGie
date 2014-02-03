//
//  ProgramManager.cs
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
using Mono.Unix;
using System.IO;
using Gtk;
using Mono.Options;
using IdpGie.Utils;
using System.Reflection;

namespace IdpGie {
	public class ProgramManager {
		private string idpFile = null, idpdFile = null, aspFile = null, hookFile = null, outputFile = null,
			theory = "T", structure = "S", vocabulary = "V", aspContent = null,
			hookContent = null, outputMode = "cairowindow";
		private readonly OptionSet options;
		public Geometry Geometry = new Geometry ();

		public bool Interactive {
			get {
				return this.IdpFile != null && this.AspFile != null;
			}
		}

		public DocumentSize DocumentSize = new DocumentSize ();

		public IEnumerable<string> InputFiles {
			get {
				yield return this.idpFile;
				yield return this.idpdFile;
				yield return this.aspFile;
				yield return this.hookFile;
			}
		}

		public string IdpFile {
			get {
				return this.idpFile;
			}
			set {
				this.idpFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		public double Time {
			get;
			set;
		}

		public string OutputFile {
			get {
				return this.outputFile;
			}
			set {
				this.outputFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		public string HookFile {
			get {
				return this.hookFile;
			}
			set {
				this.hookFile = StringUtils.NonEmptyOrNull (value);
				this.hookContent = null;
			}
		}

		public string Theory {
			get {
				return this.theory;
			}
			set {
				this.theory = StringUtils.EffectiveOrDefault (value, this.theory);
			}
		}

		public string OutputMode {
			get {
				return this.outputMode;
			}
			set {
				StringUtils.EffectiveOrDefault (ref this.outputMode, value);
			}
		}

		public string Structure {
			get {
				return this.structure;
			}
			set {
				this.structure = StringUtils.EffectiveOrDefault (value, this.structure);
			}
		}

		public string Vocabulary {
			get {
				return this.vocabulary;
			}
			set {
				this.vocabulary = StringUtils.EffectiveOrDefault (value, this.vocabulary);
			}
		}

		public string IdpdFile {
			get {
				return this.idpdFile;
			}
			set {
				this.idpdFile = StringUtils.NonEmptyOrNull (value);
			}
		}

		public bool ShowHelp {
			get;
			set;
		}

		public bool ListDevices {
			get;
			set;
		}

		public bool ListPaints {
			get;
			set;
		}

		public bool ListHooks {
			get;
			set;
		}

		public bool HelpOrLists {
			get {
				return this.ShowHelp || this.ListDevices || this.ListHooks || this.ListPaints;
			}
		}

		public string AspFile {
			get {
				return this.aspFile;
			}
			set {
				this.aspFile = StringUtils.NonEmptyOrNull (value);
				this.aspContent = null;
			}
		}

		public string AspContent {
			get {
				return this.generateAspContent ();
			}
		}

		public string HookContent {
			get {
				return this.generateHookContent ();
			}
		}

		public ProgramManager () {
			this.Time = Time;
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
					"document-size=",
					"The size of the document (for instance the size of the resulting pdf).",
					x => this.DocumentSize = DocumentSize.Parse (x)
				}, {
					"g|geometry=",
					"The geometry of the document (in case one works with chapters).",
					x => this.Geometry = Geometry.Parse (x)
				}
			};
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

		public void CheckConsistency () {
			if (this.HelpOrLists) {
				return;
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
		}

		public Stream GetIdpStream () {
			if (this.Interactive) {
				return File.Open (this.idpFile, FileMode.Open, FileAccess.ReadWrite);
			} else {
				throw new IdpGieException ("Cannot alter the Idp file, running the program in noninteractive mode.");
			}
		}

		public void Run (string[] args) {
			options.Parse (args);
			this.CheckConsistency ();

			if (this.HelpOrLists) {
				if (this.ShowHelp) {
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
				Application.Init ("idpgie", ref args);
				Gdk.Threads.Init ();
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
				OutputDevice dev = OutputDevice.CreateDevice (this.OutputMode, dt);
				dev.Run (this);
			}
		}

		public static int Main (string[] args) {
			Catalog.Init ("IdpGie", "./locale");
			OutputDevice.AnalyzeAssembly (Assembly.GetExecutingAssembly ());
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