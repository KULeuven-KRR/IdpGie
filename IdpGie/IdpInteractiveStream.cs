using System;
using System.IO;

namespace IdpGie {
	public class IdpInteractiveStream : AlterableContentChangeableStreamBase<MemoryStream,string> {
		private readonly IdpInteraction inter;
		private readonly IdpInteraction.IdpSession ses;
		private readonly string aspContent, hookContent;

		public IdpInteractiveStream (string idpFile, string theory, string structure, string vocabulary, string aspContent, string hookContent) : base (null) {
			inter = new IdpInteraction ();
			this.ses = inter.RunIdpfile (idpFile, theory, structure, vocabulary);
			this.aspContent = aspContent;
			this.hookContent = hookContent;
			this.regenerateModel ();
		}

		public override void Alter (string command) {
			ses.Execute (command);
			this.regenerateModel ();
			base.Alter (command);
		}

		private void regenerateModel () {
			string text = ses.EchoModel ();
			text = inter.TranslateClingo (text, aspContent).Replace (" ", ".\n") + hookContent;
			MemoryStream tmp = new MemoryStream ();
			StreamWriter sw = new StreamWriter (tmp);
			sw.WriteLine (text);
			Console.WriteLine (text);
			if (this.hookContent != null) {
				sw.WriteLine (this.hookContent);
			}
			sw.Flush ();
			tmp.Position = 0x00;
			MemoryStream old = this.Stream;
			this.Stream = tmp;
			if (old != null) {
				old.Dispose ();
			}
		}
	}
}

