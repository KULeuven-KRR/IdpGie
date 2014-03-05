using System;
using Cairo;
using System.Collections.Generic;
using IdpGie.Core;
using IdpGie.Engines;
using IdpGie.Geometry;

namespace IdpGie.OutputDevices {
	[OutputDevice ("pdfstrip", "Prints the content of a all timeframes as a strip using a pdf stream.")]
	public class OutputPdfStripDevice : OutputDevice {
		public OutputPdfStripDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			ICollection<double> chapters = this.Theory.Chapters;
			StripCanvasSize scs = manager.GenerateStripCanvasSize (chapters.Count);
			double dw = scs.StrideWidth;
			double dh = scs.StrideHeight;
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, scs.TotalWidth, scs.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					int index = 0x00;
					IdpGie.Geometry.Point p;
					foreach (double chapter in chapters) {
						p = scs.GetCanvasOffset (index);
						ctx.Save ();
						ctx.Translate (p.X, p.Y);
						ctx.Rectangle (0.0d, 0.0d, dw, dh);
						ctx.Stroke ();
						this.Theory.Time = chapter;
						CairoEngine engine = new CairoEngine (this.Theory);
						engine.Context = ctx;
						engine.Render ();
						ctx.Restore ();
						index++;
					}
				}
			}
		}

		#endregion

	}
}