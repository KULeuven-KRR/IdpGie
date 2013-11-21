//
//  TermConcept.cs
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

namespace IdpGie.Logic {

	/// <summary>
	/// Thy concept embodied by a specific term. This TermConcept denotes some properties of concepts (like peelable) as well.
	/// </summary>
	/// <remarks>
	/// The root properties are:
	/// <list type="bullet">
	/// <item>Predicate (1)</item>
	/// <item>Constant (2)</item>
	/// <item>Functor (4)</item>
	/// <item>Variable (8)</item>
	/// <item>Peelable (16)</item>
	/// </list>
	/// </remarks>
	[Flags]
	public enum TermConcept {
		Predicate	= 0x11,
		Functor = 0x04,
		ArFunctor	= 0x14,
		Constant	= 0x06,
		Variable	= 0x08,
		Peelable	= 0x10
	}
}

