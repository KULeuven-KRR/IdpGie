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
			Console.WriteLine (scs.CanvasSize);
			Console.WriteLine (scs.StripGeometry);
			double dw = scs.CanvasSize.Width;
			double dh = scs.CanvasSize.Height;
			using (PdfSurface surface = new PdfSurface (manager.OutputFile, scs.TotalWidth, scs.TotalHeight)) {
				using (Context ctx = new Context (surface)) {
					int index = 0x00;
					IdpGie.Geometry.Point3 p;
					foreach (double chapter in chapters) {
						Console.WriteLine (index);
						p = scs.GetCanvasOffset (index);
						Console.WriteLine (p);
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