using System;
using System.Web;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using IdpGie.Core;
using IdpGie.Engines;

namespace IdpGie.OutputDevices {
	[OutputDevice ("httpserver", "A HTTP server that runs on a specified port and handle user request using AJAX.")]
	public class OutputHttpServerDevice : OutputDevice, IHttpGieServer {
		private int port;
		private TcpListener listener;

		public OutputHttpServerDevice (DrawTheory dt) : base (dt) {
		}

		#region implemented abstract members of OutputDevice

		public override void Run (ProgramManager manager) {
			this.port = manager.Port;
			Thread thread = new Thread (this.Listen);
			thread.Start ();
		}

		#endregion

		public void Listen () {
			this.listener = new TcpListener (IPAddress.Loopback, this.port);
			this.listener.Start ();
			while (true) {
				TcpClient s = listener.AcceptTcpClient ();
				HttpEngine pr = new HttpEngine (s, this);
				Thread thread = new Thread (new ThreadStart (pr.Process));
				thread.Start ();
				Thread.Sleep (1);
			}
		}

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
				return true;
			}
		}

		#endregion

	}
}

