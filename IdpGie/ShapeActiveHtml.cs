using System;
using System.Collections.Generic;

namespace IdpGie {

	public class ShapeActiveHtml : Shape {

		public override IEnumerable<KeyValueEntry> HtmlAttributes {
			get {
				return base.HtmlAttributes;
			}
		}

		private readonly List<ShapeActiveHtml> children = new List<ShapeActiveHtml>();

		public List<ShapeActiveHtml> Children {
			get {
				return this.children;
			}
		}

		//public XhtmlActiveShape

		public ShapeActiveHtml (IFunctionInstance name) : base(name) {

		}

	}
}

