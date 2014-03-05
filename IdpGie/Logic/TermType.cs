//
//  TermType.cs
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

namespace IdpGie.Logic {

    public enum TermType : ulong {
        None          = 0x0000000000000000UL,
        Term          = 0x0800000000000000UL,
        Float         = 0x0800000000000001UL,
        Int           = 0x0800000000000003UL,
        String        = 0x0800000000000004UL,
        PointList     = 0x0800000000000008UL,
        Named         = 0x0800000000000010UL,
        Point         = 0x0800000000000020UL,
        Color         = 0x0800000000000040UL,
		KeyValue	  = 0x0800000000000080UL,
        All           = 0x08000000000000FFUL
    }
}

