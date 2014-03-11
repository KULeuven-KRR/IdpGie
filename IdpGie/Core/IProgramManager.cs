//
//  IProgramManager.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System.Collections.Generic;
using System.IO;
using IdpGie.Abstract;
using IdpGie.Geometry;

namespace IdpGie.Core {

	/// <summary>
	/// An interface defining the program manager, a manager that stores the arguments of the program and interacts with the user.
	/// </summary>
	public interface IProgramManager : IValidate {

		StripGeometry Geometry {
			get;
			set;
		}

		bool Interactive {
			get;
		}

		CanvasSize CanvasSize {
			get;
			set;
		}

		IEnumerable<string> InputFiles {
			get;
		}

		string IdpFile {
			get;
			set;
		}

		double Time {
			get;
			set;
		}

		string OutputFile {
			get;
			set;
		}

		string HookFile {
			get;
			set;
		}

		string Theory {
			get;
			set;
		}

		string OutputMode {
			get;
			set;
		}

		string Structure {
			get;
			set;
		}

		string Vocabulary {
			get;
			set;
		}

		string IdpdFile {
			get;
			set;
		}

		bool ShowHelp {
			get;
			set;
		}

		bool ListDevices {
			get;
			set;
		}

		bool ListPaints {
			get;
			set;
		}

		bool ListHooks {
			get;
			set;
		}

		bool HelpOrLists {
			get;
		}

		string AspFile {
			get;
			set;
		}

		string AspContent {
			get;
		}

		string HookContent {
			get;
		}

		int Port {
			get;
			set;
		}

		StripCanvasSize GenerateStripCanvasSize (int size);

		Stream GetIdpStream ();

		void Run (string[] args);

	}
}

