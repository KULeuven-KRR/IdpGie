//
//  IdpdOutputDevice.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IdpGie {
	public abstract class OutputDevice : IOutputDevice {
		private readonly DrawTheory theory;
		private readonly static Dictionary<string,ConstructorInfo> constructors = new Dictionary<string, ConstructorInfo> ();

		public DrawTheory Theory {
			get {
				return this.theory;
			}
		}

		protected OutputDevice (DrawTheory theory) {
			this.theory = theory;
		}

		public abstract void Run (ProgramManager manager);

		#region IDisposable implementation

		public virtual void Dispose () {
		}

		#endregion

		public static void AnalyzeAssembly (Assembly assembly) {
			foreach (Type type in assembly.GetTypes ()) {
				if (!type.IsAbstract && typeof(IOutputDevice).IsAssignableFrom (type)) {
					foreach (string name in type.GetCustomAttributes (typeof(OutputDeviceAttribute),false).Cast<OutputDeviceAttribute>().Select(x => x.Name.Trim ().ToLower ())) {
						constructors.Add (name, type.GetConstructor (new Type[] { typeof(DrawTheory) }));
					}
				}
			}
		}

		public static OutputDevice CreateDevice (string name, DrawTheory theory) {
			ConstructorInfo ci;
			if (constructors.TryGetValue (name.Trim ().ToLower (), out ci)) {
				return (OutputDevice)ci.Invoke (new object[] { theory });
			} else {
				throw new IdpGieException ("Cannot find the appropriate output device \"{0}\". Run `idp --list-devices' for a list of installed devices.", name);
			}
		}
	}
}