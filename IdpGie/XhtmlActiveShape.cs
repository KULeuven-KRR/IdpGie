using System;
using System.Collections.Generic;

namespace IdpGie {

	public class XhtmlActiveShape : Shape {

		public override IEnumerable<KeyValueEntry> XhtmlAttributes {
			get {
				return base.XhtmlAttributes;
			}
		}

		private readonly List<XhtmlActiveShape> children = new List<XhtmlActiveShape>();

		public List<XhtmlActiveShape> Children {
			get {
				return this.children;
			}
		}

		//public XhtmlActiveShape

		public XhtmlActiveShape (IFunctionInstance name) : base(name) {

		}

	}
}

