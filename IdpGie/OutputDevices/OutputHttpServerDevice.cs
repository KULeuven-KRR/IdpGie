//
//  OutputHttpServerDevice.cs
//
//  Author:
//       Willem Van Onsem <Willem.VanOnsem@cs.kuleuven.be>
//
//  Copyright (c) 2014 Willem Van Onsem
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

using IdpGie.Core;
using IdpGie.Engines;
using IdpGie.OutputDevices.Web;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Web;

namespace IdpGie.OutputDevices {

	[OutputDevice ("httpserver", "A HTTP server that runs on a specified port and handle user request using AJAX.")]
	public class OutputHttpServerDevice : OutputDevice, IHttpGieServer {
		private int port;
		private TcpListener listener;
		private INavbar navbar;

		public INavbar Navigationbar {
			get {
				return this.navbar;
			}
		}

		public OutputHttpServerDevice (DrawTheory dt, IProgramManager manager) : base (dt,manager) {
			string navbarfile = Path.Combine (manager.ServerFolder, "navbar.idpml");
			if (File.Exists (navbarfile)) {
				this.navbar = Navbar.FromStream (navbarfile);
			} else {
				throw new ArgumentException ("The navbar file does not exists!");
			}
		}

		#region implemented abstract members of OutputDevice

		public override void Run () {
			this.port = this.Manager.Port;
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