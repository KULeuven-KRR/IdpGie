using System;

namespace IdpGie {

	public class ShapeStateSetter : ShapeStateModifier {

		public ShapeStateSetter (double time, string key, object value) : base(time,x => x.SetElement(key,value)) {
		}

	}

}