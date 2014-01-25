using System;
using Cairo;

namespace IdpGie {
	[OutputDevice ("pdfstream", "Prints the content of a single timeframe as a pdf stream.")]
	public class OutputPdfDevice : OutputDevice {
		public OutputPdfDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, 1000.0d, 1000.0d)) {
				using (Context ctx = new Context (surface)) {
					this.Theory.Time = manager.Time;
					CairoEngine engine = new CairoEngine (this.Theory);
					engine.Context = ctx;
					engine.Render ();
				}
			}
		}

		#endregion

	}
}