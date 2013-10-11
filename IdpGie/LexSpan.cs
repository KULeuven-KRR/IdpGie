//
//  LexSpan.cs
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
using QUT.Gppg;

namespace ZincOxide.Parser {

    public class LexSpan : IMerge<LexSpan> {

        private readonly int startLine;
        private readonly int startColumn;
        private readonly int endLine;
        private readonly int endColumn;
        private readonly int startIndex;
        private readonly int endIndex;
        private readonly ScanBuff buffer;

        public int StartLine {
            get {
                return startLine;
            }
        }

        public int StartColumn {
            get {
                return startColumn;
            }
        }

        public int EndLine {
            get {
                return endLine;
            }
        }

        public int EndColumn {
            get {
                return endColumn;
            }
        }

        public int StartIndex {
            get {
                return startIndex;
            }
        }

        public int EndIndex {
            get {
                return endIndex;
            }
        }

        public ScanBuff Buffer {
            get {
                return buffer;
            }
        }

        public LexSpan () {
        }

        public LexSpan (int sl, int sc, int el, int ec, int sp, int ep, ScanBuff bf) {
            startLine = sl;
            startColumn = sc;
            endLine = el;
            endColumn = ec;
            startIndex = sp;
            endIndex = ep;
            buffer = bf;
        }

        /// <summary>
        /// This method implements the IMerge interface
        /// </summary>
        /// <param name="end">The last span to be merged</param>
        /// <returns>A span from the start of 'this' to the end of 'end'</returns>
        public LexSpan Merge (LexSpan end) {
            return new LexSpan (startLine, startColumn, end.endLine, end.endColumn, startIndex, end.endIndex, buffer);
        }

        public override string ToString () {
            return buffer.GetString (startIndex, endIndex);
        }

        public string LiteralString () {
            return buffer.GetString (startIndex + 0x01, endIndex - 0x01);
        }

    }
}

