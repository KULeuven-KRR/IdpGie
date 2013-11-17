//
//  ZIndexComparator.cs
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

namespace IdpGie.Utils {
	public class ZIndexComparator : IComparer<IZIndex> {
		public static readonly ZIndexComparator Instance = new ZIndexComparator ();

		private ZIndexComparator () {
		}

		#region IComparer implementation

		public int Compare (IZIndex x, IZIndex y) {
			if (x == null) {
				return 0x01;
			} else if (y == null) {
				return -0x01;
			} else {
				return x.ZIndex.CompareTo (y.ZIndex);
			}
		}

		#endregion

	}
}