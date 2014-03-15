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
	public class HttpEngine : IWebEngine {
		private readonly TcpClient client;
		private readonly OutputHttpServerDevice device;

		#region IEngine implementation
		public IDrawTheory Theory {
			get;
			set;
		}
		#endregion

		public HttpEngine (TcpClient client, OutputHttpServerDevice device) {
			this.client = client;
			this.device = device;
			this.Theory = device.Theory;
		}

		public void Process () {
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
						this.WriteBody (tw);
						this.WriteJavascript (tw);
						tw.RenderEndTag ();
						tw.RenderEndTag ();
						tw.Close ();
					}
					sw.Close ();
				}
			}
		}

		public void WriteHeader (Html32TextWriter htw) {
			htw.RenderBeginTag (HtmlTextWriterTag.Title);
			htw.Write (this.Theory.Name);
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
			htw.Write ("body {min-height: 2000px;padding-top: 70px;}");
			htw.RenderEndTag ();
			htw.WriteLine ();
		}

		public void WriteMasthead (Html32TextWriter htw) {
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar navbar-default navbar-fixed-top");
			htw.AddAttribute ("role", "navigation");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			{
				htw.AddAttribute (HtmlTextWriterAttribute.Class, "container-fluid");
				htw.RenderBeginTag (HtmlTextWriterTag.Div);
				{
					htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar-header");
					htw.RenderBeginTag (HtmlTextWriterTag.Div);
					{
						htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar-brand");
						htw.AddAttribute (HtmlTextWriterAttribute.Href, "#");
						htw.RenderBeginTag (HtmlTextWriterTag.A);
						{
							htw.Write (this.Theory.Name);
						}
						htw.RenderEndTag ();
					}
					htw.RenderEndTag ();
					htw.AddAttribute (HtmlTextWriterAttribute.Class, "navbar-collapse collapse");
					htw.RenderBeginTag (HtmlTextWriterTag.Div);
					{
						htw.AddAttribute (HtmlTextWriterAttribute.Class, "nav navbar-nav");
						htw.RenderBeginTag (HtmlTextWriterTag.Ul);
						{
							bool active = true;
							string[] ss = {"Foo","Bar","Baz"};
							foreach (string s in ss) {
								if (active) {
									htw.AddAttribute (HtmlTextWriterAttribute.Class, "active");
								}
								htw.RenderBeginTag (HtmlTextWriterTag.Li);
								htw.AddAttribute (HtmlTextWriterAttribute.Href, "#");
								htw.RenderBeginTag (HtmlTextWriterTag.A);
								htw.Write (s);
								htw.RenderEndTag ();
								htw.RenderEndTag ();
								active = false;
							}
						}
						htw.RenderEndTag ();
					}
					htw.RenderEndTag ();
				}
				htw.RenderEndTag ();
			}
			htw.RenderEndTag ();
		}

		public void WriteBody (Html32TextWriter htw) {
			this.WriteMasthead (htw);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "container");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.RenderBeginTag (HtmlTextWriterTag.Hr);
			htw.RenderEndTag ();
			this.WriteFooter (htw);
			htw.RenderEndTag ();
		}

		public void WriteJavascript (Html32TextWriter htw) {
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
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
		}
	}
}

