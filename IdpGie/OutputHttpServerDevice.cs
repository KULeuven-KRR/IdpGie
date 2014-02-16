using System;
using System.Web;
using System.IO;
using System.Net.Sockets;

namespace IdpGie {
	[OutputDevice ("httpserver", "A HTTP server that runs on a specified port and handle user request using AJAX.")]
	public class OutputHttpServerDevice : OutputDevice, IHttpGieServer {
		protected int port;
		TcpListener listener;

		public OutputHttpServerDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			throw new NotImplementedException ();
		}

		#endregion

		#region IHttpHandler implementation

		public void ProcessRequest (HttpContext context) {
			HttpRequest rq = context.Request;
			HttpResponse rp = context.Response;
			rp.StatusCode = 200;
			StreamWriter sw = new StreamWriter (rp.OutputStream);
			sw.WriteLine ("<html><body><h1>test server</h1>");
			sw.WriteLine ("Current Time: " + DateTime.Now.ToString ());
			sw.WriteLine ("url : {0}", rq.Url);
			sw.WriteLine ("<form method=post action=/form>");
			sw.WriteLine ("<input type=text name=foo value=foovalue>");
			sw.WriteLine ("<input type=submit name=bar value=barvalue>");
			sw.WriteLine ("</form>");
		}

		public bool IsReusable {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion

	}
}

