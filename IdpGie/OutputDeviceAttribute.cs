using System;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Class)]
	public class OutputDeviceAttribute : NamedDescribedAttributeBase {
		public OutputDeviceAttribute (string name) : base (name) {
		}

		public OutputDeviceAttribute (string name, string description) : base (name, description) {
		}
	}
}