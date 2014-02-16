using System;
using System.Web;

namespace IdpGie {
	[OutputDevice ("httpserver", "A HTTP server that runs on a specified port and handle user request using AJAX.")]
	public class OutputHttpServerDevice : OutputDevice, IHttpGieServer {
		public OutputHttpServerDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			throw new NotImplementedException ();
		}

		#endregion

		#region IHttpHandler implementation

		public void ProcessRequest (HttpContext context) {
			throw new NotImplementedException ();
		}

		public bool IsReusable {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

	}
}

