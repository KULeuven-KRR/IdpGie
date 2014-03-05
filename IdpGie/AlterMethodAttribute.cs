using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IdpGie.Mappers {
	[AttributeUsage (AttributeTargets.Method)]
	public class AlterMethodAttribute : MethodBaseAttribute {

		#region implemented abstract members of MethodBaseAttribute

		public override string Stem {
			get {
				return "idpa_";
			}
		}

		#endregion

		public AlterMethodAttribute (string name, params TermType[] types) : this (name, 1.0d, types) {
		}

		public AlterMethodAttribute (string name, string description, params TermType[] types) : this (name, description, 1.0d, types) {
		}

		public AlterMethodAttribute (string name, double priority = 1.0d, params TermType[] types) : base (name, priority, types) {
		}

		public AlterMethodAttribute (string name, string description, double priority = 1.0d, params TermType[] types) : base (name, description, priority, types) {
		}

		public IEnumerable<TypedMethodPredicate> Predicates (MethodInfo mi) {
			double pr = this.Priority;
			string stem = this.StemName;
			List<TermType> tt = this.Types.ToList ();
			yield return new TypedMethodPredicate (stem, tt, mi, pr);
		}
	}
}
