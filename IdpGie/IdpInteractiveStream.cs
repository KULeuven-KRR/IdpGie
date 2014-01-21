using System;
using System.IO;

namespace IdpGie {
	public class IdpInteractiveStream : ContentChangeableStreamBase<MemoryStream> {
		private readonly IdpInteraction inter;
		private readonly IdpInteraction.IdpSession ses;
		private readonly string aspContent, hookContent;

		#region IContentChangeableStream implementation

		#endregion

		public IdpInteractiveStream (string idpFile, string theory, string structure, string aspContent, string hookContent) : base (null) {
			Console.WriteLine ("bla {0} {1} {2} {3} {4}", idpFile, theory, structure, aspContent, hookContent);
			inter = new IdpInteraction ();
			this.ses = inter.RunIdpfile (idpFile, theory, structure);
			this.aspContent = aspContent;
			this.hookContent = hookContent;
			this.regenerateModel ();
		}

		private void regenerateModel () {
			string text = ses.EchoModel ();
			Console.WriteLine ("EM\n" + text);
			text = inter.TranslateClingo (text, aspContent).Replace (" ", ".\n") + hookContent;
			Console.WriteLine (text);
			MemoryStream tmp = new MemoryStream ();
			StreamWriter sw = new StreamWriter (tmp);
			sw.Write (text);
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

