using System;
using Cairo;
using System.Collections.Generic;
using IdpGie.Core;
using IdpGie.Engines;
using IdpGie.Geometry;

namespace IdpGie.OutputDevices {
	[OutputDevice ("pdfstrip", "Prints the content of a all timeframes as a strip using a pdf stream.")]
	public class OutputPdfStripDevice : OutputDevice {
		public OutputPdfStripDevice (DrawTheory dt, IProgramManager manager) : base (dt,manager) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run () {
			ICollection<double> chapters = this.Theory.Chapters;
			StripCanvasSize scs = this.Manager.GenerateStripCanvasSize (chapters.Count);
			double dw = scs.CanvasSize.Width;
			double dh = scs.CanvasSize.Height;
			using (PdfSurface surface = new PdfSurface (this.Manager.OutputFile, scs.TotalWidth, scs.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					int index = 0x00;
					IPoint3 p;
					foreach (double chapter in chapters) {
						p = scs.GetCanvasOffset (index);
						ctx.Save ();
						ctx.Translate (p.X, p.Y);
						ctx.Rectangle (0.0d, 0.0d, dw, dh);
						ctx.Stroke ();
						this.Theory.Time = chapter;
						CairoEngine engine = new CairoEngine (this.Theory);
						engine.Context = ctx;
						engine.Process ();
						ctx.Restore ();
						index++;
					}
				}
			}
		}

		#endregion

	}
}