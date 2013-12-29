using System;
using System.Collections.Generic;
using Cairo;

namespace IdpGie {
	public class ShapeSvgPath : Shape {
		private readonly LinkedList<SvgInstruction> instructions = new LinkedList<SvgInstruction> ();

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

		private abstract class SvgInstruction {
			public abstract void Execute (Context ctx);
		}

		private abstract class SvgInstructionP : SvgInstruction {
			public readonly Point P0;

			public SvgInstructionP (Point p0) {
				this.P0 = p0;
			}

			public SvgInstructionP (double x, double y) : this (new Point (x, y)) {
			}
		}

		private abstract class SvgInstruction2P : SvgInstructionP {
			public readonly Point P1;

			public SvgInstruction2P (Point p0, Point p1) : base (p0) {
				this.P1 = p1;
			}

			public SvgInstruction2P (double x, double y, double x1, double y1) : this (new Point (x, y), new Point (x1, y1)) {
			}
		}

		private abstract class SvgInstruction3P : SvgInstruction2P {
			public readonly Point P2;

			public SvgInstruction3P (Point p0, Point p1, Point p2) : base (p0, p1) {
				this.P2 = p2;
			}

			public SvgInstruction3P (double x, double y, double x1, double y1, double x2, double y2) : this (new Point (x, y), new Point (x1, y1), new Point (x2, y2)) {
			}
		}

		private sealed class SvgAInstruction : SvgInstruction2P {
			public readonly double XAxisRotation;
			public readonly bool LargeArc, Sweep;

			public SvgAInstruction (Point p0, double xAxisRotation, bool largeArc, bool sweep, Point p1) : base (p0, p1) {
				this.XAxisRotation = xAxisRotation;
				this.LargeArc = largeArc;
				this.Sweep = sweep;
			}

			public SvgAInstruction (double x, double y, double xAxisRotation, bool largeArc, bool sweep, double x1, double y1) : this (new Point (x, y), xAxisRotation, largeArc, sweep, new Point (x1, y1)) {
			}

			#region SvgInstruction implementation

			public override void Execute (Context ctx) {
			}

			#endregion

		}

		private sealed class SvgCInstruction : SvgInstruction3P {
			public SvgCInstruction (Point p0, Point p1, Point p2) : base (p0, p1, p2) {
			}

			public SvgCInstruction (double x, double y, double x1, double y1, double x2, double y2) : base (x, y, x1, y1, x2, y2) {
			}

			#region SvgInstruction implementation

			public override void Execute (Context ctx) {
				ctx.CurveTo (this.P0, this.P1, this.P2);
			}

			#endregion

		}

		private sealed class SvgLInstruction : SvgInstructionP {
			public SvgLInstruction (double x, double y) : base (x, y) {
			}

			public SvgLInstruction (Point p0) : base (p0) {
			}

			#region SvgInstruction implementation

			public override void Execute (Context ctx) {
				ctx.LineTo (this.P0);
			}

			#endregion

		}

		private sealed class SvgMInstruction : SvgInstructionP {
			public SvgMInstruction (double x, double y) : base (x, y) {
			}

			public SvgMInstruction (Point p0) : base (p0) {
			}

			#region SvgInstruction implementation

			public override void Execute (Context ctx) {
				ctx.MoveTo (this.P0);
			}

			#endregion

		}

		private sealed class SvgZInstruction : SvgInstruction {

			#region SvgInstruction implementation

			public override void Execute (Context ctx) {
				ctx.ClosePath ();
				ctx.NewPath ();
			}

			#endregion

		}
		/*private enum SvgInstruction : byte {
			A = 0x70,
			H = 0x10,
			L = 0x21,
			M = 0x20,
			Q = 0x40,
			V = 0x11,
			Z = 0x0f
		}*/
	}
}

