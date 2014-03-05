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

namespace IdpGie.UserInterface {

    [Flags]
    public enum MediaButtons : long {
        None             = 0x0000,
        Play             = 0x0001,
        Pause            = 0x0002,
        Default          = Play | Pause,
        Rewind           = 0x0004,
        Forward          = 0x0008,
        PreviousChapter  = 0x0010,
        NextChapter      = 0x0020,
        Shuffle          = 0x0100,
        Repeat           = 0x0200,
        Eject            = 0x0400,
        Record           = 0x4000,
        Stop             = 0x8000,
    }
}

