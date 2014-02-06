using System;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Property)]
	public class ShapeStateAttribute : NamedAttributeBase {
		public ShapeStateAttribute (string name) : base (name) {
		}
	}
}

