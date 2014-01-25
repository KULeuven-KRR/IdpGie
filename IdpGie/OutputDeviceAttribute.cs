using System;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Class)]
	public class OutputDeviceAttribute : Attribute, INameDescription {
		private readonly string name, description;

		#region IName implementation

		public string Name {
			get {
				return this.name;
			}
		}

		#endregion

		#region IDescription implementation

		public string Description {
			get {
				return description;
			}
		}

		#endregion

		public OutputDeviceAttribute (string name, string description = "No description available") {
			this.name = name;
			this.description = description;
		}
	}
}