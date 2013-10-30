//
//  TopWindow.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
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
#define PARSE

using System;
using System.IO;
using Gtk;
using IdpGie.Parser;

namespace IdpGie {
    public partial class TopWindow : Gtk.Window {

        public static TopWindow Create<T> (T widget) where T : Widget, IMediaObject {
            return new TopWindow (widget);
        }

        private TopWindow (Widget widget) : base(WindowType.Toplevel) {
            this.Build ();
        }

        public static int Main (string[] args) {
            Application.Init ("IdpGie", ref args);
            DirectoryInfo dirInfo = new DirectoryInfo (".");
            foreach (string name in args) {
                FileInfo[] fInfo = dirInfo.GetFiles (name);
                foreach (FileInfo info in fInfo) {
                    try {
                        using (FileStream file = new FileStream (info.FullName, FileMode.Open)) {
                            Lexer scnr = new Lexer (file);
                            IdpParser pars = new IdpParser (scnr);

                            //Console.Error.WriteLine ("File: " + info.Name);
#if PARSE
                            pars.Parse ();
#else
                            foreach (Token tok in scnr.Tokenize()) {
                                Console.Error.Write (tok);
                                Console.Error.Write (' ');
                            }
#endif
                            if (pars.Result != null) {
                                pars.Result.Execute ();
                                //Console.Error.WriteLine ("echo: ");
                                //Console.Error.WriteLine (pars.Result);
                            }
                        }
                    } catch (IOException) {
                        Console.Error.WriteLine ("File \"{0}\" not found.", info.Name);
                    }
                }
            }
            return 0x00;
        }

    }
}

