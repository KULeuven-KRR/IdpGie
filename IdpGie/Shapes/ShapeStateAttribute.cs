using System;
using IdpGie.Abstract;

namespace IdpGie.Shapes {
	[AttributeUsage (AttributeTargets.Property)]
	public class ShapeStateAttribute : NamedAttributeBase {
		public ShapeStateAttribute (string name) : base (name) {
		}
	}
}

