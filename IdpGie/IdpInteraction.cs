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
		public int nbmodels = 0;

		public IdpInteraction () {
		}

		public IdpSession Runfile (string file) {
			return new IdpSession (this, file);
		}

		public class IdpSession {
			private readonly Process process;
			private readonly StreamWriter stdin;
			private readonly StreamReader stdout, stderr;

			public IdpSession (IdpInteraction interaction, string filename) {
				this.process = Process.Start (interaction.IdpExecutable, string.Format ("-i {0}", file));
				this.stdin = this.process.StandardInput;
				this.stdout = this.process.StandardOutput;
				this.stderr = this.process.StandardError;
			}

			public void ReadIn (string text) {
				stdin.Write (text);
				stdin.Flush ();
			}
		}
	}
}