//
//  HookMappingMethod.cs
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

    [Mapper]
    public static class HookMethodMapping {

        [HookMethod("buttonpress",1000.0d)]
        public static void ButtonPress () {

        }

        public static void ButtonRelease () {

        }

        public static void Scroll () {

        }

        public static void MotionNotify () {

        }

        public static void Delete () {

        }

        public static void Destroy () {

        }

        public static void Expose () {

        }

        public static void KeyPress () {

        }

        public static void KeyRelease () {

        }

        public static void EnterNotify () {

        }

        public static void LeaveNotify () {

        }

        public static void Configure () {

        }

        public static void FocusIn () {

        }

        public static void FocusOut () {

        }

        public static void Map () {

        }

        public static void Unmap () {

        }

        public static void PropertyNotify () {

        }

        public static void SelectionClear () {

        }

        public static void SelectionRequest () {

        }

        public static void SelectionNotify () {

        }

        public static void ProximityIn () {

        }

        public static void ProximityOut () {

        }

        public static void VisibilityNotify () {

        }

        public static void Client () {

        }

        public static void NoExpose () {

        }

        public static void WindowState () {

        }

    }

}

