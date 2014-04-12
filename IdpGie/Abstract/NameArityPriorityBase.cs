//
//  NameArityPriorityBase.cs
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
	/// An implementation of the <see cref="INameArity"/> and <see cref="IPriority"/> interfaces. This class
	/// is provided as a convinient basic implementation.
	/// </summary>
	public abstract class NameArityPriorityBase : NameArityBase, INameArity, IPriority {

		private double priority;

        #region IPriority implementation
		/// <summary>
		///  Gets the priority of this object.
		/// </summary>
		/// <value>
		///  The priority of this object.
		/// </value>
		public virtual double Priority {
			get {
				return this.priority;
			}
			protected set {
				this.priority = value;
			}
		}
        #endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Abstract.NameArityPriorityBase"/> class with a given name, arity and priority.
		/// </summary>
		/// <param name='name'>
		/// The name of the object.
		/// </param>
		/// <param name='arity'>
		/// The arity of the object.
		/// </param>
		/// <param name='priority'>
		/// The priority of the object.
		/// </param>
		protected NameArityPriorityBase (string name, int arity = 0x00, double priority = 1.0d) : base(name,arity) {
			this.Priority = priority;
		}

	}

}

