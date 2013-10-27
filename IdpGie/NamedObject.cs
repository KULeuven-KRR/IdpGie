//
//  NamedObject.cs
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

    [IdpdNamedObjectEnum]
    public enum NamedObject : long {
        #region Generic   (0x000000 family)
        [IdpdNamedObject]
        Unknown = 0x000000,
        #endregion
        #region Keys      (0x010000 family)
        KeyA     = 0x010000,
        KeyB     = 0x010001,
        KeyC     = 0x010002,
        KeyD     = 0x010003,
        KeyE     = 0x010004,
        KeyF     = 0x010005,
        KeyG     = 0x010006,
        KeyH     = 0x010007,
        KeyI     = 0x010008,
        KeyJ     = 0x010009,
        KeyK     = 0x01000a,
        KeyUp    = 0x01000b,
        KeyLeft  = 0x01000c,
        KeyRight = 0x01000d,
        KeyDown  = 0x01000e,
        #endregion
        #region Mouse
        #endregion
        #region ModeNames (0x030000 family)
        [IdpdNamedObject]
        Opengl  = 0x030001,
        [IdpdNamedObject]
        Cairo   = 0x030002,
        [IdpdNamedObject]
        Latex   = 0x030003,
        [IdpdNamedObject]
        Print   = 0x030004
        #endregion
    }

}

