using System;
using System.Net.Sockets;
using System.Web;
using System.IO;
using System.Text;

namespace IdpGie {
	public class HttpProcessor {
		private readonly TcpClient client;
		private readonly IHttpHandler handler;

		public HttpProcessor (TcpClient client, IHttpHandler handler) {
			this.client = client;
			this.handler = handler;
		}

		public void process () {
			Console.WriteLine ("HTTPPRocessor PROCESS");
			using (StreamReader inputStream = new StreamReader (client.GetStream ())) {
				Console.WriteLine ("FOO");
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
				string http_method = tokens [0].ToUpper ();
				string http_url = tokens [1];
				string http_filename = tokens [1];
				string http_protocol_versionstring = tokens [2];
				Console.WriteLine ("FOOBAR " + request);
				HttpRequest rq = new HttpRequest (http_filename, http_url, rest.ToString ());
				Console.WriteLine (rq);
			}
		}
	}
}

