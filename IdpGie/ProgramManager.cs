//
//  ProgramManager.cs
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
using System;
using IdpGie.Parser;
using Mono.Unix;
using System.IO;
using Gtk;

namespace IdpGie {

    public class ProgramManager : IDisposable {

        private TopWindow tw;

        public ProgramManager () {
        }

        public void CreateWindow () {
            tw = new TopWindow ();
        }

        public void ShowWindow () {
            Application.Run ();
        }

        public void OpenFile () {
        
        }

        #region IDisposable implementation
        public void Dispose () {
            tw.Dispose ();
        }
        #endregion

        public void OpenTab (string name, Widget widget) {

        }

        public static int Main (string[] args) {
            Catalog.Init ("IdpGie", "./locale");
            Application.Init ("IdpGie", ref args);
            using (ProgramManager manager = new ProgramManager ()) {
                manager.CreateWindow ();
                DirectoryInfo dirInfo = new DirectoryInfo (".");
                foreach (string name in args) {
                    FileInfo[] fInfo = dirInfo.GetFiles (name);
                    foreach (FileInfo info in fInfo) {
                        try {
                            using (FileStream file = new FileStream (info.FullName, FileMode.Open)) {
                                Lexer scnr = new Lexer (file);
                                IdpParser pars = new IdpParser (scnr);
                                pars.Parse ();
                                if (pars.Result != null) {
                                    pars.Result.Execute (manager);
                                }
                            }
                        } catch (IOException) {
                            Console.Error.WriteLine ("File \"{0}\" not found.", info.Name);
                        }
                    }
                }
                manager.ShowWindow ();
            }
            return 0x00;
        }

    }
}

