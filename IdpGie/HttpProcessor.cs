using System;
using System.Net.Sockets;
using System.Web;
using System.IO;
using System.Text;
using System.Net;
using System.Web.UI;

namespace IdpGie {
	public class HttpProcessor {
		private readonly TcpClient client;
		private readonly OutputHttpServerDevice device;

		public HttpProcessor (TcpClient client, OutputHttpServerDevice device) {
			this.client = client;
			this.device = device;
		}

		public void WriteHeader (Html32TextWriter htw) {
			htw.AddAttribute(HtmlTextWriterAttribute.Name,"generator");
			htw.AddAttribute(HtmlTextWriterAttribute.Content,ProgramManager.ProgramNameVersion);
			htw.RenderBeginTag(HtmlTextWriterTag.Meta);
			htw.RenderEndTag();
			htw.WriteLine();
			htw.AddAttribute(HtmlTextWriterAttribute.Name,"viewport");
			htw.AddAttribute(HtmlTextWriterAttribute.Content,"width=device-width, initial-scale=1.0");
			htw.RenderBeginTag(HtmlTextWriterTag.Meta);
			htw.RenderEndTag();
			htw.WriteLine();
			htw.AddAttribute(HtmlTextWriterAttribute.Href,"//netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css");
			htw.AddAttribute(HtmlTextWriterAttribute.Rel,"stylesheet");
			htw.RenderBeginTag(HtmlTextWriterTag.Link);
			htw.RenderEndTag();
			htw.AddAttribute(HtmlTextWriterAttribute.Type,"text/css");
			htw.RenderBeginTag(HtmlTextWriterTag.Style);
			htw.WriteLine("body {\npadding-top: 20px;\npadding-bottom: 40px;\n}\n\n/* Custom container */\n.container-narrow {\nmargin: 0 auto;\nmax-width: 700px;\n}\n.container-narrow > hr {\nmargin: 30px 0;\n}\n\n/* Main marketing message and sign up button */\n.jumbotron {\nmargin: 60px 0;\ntext-align: center;\n}\n.jumbotron h1 {\nfont-size: 72px;\nline-height: 1;\n}\n.jumbotron .btn {\nfont-size: 21px;\npadding: 14px 24px;\n}\n\n/* Supporting marketing content */\n.marketing {\nmargin: 60px 0;\n}\n.marketing p + h4 {\nmargin-top: 28px;\n}");
			htw.RenderEndTag();
		}

		public void WriteBody (Html32TextWriter htw) {
		}

		public void WriteFooter (Html32TextWriter htw) {
			htw.RenderBeginTag(HtmlTextWriterTag.Hr);
			htw.RenderEndTag();
			htw.AddAttribute(HtmlTextWriterAttribute.Class,"footer");
			htw.RenderBeginTag(HtmlTextWriterTag.Div);
			htw.RenderBeginTag(HtmlTextWriterTag.P);
			htw.Write ("This page is created with {0}", ProgramManager.ProgramNameVersion);
			htw.RenderEndTag();
			htw.RenderEndTag();
			htw.WriteLine();
			htw.AddAttribute(HtmlTextWriterAttribute.Src,"//netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js");
			htw.RenderBeginTag(HtmlTextWriterTag.Script);
			htw.RenderEndTag();
			htw.WriteLine();
			htw.AddAttribute(HtmlTextWriterAttribute.Src,"https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js");
			htw.RenderBeginTag(HtmlTextWriterTag.Script);
			htw.RenderEndTag();
			htw.WriteLine();
		}

		public void process ()
		{
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
				Console.WriteLine(http_filename);
				using(StreamWriter sw = new StreamWriter (client.GetStream ())) {
					using(Html32TextWriter tw = new Html32TextWriter (sw)) {
						tw.WriteLine("<!DOCTYPE html>");
						tw.RenderBeginTag(HtmlTextWriterTag.Html);
						tw.RenderBeginTag(HtmlTextWriterTag.Head);
						this.WriteHeader(tw);
						tw.RenderEndTag();
						tw.RenderBeginTag(HtmlTextWriterTag.Body);
						tw.AddAttribute(HtmlTextWriterAttribute.Class,"container-narrow");
						tw.RenderBeginTag(HtmlTextWriterTag.Div);
						this.WriteBody(tw);
						this.WriteFooter(tw);
						tw.RenderEndTag();
						tw.RenderEndTag();
						tw.RenderEndTag();
						tw.Close();
					}
					sw.Close();
				}
			}
		}
	}
}

