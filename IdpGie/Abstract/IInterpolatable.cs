//
//  IInterpolatable.cs
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

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface specifying that a certain action can be interpolated.
	/// </summary>
	/// <remark>
	/// By interpolating, we mean that given an action that modifies an object from state <c>s1</c> to <c>s2</c>,
	/// there is a method to modify the object to state <c>s(t)</c> with <c>0 &lt;= t &lt; 1</c> where <c>s(0)=s0</c>,
	/// <c>s(1)=s1</c> and  where <c>s(t)</c> some meaningful state in between.
	/// </remark>
	public interface IInterpolatable {

		/// <summary>
		/// Gets a value indicating whether this instance can be interpolated.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance can be interpolated; otherwise, <c>false</c>.
		/// </value>
		bool CanInterpolate {
			get;
		}

	}

}

