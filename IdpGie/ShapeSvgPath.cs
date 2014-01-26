using System;
using System.Collections.Generic;
using Cairo;
using System.Text.RegularExpressions;

namespace IdpGie {
	public class ShapeSvgPath : Shape {
		private readonly LinkedList<byte> instructions = new LinkedList<byte> ();
		private readonly LinkedList<double> attributes;
		private static readonly Regex rgx = null;

		public ShapeSvgPath (IFunctionInstance name, string instructions) : base (name) {
			this.instructions.AddAll (this.parseInstructions (instructions));
		}

		private void parseInstructions (string instructions) {
			Point curPoint = new Point ();
			yield break;
		}

		private enum SvgInstruction : byte {

			#region 1var

			H = 0x10,
			Hr = 0x11,
			V = 0x12,
			Vr = 0x13,
			#endregion

			#region 2var

			M = 0x20,
			L = 0x21,
			Lr = 0x22,
			T = 0x23,
			Tr = 0x24,
			#endregion

			#region 4var

			Q = 0x40,
			Qr = 0x41,
			S = 0x42,
			Sr = 0x43,
			#endregion

			#region 6var

			C = 0x60,
			Cr = 0x61,
			#endregion

			#region 7var

			A = 0x71,
			Ar = 0x72,
			#endregion

		}

		protected override void InnerPaintObject (Context ctx) {
			foreach (SvgInstruction instruction in this.instructions) {
				//instruction.Execute (ctx);
			}
			base.InnerPaintObject (ctx);
		}
	}
}

