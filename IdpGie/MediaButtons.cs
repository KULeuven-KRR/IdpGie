//
//  MediaButtons.cs
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

namespace IdpGie {

    [Flags]
    public enum MediaButtons : long {
        Play         = 0x0001,
        Pause        = 0x0002,
        Default      = Play | Pause,
        Stop         = 0x0004,
        Rewind       = 0x0008,
        FastForward  = 0x0010,
        SkipPrevious = 0x0020,
        SkipNext     = 0x0040,
        Record       = 0x0080,
        Eject        = 0x0100,
        Shuffle      = 0x0200,
        Repeat       = 0x0400
    }
}

