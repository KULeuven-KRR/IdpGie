using System;

namespace IdpGie {
	[OutputDevice ("pdfstrip", "Prints the content of a all timeframes as a strip using a pdf stream.")]
	public class OutputPdfStripDevice : OutputDevice {
		public OutputPdfStripDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {

		}

		#endregion

	}
}