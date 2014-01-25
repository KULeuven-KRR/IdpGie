using System;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Class)]
	public class OutputDeviceAttribute : Attribute, IName {
		private readonly string name, description;

		#region IName implementation

		public string Name {
			get {
				return this.name;
			}
		}

		#endregion

		public string Description {
			get {
				return description;
			}
		}

		public OutputDeviceAttribute (string name, string description = "No description available") {
			this.name = name;
			this.description = description;
		}
	}
}