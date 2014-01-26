//
//  IdpdHookMethodAttribut.cs
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
using System.Reflection;
using System.Linq;

namespace IdpGie {
	[AttributeUsage (AttributeTargets.Method)]
	public class HookMethodAttribute : MethodBaseAttribute {

		#region implemented abstract members of MethodBaseAttribute

		public override string Stem {
			get {
				return "idph_";
			}
		}

		#endregion

		public HookMethodAttribute (string name, double priority = 1000.0d, params TermType[] types) : base (name, priority, types) {
		}

		public HookMethodAttribute (string name, string description, double priority = 1000.0d, params TermType[] types) : base (name, description, priority, types) {
		}

		public IEnumerable<HookMethodPredicate> Predicates (MethodInfo mi) {
			double pr = this.Priority;
			string stem = this.StemName;
			List<TermType> tt = this.Types.ToList ();
			yield return new HookMethodPredicate (stem, tt, mi, pr);
		}
	}
}

