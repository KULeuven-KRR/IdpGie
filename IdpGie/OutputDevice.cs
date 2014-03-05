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
using IdpGie.Core;
using IdpGie.Utils;

namespace IdpGie.OutputDevices {
	public abstract class OutputDevice : IOutputDevice {
		private readonly DrawTheory theory;
		private readonly static Dictionary<string,Tuple<string,ConstructorInfo>> constructors = new Dictionary<string, Tuple<string,ConstructorInfo>> ();

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
					ConstructorInfo ci = type.GetConstructor (new Type[] { typeof(DrawTheory) });
					if (ci != null) {
						foreach (OutputDeviceAttribute oda in type.GetCustomAttributes (typeof(OutputDeviceAttribute),false).Cast<OutputDeviceAttribute>()) {
							string name = oda.Name.Trim ().ToLower ();
							string desc = oda.Description;
							constructors.Add (name, new Tuple<string,ConstructorInfo> (desc, ci));
						}
					}
				}
			}
		}

		public static IEnumerable<Tuple<string,string>> ListDevices () {
			foreach (KeyValuePair<string,Tuple<string,ConstructorInfo>> kvp in constructors) {
				yield return new Tuple<string,string> (kvp.Key, kvp.Value.Item1);
			}
		}

		public static OutputDevice CreateDevice (string name, DrawTheory theory) {
			Tuple<string,ConstructorInfo> ci;
			if (constructors.TryGetValue (name.Trim ().ToLower (), out ci)) {
				return (OutputDevice)ci.Item2.Invoke (new object[] { theory });
			} else {
				throw new IdpGieException ("Cannot find the appropriate output device \"{0}\". Run `idp --list-devices' for a list of installed devices.", name);
			}
		}
	}
}