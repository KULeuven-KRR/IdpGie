using System;
using Cairo;

namespace IdpGie {
	[OutputDevice ("pdfstream", "Prints the content of a single timeframe as a pdf stream.")]
	public class OutputPdfDevice : OutputDevice {
		public OutputPdfDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, manager.DocumentSize.TotalWidth, manager.DocumentSize.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					ctx.Translate (manager.DocumentSize.Margin, manager.DocumentSize.Margin);
					ctx.Save ();
					this.Theory.Time = manager.Time;
					CairoEngine engine = new CairoEngine (this.Theory);
					engine.Context = ctx;
					engine.Render ();
					ctx.Restore ();
				}
			}
		}

		#endregion

	}
}