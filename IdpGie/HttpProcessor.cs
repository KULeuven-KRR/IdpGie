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

		public HttpProcessor (TcpClient client, IHttpHandler handler) {
			this.client = client;
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
			htw.WriteLine();
		}

		public void WriteBody (Html32TextWriter htw) {
		}

		public void WriteFooter (Html32TextWriter htw) {
			htw.RenderBeginTag(HtmlTextWriterTag.Hr);
			htw.Write ("This page is created with {0}", ProgramManager.ProgramNameVersion);
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
						this.WriteBody(tw);
						this.WriteFooter(tw);
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

