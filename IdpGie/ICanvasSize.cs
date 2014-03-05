using System;

namespace IdpGie.UserInterface {
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

		double StrideWidth {
			get;
		}

		double StrideHeight {
			get;
		}

		double Margin {
			get;
			set;
		}

		Point GetCanvasOffset (int index);
	}
}

