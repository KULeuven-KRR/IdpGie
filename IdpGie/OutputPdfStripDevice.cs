using System;
using Cairo;

namespace IdpGie {
	[OutputDevice ("pdfstrip", "Prints the content of a all timeframes as a strip using a pdf stream.")]
	public class OutputPdfStripDevice : OutputDevice {
		public OutputPdfStripDevice (DrawTheory dt) : base (dt) {
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