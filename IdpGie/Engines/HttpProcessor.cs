using System;
using System.Net.Sockets;
using System.Web;
using System.IO;
using System.Text;
using System.Net;
using System.Web.UI;
using IdpGie.Core;
using IdpGie.OutputDevices;

namespace IdpGie.Engines {
	public class HttpProcessor {
		private readonly TcpClient client;
		private readonly OutputHttpServerDevice device;

		public HttpProcessor (TcpClient client, OutputHttpServerDevice device) {
			this.client = client;
			this.device = device;
		}

		public void WriteHeader (Html32TextWriter htw) {
			htw.RenderBeginTag (HtmlTextWriterTag.Title);
			htw.Write (this.device.Theory.Name);
			htw.RenderEndTag ();
			htw.AddAttribute (HtmlTextWriterAttribute.Name, "generator");
			htw.AddAttribute (HtmlTextWriterAttribute.Content, ProgramManager.ProgramNameVersion);
			htw.RenderBeginTag (HtmlTextWriterTag.Meta);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Name, "viewport");
			htw.AddAttribute (HtmlTextWriterAttribute.Content, "width=device-width, initial-scale=1.0");
			htw.RenderBeginTag (HtmlTextWriterTag.Meta);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Href, "https://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css");
			htw.AddAttribute (HtmlTextWriterAttribute.Rel, "stylesheet");
			htw.RenderBeginTag (HtmlTextWriterTag.Link);
			htw.RenderEndTag ();
			htw.AddAttribute (HtmlTextWriterAttribute.Type, "text/css");
			//htw.RenderBeginTag (HtmlTextWriterTag.Style);
			//htw.WriteLine ("\nbody {\npadding-top: 20px;\npadding-bottom: 60px;\n}\n.container {\nmargin: 0 auto;\nmax-width: 1000px;\n}\n.container > hr {\nmargin: 60px 0;\n}\n.jumbotron {\nmargin: 80px 0;\ntext-align: center;\n}\n.jumbotron h1 {\nfont-size: 100px;\nline-height: 1;\n}\n.jumbotron .lead {\nfont-size: 24px;\nline-height: 1.25;\n}\n.jumbotron .btn {\nfont-size: 21px;\npadding: 14px 24px;\n}\n.marketing {\nmargin: 60px 0;\n}\n.marketing p + h4 {\nmargin-top: 28px;\n}\n.navbar .navbar-inner {\npadding: 0;\n}\n.navbar .nav {\nmargin: 0;\ndisplay: table;\nwidth: 100%;\n}\n.navbar .nav li {\ndisplay: table-cell;\nwidth: 1%;\nfloat: none;\n}\n.navbar .nav li a {\nfont-weight: bold;\ntext-align: center;\nborder-left: 1px solid rgba(255,255,255,.75);\nborder-right: 1px solid rgba(0,0,0,.1);\n}\n.navbar .nav li:first-child a {\nborder-left: 0;\nborder-radius: 3px 0 0 3px;\n}\n.navbar .nav li:last-child a {\nborder-right: 0;\nborder-radius: 0 3px 3px 0;\n}");
			//htw.RenderEndTag ();
			htw.WriteLine ();
		}

		public void WriteMasthead (Html32TextWriter htw) {
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "masthead");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "muted");
			htw.RenderBeginTag (HtmlTextWriterTag.H3);
			htw.Write (this.device.Theory.Name);
			htw.RenderEndTag ();
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar-inner");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "container");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "nav");
			htw.RenderBeginTag (HtmlTextWriterTag.Ul);

			htw.AddAttribute (HtmlTextWriterAttribute.Class, "active");
			htw.RenderBeginTag (HtmlTextWriterTag.Li);
			htw.AddAttribute (HtmlTextWriterAttribute.Href, "#");
			htw.RenderBeginTag (HtmlTextWriterTag.A);
			htw.Write ("Home");
			htw.RenderEndTag ();
			htw.RenderEndTag ();

			htw.RenderBeginTag (HtmlTextWriterTag.Li);
			htw.AddAttribute (HtmlTextWriterAttribute.Href, "#");
			htw.RenderBeginTag (HtmlTextWriterTag.A);
			htw.Write ("About");
			htw.RenderEndTag ();
			htw.RenderEndTag ();

			htw.RenderBeginTag (HtmlTextWriterTag.Li);
			htw.AddAttribute (HtmlTextWriterAttribute.Href, "#");
			htw.RenderBeginTag (HtmlTextWriterTag.A);
			htw.Write ("Contact");
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.RenderBeginTag (HtmlTextWriterTag.Hr);
			htw.RenderEndTag ();
		}

		public void WriteBody (Html32TextWriter htw) {
			this.WriteMasthead (htw);
		}

		public void WriteFooter (Html32TextWriter htw) {
			htw.RenderBeginTag (HtmlTextWriterTag.Hr);
			htw.RenderEndTag ();
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "footer");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.RenderBeginTag (HtmlTextWriterTag.P);
			htw.Write ("This page is created with {0}", ProgramManager.ProgramNameVersion);
			htw.RenderEndTag ();
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
			htw.WriteLine ();
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
				Console.WriteLine (http_filename);
				using (StreamWriter sw = new StreamWriter (client.GetStream ())) {
					using (Html32TextWriter tw = new Html32TextWriter (sw)) {
						tw.WriteLine ("<!DOCTYPE html>");
						tw.RenderBeginTag (HtmlTextWriterTag.Html);
						tw.RenderBeginTag (HtmlTextWriterTag.Head);
						this.WriteHeader (tw);
						tw.RenderEndTag ();
						tw.RenderBeginTag (HtmlTextWriterTag.Body);
						tw.AddAttribute (HtmlTextWriterAttribute.Class, "container");
						tw.RenderBeginTag (HtmlTextWriterTag.Div);
						this.WriteBody (tw);
						this.WriteFooter (tw);
						tw.RenderEndTag ();
						tw.RenderEndTag ();
						tw.RenderEndTag ();
						tw.Close ();
					}
					sw.Close ();
				}
			}
		}
	}
}

