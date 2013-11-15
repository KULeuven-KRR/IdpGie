//
//  IHookSource.cs
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

    public interface IHookSource {

        event EventHandler DeleteHook;
        event EventHandler DestroyHook;
        event EventHandler ExposeHook;
        event EventHandler MotionNotifyHook;
        event EventHandler ButtonPressHook;
        event EventHandler TwoButtonPressHook;
        event EventHandler ThreeButtonPressHook;
        event EventHandler ButtonReleaseHook;
        event EventHandler KeyPressHook;
        event EventHandler KeyReleaseHook;
        event EventHandler EnterNotifyHook;
        event EventHandler LeaveNotifyHook;
        event EventHandler FocusChangeHook;
        event EventHandler ConfigureHook;
        event EventHandler MapHook;
        event EventHandler UnmapHook;
        event EventHandler PropertyNotifyHook;
        event EventHandler SelectionClearHook;
        event EventHandler SelectionRequestHook;
        event EventHandler SelectionNotifyHook;
        event EventHandler ProximityInHook;
        event EventHandler ProximityOutHook;
        event EventHandler DragEnterHook;
        event EventHandler DragLeaveHook;
        event EventHandler DragMotionHook;
        event EventHandler DragStatusHook;
        event EventHandler DropStartHook;
        event EventHandler DropFinishedHook;
        event EventHandler ClientEventHook;
        event EventHandler VisibilityNotifyHook;
        event EventHandler NoExposeHook;
        event EventHandler ScrollHook;
        event EventHandler WindowStateHook;
        event EventHandler SettingHook;
        event EventHandler OwnerChangeHook;
        event EventHandler GrabBrokenHook;

    }

}