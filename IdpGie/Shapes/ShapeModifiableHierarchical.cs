//
//  ShapeModifiableHierarchical.cs
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
using IdpGie.Logic;

namespace IdpGie.Shapes {
	public class ShapeModifiableHierarchical<TShapeState> : ShapeHierarchical<TShapeState>, IShapeModifiableHierarchical where TShapeState : IShapeState, new() {

		private readonly LinkedList<IShape> children = new LinkedList<IShape> ();

		#region implemented abstract members of IdpGie.Shapes.ShapeHierarchical
		public override IEnumerable<IShape> Children {
			get {
				return this.children;
			}
		}
		#endregion

		protected ShapeModifiableHierarchical (IFunctionInstance name) : base(name) {
		}

		protected ShapeModifiableHierarchical (IFunctionInstance name, IShapeHierarchical parent) : base(name,parent) {
		}

		#region IShapeModifiableHierarchical implementation
		public void AddChild (IShape child) {
			this.children.AddLast (child);
		}

		public void RemoveChild (IShape child) {
			this.children.Remove (child);
		}
		#endregion


		public override void RegisterChild (IShapeHierarchical child) {
			if (child != null && child.Parent == this) {
				this.children.AddLast (child);
			}
			base.RegisterChild (child);
		}

		public override void UnregisterChild (IShapeHierarchical child) {
			if (child != null && child.Parent == null) {
				this.children.Remove (child);
			}
			base.RegisterChild (child);
		}

	}
}

