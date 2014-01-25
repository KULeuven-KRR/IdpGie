using System;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Class)]
	public class OutputDeviceAttribute : Attribute, IName {
		private readonly string name;

		#region IName implementation

		public string Name {
			get {
				return this.name;
			}
		}

		#endregion

		public OutputDeviceAttribute (string name) {
			this.name = name;
		}
	}
}