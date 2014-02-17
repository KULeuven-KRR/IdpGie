using System;
using System.Net.Sockets;
using System.Web;
using System.IO;
using System.Text;
using System.Net;

namespace IdpGie {
	public class HttpProcessor {
		private readonly TcpClient client;
		private readonly IHttpHandler handler;

		public HttpProcessor (TcpClient client, IHttpHandler handler) {
			this.client = client;
			this.handler = handler;
		}

		public void process () {
			using (StreamReader inputStream = new StreamReader (client.GetStream ())) {
				String request = inputStream.ReadLine (), line;
				string[] tokens = request.Split (' ');
				if (tokens.Length != 3) {
					throw new Exception ("invalid http request line");
				}
				StringBuilder rest = new StringBuilder ();
				do {
					line = inputStream.ReadLine ();
					rest.AppendLine (line);
				} while(line != string.Empty && line != null);
				string http_url = tokens [1];
				string http_filename = tokens [1];
				/*Console.WriteLine (http_url);
				HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create (request);
				Console.WriteLine (hwr);*/
				StreamWriter sw = new StreamWriter (client.GetStream ());
				sw.WriteLine ("<html><body><h1>test server</h1>");
				sw.WriteLine ("Current Time: " + DateTime.Now.ToString ());
				sw.WriteLine ("url : {0}", "HURAY");
				sw.WriteLine ("<form method=post action=/form>");
				sw.WriteLine ("<input type=text name=foo value=foovalue>");
				sw.WriteLine ("<input type=submit name=bar value=barvalue>");
				sw.WriteLine ("</form>");
				sw.Close ();
				//HttpRequest rq = new HttpRequest (string.Empty, string.Empty, rest.ToString ());
				//HttpResponse rp = new HttpResponse (new StreamWriter (client.GetStream ()));
				//HttpContext ctx = new HttpContext (hwr, rp);
				//this.handler.ProcessRequest (ctx);
			}
		}
	}
}

