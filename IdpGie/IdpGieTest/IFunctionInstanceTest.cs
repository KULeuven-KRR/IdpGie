//
//  IFunctionInstanceTest.cs
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
using NUnit.Framework;
using IdpGie;

namespace IdpGieTest {
	[TestFixture ()]
	public class TermEqualityTest {
		[Test ()]
		public void TestCase () {
			Function teleport = new Function ("teleport", 0x02);
			Function wall = new Function ("wall", 0x03);
			Function l = new Function ("l", 0x00);
			IFunctionInstance fiaa = (IFunctionInstance)teleport.CreateInstance (new FunctionIntegerInstance ("3"), new FunctionIntegerInstance ("3"));
			IFunctionInstance fiab = (IFunctionInstance)teleport.CreateInstance (new FunctionIntegerInstance ("3"), new FunctionIntegerInstance ("3"));
			Assert.IsTrue (fiaa.Equals (fiab));
			FunctionInstance fiba = new FunctionInstance (wall, new FunctionIntegerInstance ("3"), new FunctionIntegerInstance ("3"), l.CreateInstance ());
			FunctionInstance fibb = new FunctionInstance (teleport, new FunctionIntegerInstance ("3"), new FunctionIntegerInstance ("3"));
		}
	}
}

