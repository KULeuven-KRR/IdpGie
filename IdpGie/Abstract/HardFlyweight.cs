//
//  HardFlyweight.cs
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
using System.Collections.Generic;

namespace IdpGie.Abstract {

	/// <summary>
	/// A generic flyweight pattern where all the generated instance are stored until the program exits.
	/// </summary>
	/// <typeparam name="TKey">
	/// The type of keys on which new object are generated and resulting object are associated with.
	/// </typeparam>
	/// <typeparam name="TValue">
	/// The type of objects generated and emitted by the flyweight.
	/// </typeparam>
	public class HardFlyweight<TKey,TValue> : IFlyweight<TKey,TValue> {

		private readonly Dictionary<TKey,TValue> cache = new Dictionary<TKey, TValue> ();
		private readonly Func<TKey,TValue> generator;

        #region IFlyWeight implementation
		/// <summary>
		/// Gets the generator that generates a new object in case the object is not generated yet.
		/// </summary>
		/// <value>
		/// The generator, a function that generates a new object in case no object has been generated for the given parameter.
		/// </value>
		public Func<TKey, TValue> Generator {
			get {
				return this.generator;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this flyweight is weak.
		/// </summary>
		/// <value>
		/// <c>true</c> if this flyweight is weak; otherwise, <c>false</c>.
		/// </value>
		/// <remarks>
		/// <para>This is a hard flyweight, thus this value is always <c>false</c>.</para>
		/// </remarks>
		public bool IsWeak {
			get {
				return false;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this <see cref="IdpGie.Abstract.HardFlyweight`2"/> supports <see cref="IDispose"/>.
		/// </summary>
		/// <value>
		/// <c>true</c> if this flyweight supports <see cref="IDispose"/>; otherwise, <c>false</c>.
		/// </value>
		/// <remarks>
		/// <para>This implementation of the <see cref="IFlyweight"/> pattern does not support <see cref="IDispose"/>, the value is always <c>False</c>.</para>
		/// </remarks>
		public bool DisposeSupport {
			get {
				return false;
			}
		}
        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.HardFlyweight`2"/> class with a given generator.
		/// </summary>
		/// <param name='generator'>
		/// The generator that generates a new instance in case no object for the given parameters has been generated yet.
		/// </param>
		public HardFlyweight (Func<TKey,TValue> generator) {
			this.generator = generator;
		}

        #region IFlyWeight implementation
		/// <summary>
		/// Gets a pointer to an earlier generated object associated with the given <paramref name="key"/>, otherwise uses the <see cref="IFlyweight.Generator"/> to generate
		/// a new object.
		/// </summary>
		/// <returns>
		/// A references to an earlier generated object, or the newly generated object.
		/// </returns>
		/// <param name='key'>
		/// The key on which an object is generated or associated.
		/// </param>
		public TValue GetOrCreate (TKey key) {
			TValue res;
			if (!this.cache.TryGetValue (key, out res)) {
				res = this.generator (key);
				this.cache.Add (key, res);
			}
			return res;
		}

		/// <summary>
		/// Checks if the flyweight contains an object associated with the given <paramref name="key"/>.
		/// </summary>
		/// <param name='key'>
		/// The given parameter.
		/// </param>
		/// <returns>
		/// <c>true</c> if the <see cref="IFlyweight"/> already contains an object associated with the given <paramref name="key"/>, <c>false</c> otherwise.
		/// </returns>
		/// <remarks>
		/// <para>In case of a hard flyweight, once an object is generated based on the given <paramref name="key"/>, this method will always return <c>true</c> for this key.</para>
		/// </remarks>
		public bool Contains (TKey key) {
			return this.cache.ContainsKey (key);
		}
        #endregion

	}
}

