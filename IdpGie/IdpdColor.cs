//
//  Color.cs
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
using System.Globalization;

namespace IdpGie {

    [IdpdFunctionStructureAttribute("color",TermType.Color)]
    public struct IdpdColor {

        public const ulong AlphaChannel = 0xff000000;
        public const ulong RedChannel = 0x00ff0000;
        public const ulong GreenChannel = 0x0000ff00;
        public const ulong BlueChannel = 0x000000ff;
        public const int AlphaShift = 0x18;
        public const int RedShift = 0x10;
        public const int GreenShift = 0x08;
        public const int BlueShift = 0x00;
        public const ulong ChannelMask = BlueChannel;

        private ulong data;

        public byte Alpha {
            get {
                return (byte)((data >> AlphaShift) & ChannelMask);
            }
        }

        public byte Red {
            get {
                return (byte)((data >> RedShift) & ChannelMask);
            }
        }

        public byte Green {
            get {
                return (byte)((data >> GreenShift) & ChannelMask);
            }
        }

        public byte Blue {
            get {
                return (byte)((data >> BlueShift) & ChannelMask);
            }
        }

        [IdpdFunctionStructureConstructor(TermType.Int,TermType.Int,TermType.Int)]
        public IdpdColor (int red, int green, int blue) {
            this.data = AlphaChannel | (ulong)(red << RedShift) | (ulong)(green << GreenShift) | (ulong)(blue << BlueShift);
        }

        [IdpdFunctionStructureConstructor(TermType.Int,TermType.Int,TermType.Int,TermType.Int)]
        public IdpdColor (int alpha, int red, int green, int blue) {
            this.data = (ulong)(alpha << AlphaShift) | (ulong)(red << RedShift) | (ulong)(green << GreenShift) | (ulong)(blue << BlueShift);
        }

        public override bool Equals (object obj) {
            if (obj is IdpdColor) {
                return this.data == ((IdpdColor)obj).data;
            } else {
                return false;
            }
        }

        public override int GetHashCode () {
            return base.GetHashCode ();
        }

        public override string ToString () {
            return this.data.ToString ("x");
        }

    }

}

