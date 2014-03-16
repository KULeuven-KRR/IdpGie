//
//  HttpEngine.cs
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

using System;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Web.UI;
using IdpGie.Core;
using IdpGie.OutputDevices;

namespace IdpGie.Engines {

	/// <summary>
	/// An engine that generates webpages based on the logical descripiton.
	/// </summary>
	public class HttpEngine : Engine, IWebEngine {
		private readonly TcpClient client;

		#region IWebEngine implementation
		/// <summary>
		/// Gets the <see cref="TcpClient"/> that contains data about the requested page and a stream to send a response.
		/// </summary>
		/// <value>
		/// The <see cref="TcpClient"/> that contains data about the requested page and a stream to send a response.
		/// </value>
		public TcpClient Client {
			get {
				return this.client;
			}
		}
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.HttpEngine"/> class with a specified <see cref="TcpClient"/> and <see cref="OutputHttpServerDevice"/>.
		/// </summary>
		/// <param name='client'>
		/// A <see cref="TcpClient"/> instance that contains information about the page request and a <see cref="Stream"/> to write a response back.
		/// </param>
		/// <param name='device'>
		/// A <see cref="OutputHttpServerDevice"/> instance that contains the <see cref="IDrawTheory"/>.
		/// </param>
		public HttpEngine (TcpClient client, OutputHttpServerDevice device) : this(client,device.Theory) {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IdpGie.Engines.HttpEngine"/> class with a specified <see cref="TcpClient"/> and <see cref="IDrawTheory"/>.
		/// </summary>
		/// <param name='client'>
		/// A <see cref="TcpClient"/> instance that contains information about the page request and a <see cref="Stream"/> to write a response back.
		/// </param>
		/// <param name='theory'>
		/// The intial <see cref="IDrawTheory"/> instance that contains the set of <see cref="IdpGie.Shapes.IShape"/> instances.
		/// </param>
		public HttpEngine (TcpClient client, IDrawTheory theory) : base(theory) {
			this.client = client;
		}

		#region IEngine implementation
		/// <summary>
		/// Converts the set of <see cref="IdpGie.Shapes.IShape"/> by converting it into a readable format.
		/// </summary>
		public override void Process () {
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
				//string http_url = tokens [1];
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

		#endregion

		private void WriteHeader (Html32TextWriter htw) {
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

		private void WriteMasthead (Html32TextWriter htw) {
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

		private void WriteBody (Html32TextWriter htw) {
			this.WriteMasthead (htw);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "container");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.RenderBeginTag (HtmlTextWriterTag.Hr);
			htw.RenderEndTag ();
			this.WriteFooter (htw);
			htw.RenderEndTag ();
		}

		private void WriteJavascript (Html32TextWriter htw) {
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "https://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
		}

		private void WriteFooter (Html32TextWriter htw) {
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

