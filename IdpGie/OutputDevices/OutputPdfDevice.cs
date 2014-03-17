using System;
using Cairo;
using IdpGie.Core;
using IdpGie.Engines;
using IdpGie.Geometry;

namespace IdpGie.OutputDevices {
	[OutputDevice ("pdfstream", "Prints the content of a single timeframe as a pdf stream.")]
	public class OutputPdfDevice : OutputDevice {
		public OutputPdfDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			StripCanvasSize scs = manager.GenerateStripCanvasSize (0x01);
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, scs.TotalWidth, scs.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					IdpGie.Geometry.Point3 p = scs.GetCanvasOffset (0x00);
					ctx.Save ();
					ctx.Translate (p.X, p.Y);
					this.Theory.Time = manager.Time;
					CairoEngine engine = new CairoEngine (this.Theory);
					engine.Context = ctx;
					engine.Process ();
					ctx.Restore ();
				}
			}
		}

		#endregion

	}
}