using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace IdpGie {
	[XmlType ("Interaction")]
	public class IdpInteraction {
		[XmlAttribute ("Idp")]
		public string IdpExecutable = @"/home/kommusoft/idp/bin/idp";
		[XmlAttribute ("Gringo")]
		public string GringoExecutable = @"gringo";
		[XmlAttribute ("Clang")]
		public string ClangExecutable = @"clang";
		[XmlAttribute ("Xsb")]
		public bool Xsb = false;
		[XmlAttribute ("Groundwithbounds")]
		public bool Groundwithbounds = false;
		[XmlAttribute ("Liftedunitpropagation")]
		public bool Liftedunitpropagation = false;
		[XmlAttribute ("Nbmodels")]
		public int Nbmodels = 0;

		public IdpInteraction () {
		}

		public IdpSession RunIdpfile (string file, string theory, string structure) {
			return new IdpSession (this, file, theory, structure);
		}

		public class IdpSession {
			private readonly Process process;
			private readonly StreamWriter stdin;
			private readonly StreamReader stdout, stderr;
			private readonly string theory, structure;

			public IdpSession (IdpInteraction interaction, string filename, string theory, string structure) {
				this.process = Process.Start (interaction.IdpExecutable, string.Format ("--nowarnings -i {0}", filename));
				this.stdin = this.process.StandardInput;
				this.stdin.AutoFlush = false;
				this.stdin.WriteLine ("stdoptions.xsb={0}", interaction.Xsb.ToString ().ToLower ());
				this.stdin.WriteLine ("stdoptions.groundwithbounds={0}", interaction.Groundwithbounds.ToString ().ToLower ());
				this.stdin.WriteLine ("stdoptions.liftedunitpropagation={0}", interaction.Liftedunitpropagation.ToString ().ToLower ());
				this.stdin.WriteLine ("stdoptions.nbmodels={0}", interaction.Nbmodels);
				this.stdin.Flush ();
				this.stdout = this.process.StandardOutput;
				this.stderr = this.process.StandardError;
				this.theory = theory;
				this.structure = structure;
			}

			public void ReadIn (string text) {
				stdin.Write (text);
				stdin.Flush ();
			}

			public string EchoModel () {
				this.stdin.WriteLine ("stdoptions.language=\"asp\"");
				this.stdin.WriteLine ("cs = calculatedefinitions({0},{1})", this.theory, this.structure);
				this.stdin.WriteLine ("ps, a, b, iv = initialise({0},cs)", this.theory);
				this.stdin.WriteLine ("struc = ps[1]");
				this.stdin.WriteLine ("tostring (struc)");
				this.stdin.Flush ();
				return stdout.ReadToEnd ();
			}
		}
	}
}