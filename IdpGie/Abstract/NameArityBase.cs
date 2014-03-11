//
//  NameArityBase.cs
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
	/// An implementation of the <see cref="INameArity"/> interface, used as a convenient stepup.
	/// </summary>
	public abstract class NameArityBase : NameBase, INameArity {

		private int arity;

        #region IArity implementation
		/// <summary>
		///  Gets the arity of this instance. 
		/// </summary>
		/// <value>
		///  The arity of this instance.
		/// </value>
		/// <remarks>
		/// <para>The arity of a function is the number of expected parameters.</para>
		/// <para>In case the instance is variadic, the value is set to a strictly negative number.</para>
		/// </remarks>
		public virtual int Arity {
			get {
				return this.arity;
			}
			protected set {
				this.arity = value;
			}
		}
        #endregion

        #region INameArity implementation
		/// <summary>
		///  Gets the signature of this instance. 
		/// </summary>
		/// <value>
		///  The signature of this instance.
		/// </value>
		/// <remarks>
		/// <para>The signature of a function is a tuple containing the name and arity of the function.</para>
		/// </remarks>
		public virtual Tuple<string, int> Signature {
			get {
				return new Tuple<string, int> (this.Name, this.Arity);
			}
		}
        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameArityBase"/> class with a given name and arity.
		/// </summary>
		/// <param name='name'>
		/// The name of the instance.
		/// </param>
		/// <param name='arity'>
		/// The arity of the instance.
		/// </param>
		protected NameArityBase (string name, int arity = 0x00) : base(name) {
			this.Arity = arity;
		}
	}
}

