using System;
using System.IO;

namespace IdpGie {
	public class IdpInteractiveStream : IContentChangeableStream {
		private readonly IdpInteraction inter;
		private readonly IdpInteraction.IdpSession ses;
		private MemoryStream strm;
		private readonly string aspContent, hookContent;

		#region IContentChangeableStream implementation

		public event EventHandler Changed;

		public Stream Stream {
			get {
				return this.strm;
			}
			set {
				throw new NotSupportedException ("Cannot set the stream.");
			}
		}

		#endregion

		public IdpInteractiveStream (string idpFile, string theory, string structure, string aspContent, string hookContent) {
			inter = new IdpInteraction ();
			this.ses = inter.RunIdpfile (idpFile, theory, structure);
			this.aspContent = aspContent;
			this.hookContent = hookContent;
			this.regenerateModel ();
		}

		private void regenerateModel () {
			MemoryStream tmp = new MemoryStream ();
			StreamWriter sw = new StreamWriter (tmp);
			string text = inter.TranslateClingo (ses.EchoModel (), aspContent).Replace (" ", ".\n") + hookContent;
			text = text.Substring (0x00, text.Length);
			sw.Write (text);
			sw.Flush ();
			tmp.Position = 0x00;
			MemoryStream old = this.strm;
			this.strm = tmp;
			if (old != null) {
				old.Dispose ();
			}
		}
	}
}

