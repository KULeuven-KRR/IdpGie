using System;

namespace IdpGie {
	public interface ICanvasSize {
		double Width {
			get;
			set;
		}

		double TotalWidth {
			get;
		}

		double Height {
			get;
			set;
		}

		double TotalHeight {
			get;
		}

		double Margin {
			get;
			set;
		}
	}
}

