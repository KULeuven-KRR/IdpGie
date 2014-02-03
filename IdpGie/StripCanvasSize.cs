using System;
using Gdk;

namespace IdpGie {
	public class StripCanvasSize : ICanvasSize {
		public CanvasSize Size;
		public StripGeometry Geometry;

		public StripCanvasSize (CanvasSize size, StripGeometry geometry) {
			this.Size = size;
			this.Geometry = geometry;
		}
	}
}

