using System;
using System.Collections.Generic;
using Cairo;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class ShapeSvgPath : Shape {
		private readonly LinkedList<byte> instructions = new LinkedList<byte> ();
		private readonly LinkedList<Point> pts;
		private static readonly Regex rgx = null;

		public ShapeSvgPath (IFunctionInstance name, string instructions) : base (name) {
			this.instructions.AddAll (this.parseInstructions (instructions));
		}

		private IEnumerable<SvgInstruction> parseInstructions (string instructions) {
			Point curPoint = new Point ();
			yield break;
		}

		protected override void InnerPaintObject (Context ctx) {
			foreach (SvgInstruction instruction in this.instructions) {
				instruction.Execute (ctx);
			}
			base.InnerPaintObject (ctx);
		}
	}
}

