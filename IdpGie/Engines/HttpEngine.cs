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
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Web.UI;
using IdpGie.Core;
using IdpGie.OutputDevices;
using IdpGie.Shapes.Pages;

namespace IdpGie.Engines {
	/// <summary>
	/// An engine that generates webpages based on the logical descripiton.
	/// </summary>
	public class HttpEngine : Engine, IWebEngine {

		/// <summary>
		/// The file name of the icon.
		/// </summary>
		public const string IconName = @"favicon.ico";
		private readonly TcpClient client;
		private readonly OutputHttpServerDevice device;
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
			this.device = device;
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
				Console.WriteLine ("\"{0}\"", http_filename);
				
				if (http_filename == "/" + IconName) {
					this.device.Navigationbar.FavIcon.RenderIcon (this.device.Manager.ServerFolder, this, client.GetStream ());
				} else {
					bool border;
					IWebPage wp = this.device.Navigationbar.GetPage (http_filename.Substring (0x01), out border);
					using (StreamWriter sw = new StreamWriter (client.GetStream ())) {
						using (Html32TextWriter tw = new Html32TextWriter (sw)) {
							if (border) {
								tw.WriteLine ("<!DOCTYPE html>");
								tw.RenderBeginTag (HtmlTextWriterTag.Html);
								tw.RenderBeginTag (HtmlTextWriterTag.Head);
								this.WriteHeader (tw);
								tw.RenderEndTag ();
								tw.RenderBeginTag (HtmlTextWriterTag.Body);
								this.WriteBody (tw, wp);
								this.WriteJavascript (tw);
								tw.RenderEndTag ();
								tw.RenderEndTag ();
							} else {
								wp.Render (this.device.Manager.ServerFolder, this, tw);
							}
						}
					}
				}
			}
		}
		#endregion
		#region Webpage writing
		/// <summary>
		/// Writes the header of the webpage. The header contains references to bootstrap, a favoicon and some stylefile.
		/// </summary>
		/// <param name='htw'>
		/// A <see cref="Html32TextWriter"/> to write the content to.
		/// </param>
		private void WriteHeader (Html32TextWriter htw) {
			htw.RenderBeginTag (HtmlTextWriterTag.Title);
			{
				htw.Write (this.device.Navigationbar.Name);
			}
			htw.RenderEndTag ();
			htw.AddAttribute (HtmlTextWriterAttribute.Name, "generator");
			htw.AddAttribute (HtmlTextWriterAttribute.Content, ProgramManager.ProgramNameVersion);
			htw.RenderBeginTag (HtmlTextWriterTag.Meta);
			{}
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Name, "viewport");
			htw.AddAttribute (HtmlTextWriterAttribute.Content, "width=device-width, initial-scale=1.0");
			htw.RenderBeginTag (HtmlTextWriterTag.Meta);
			{}
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Href, "http://netdna.bootstrapcdn.com/bootstrap/3.1.1/css/bootstrap.min.css");
			htw.AddAttribute (HtmlTextWriterAttribute.Rel, "stylesheet");
			htw.RenderBeginTag (HtmlTextWriterTag.Link);
			{}
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Href, IconName);
			htw.AddAttribute (HtmlTextWriterAttribute.Rel, "icon");
			htw.AddAttribute (HtmlTextWriterAttribute.Type, "image/x-icon");
			htw.RenderBeginTag (HtmlTextWriterTag.Link);
			{}
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.RenderBeginTag (HtmlTextWriterTag.Style);
			{
				htw.Write ("body {min-height: 2000px;padding-top: 70px;}");
			}
			htw.RenderEndTag ();
			htw.AddAttribute ("language", "javascript");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			{
				htw.WriteLine ("function genericAjax (source, target) {");
				htw.WriteLine ("    var xmlhttp;");
				htw.WriteLine ("    if (window.XMLHttpRequest) {");
				htw.WriteLine ("        xmlhttp=new XMLHttpRequest();");
				htw.WriteLine ("    } else {");
				htw.WriteLine ("        xmlhttp=new ActiveXObject(\"Microsoft.XMLHTTP\");");
				htw.WriteLine ("    }");
				htw.WriteLine ("    xmlhttp.onreadystatechange=function() {");
				htw.WriteLine ("        if (xmlhttp.readyState==4) {");
				htw.WriteLine ("            if(xmlhttp.status==200) {");
				htw.WriteLine ("                document.getElementById(target).innerHTML=xmlhttp.responseText;");
				htw.WriteLine ("            } else {");
				htw.WriteLine ("                document.getElementById(target).innerHTML=\"<div class='alert alert-warning'><strong>Warning:</strong> something went wrong during an AJAX call. Error code: \"+xmlhttp.status+\", Source: \"+source+\".</div>\";");
				htw.WriteLine ("            }");
				htw.WriteLine ("        }");
				htw.WriteLine ("    }");
				htw.WriteLine ("    xmlhttp.open(\"GET\",source,true);");
				htw.WriteLine ("    xmlhttp.send();");
				htw.WriteLine ("}");
			}
			htw.RenderEndTag ();
			htw.WriteLine ();
		}

		/// <summary>
		/// Writes the navigation bar to the given <see cref="Html32TextWriter"/>.
		/// </summary>
		/// <param name='htw'>
		/// The <see cref="Html32TextWriter"/> to write the content to.
		/// </param>
		/// <param name='webpage'>
		/// The webpage that is currently displayed. This is needed to denote the current page.
		/// </param>
		private void WriteMasthead (Html32TextWriter htw, IWebPage webpage) {
			INavbar navbar = this.device.Navigationbar;
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
							htw.Write (navbar.Name);
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
							foreach (IWebPage wp in navbar.Pages) {
								if (wp == webpage) {
									htw.AddAttribute (HtmlTextWriterAttribute.Class, "active");
								}
								htw.RenderBeginTag (HtmlTextWriterTag.Li);
								htw.AddAttribute (HtmlTextWriterAttribute.Href, wp.Href);
								htw.RenderBeginTag (HtmlTextWriterTag.A);
								htw.Write (wp.Name);
								htw.RenderEndTag ();
								htw.RenderEndTag ();
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

		/// <summary>
		/// Writes the body of the given <see cref="IWebPage"/> to the <see cref="Html32TextWriter"/>.
		/// </summary>
		/// <param name='htw'>
		/// The <see cref="Html32TextWriter"/> to write the content to.
		/// </param>
		/// <param name='webpage'>
		/// The <see cref="IWebPage"/> to write to the <see cref="Html32TextWriter"/>.
		/// </param>
		private void WriteBody (Html32TextWriter htw, IWebPage webpage) {
			this.WriteMasthead (htw, webpage);
			htw.AddAttribute (HtmlTextWriterAttribute.Class, "container");
			htw.RenderBeginTag (HtmlTextWriterTag.Div);
			htw.RenderBeginTag (HtmlTextWriterTag.Hr);
			htw.RenderEndTag ();

			webpage.Render (this.device.Manager.ServerFolder, this, htw);

			this.WriteFooter (htw);
			htw.RenderEndTag ();
		}

		/// <summary>
		/// Writes references of some javascript libraries to the given <see cref="Html32TextWriter"/> to let the bootstrap work.
		/// </summary>
		/// <param name='htw'>
		/// The <see cref="Html32TextWriter"/> to write the content to.
		/// </param>
		private void WriteJavascript (Html32TextWriter htw) {
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "http://netdna.bootstrapcdn.com/bootstrap/3.1.1/js/bootstrap.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			htw.RenderEndTag ();
			htw.WriteLine ();
			htw.AddAttribute (HtmlTextWriterAttribute.Src, "http://ajax.googleapis.com/ajax/libs/jquery/1.11.0/jquery.min.js");
			htw.RenderBeginTag (HtmlTextWriterTag.Script);
			{}
			htw.RenderEndTag ();
		}

		/// <summary>
		/// Writes a footer of every webpage to the given <see cref="Html32TextWriter"/> instance.
		/// </summary>
		/// <param name='htw'>
		/// The <see cref="Html32TextWriter"/> to write the webpage to.
		/// </param>
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
		#endregion
	}
}