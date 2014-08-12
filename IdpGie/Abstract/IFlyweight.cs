//
//  IFlyweight.cs
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

using System;

namespace IdpGie.Abstract {

	/// <summary>
	/// An interface representing the basic functionality provided by a flyweight pattern.
	/// </summary>
	/// <remarks>
	/// <para>A flyweight pattern is used to reduce the memory footprint and sometimes the computation overhead (for instance to compare two objects).
	/// A drawback of the method is that the flyweight requires additional memory and the computational overhead when creating an object.</para>
	/// <para>We destinct two types of flyweights: <see cref="HardFlyweight"/> objects store objects until the program dies.<see cref="WeakFlyweight"/> objects
	/// are sensible to the garbage collector of the runtime environment.</para>
	/// </remarks>
	/// <typeparam name="TKey">
	/// The type of parameter from which objects are created.
	/// </typeparam>
	/// <typeparam name="TValue">
	/// The type of objects generated by the flyweight.
	/// </typeparam>
	public interface IFlyweight<TKey,TValue> {

		/// <summary>
		/// Gets the generator of the flyweight.
		/// </summary>
		/// <value>
		/// The generator of the flyweight. A function that generates a new object in case the flyweight does not contain an object associated with the given key.
		/// </value>
		Func<TKey,TValue> Generator {
			get;
		}

		/// <summary>
		/// Gets a value indicating whether this flyweight is weak.
		/// </summary>
		/// <value>
		/// <c>true</c> if the flyweight is weak; otherwise, <c>false</c>.
		/// </value>
		/// <remarks>
		/// <para>A flyweight is weak if it is sensitive to the garbage collector of the runtime environment.</para>
		/// </remarks>
		bool IsWeak {
			get;
		}

		/// <summary>
		/// Gets a value indicating whether this flyweight <see cref="IdpGie.Abstract.IFlyWeight`2"/> supports the <see cref="IDisposable"/> functionality.
		/// </summary>
		/// <value>
		/// <c>true</c> if the <see cref="IFlyweight'2"/> supports the <see cref="IDisposable"/> functionality; otherwise, <c>false</c>.
		/// </value>
		bool DisposeSupport {
			get;
		}

		/// <summary>
		/// Gets a reference to the object associated with the given key, in case such object is not known to the <see cref="IFlyweight"/>, it is generated with the <see cref="IFlyweight.Generator"/>
		/// </summary>
		/// <returns>
		/// A reference to the object associated with the given key, in case such object is not known to the <see cref="IFlyweight"/>, it is generated with the <see cref="IFlyweight.Generator"/> and a reference to the new object is returned.
		/// </returns>
		/// <param name='key'>
		/// The key based on which an object is generated and with which this object is associated.
		/// </param>
		TValue GetOrCreate (TKey key);

		/// <summary>
		/// Checks if the <see cref="IFlyweight"/> already contains a defintion for the given <paramref name="key"/>.
		/// </summary>
		/// <param name='key'>
		/// The key based on which an object is generated an with which this object is associated.
		/// </param>
		/// <returns>
		/// <c>true</c> if the <see cref="IFlyweight"/> contains an object associated with the given <paramref name="key"/>, <c>false</c> otherwise.
		/// </returns>
		bool Contains (TKey key);

	}

}