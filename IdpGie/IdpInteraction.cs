using System;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using IdpGie.Parser;
using System.Text;

namespace IdpGie {
	[XmlType ("Interaction")]
	public class IdpInteraction {
		[XmlAttribute ("Idp")]
		public string IdpExecutable = @"/home/kommusoft/idp/bin/idp";
		[XmlAttribute ("Gringo")]
		public string GringoExecutable = @"gringo";
		[XmlAttribute ("Clang")]
		public string ClangExecutable = @"clang";
		[XmlAttribute ("Clingo")]
		public string ClingoExecutable = @"clingo";
		[XmlAttribute ("Xsb")]
		public bool Xsb = false;
		[XmlAttribute ("Groundwithbounds")]
		public bool Groundwithbounds = false;
		[XmlAttribute ("Liftedunitpropagation")]
		public bool Liftedunitpropagation = false;
		[XmlAttribute ("Nbmodels")]
		public int Nbmodels = 0;
		[XmlAttribute ("Timeout")]
		public int Timeout = 0x1000;

		public IdpInteraction () {
		}

		public IdpSession RunIdpfile (string file, string theory, string structure) {
			return new IdpSession (this, file, theory, structure);
		}

		public string TranslateClingo (string original, string aspContent) {
			using (ClingoSession cs = new ClingoSession (this, aspContent, original)) {
				return cs.Output;
			}
		}

		public class ClingoSession : ProcessSession {
			public string Output {
				get {
					return this.Stdout.ReadToEnd ();
				}
			}

			public ClingoSession (IdpInteraction interaction, string aspContent, string inp) : base (interaction.ClingoExecutable, string.Format ("-n 1 --verbose=0")) {
				this.Stdin.Write (aspContent);
				this.Stdin.Write (inp);
				this.Stdin.Close ();
			}
		}

		public class IdpSession : ProcessSession {
			private readonly string theory, structure;

			public IdpSession (IdpInteraction interaction, string filename, string theory, string structure) : base (interaction.IdpExecutable, string.Format ("--nowarnings -i {0}", filename)) {
				this.Stdin.WriteLine ("stdoptions.xsb={0}", interaction.Xsb.ToString ().ToLower ());
				this.Stdin.WriteLine ("stdoptions.groundwithbounds={0}", interaction.Groundwithbounds.ToString ().ToLower ());
				this.Stdin.WriteLine ("stdoptions.liftedunitpropagation={0}", interaction.Liftedunitpropagation.ToString ().ToLower ());
				this.Stdin.WriteLine ("stdoptions.nbmodels={0}", interaction.Nbmodels);
				this.Stdin.Flush ();
				this.theory = theory;
				this.structure = structure;
			}

			public string EchoModel () {
				this.Stdin.WriteLine ("stdoptions.language=\"asp\"");
				this.Stdin.WriteLine ("cs = calculatedefinitions({0},{1})", this.theory, this.structure);
				this.Stdin.WriteLine ("ps, a, b, iv = initialise({0},cs)", this.theory);
				this.Stdin.WriteLine ("struc = ps[1]");
				this.Stdin.WriteLine (@"print(string.format(""\a%s\n\a"",tostring (struc)))");
				this.Stdin.Flush ();
				while (this.Stdout.Read () != 0x07)
					;
				StringBuilder sb = new StringBuilder ();
				while (this.Stdout.Peek () != 0x07) {
					sb.AppendLine (this.Stdout.ReadLine ());
				}
				return sb.ToString ();
			}
		}
	}
}