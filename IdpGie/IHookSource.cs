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
using Gdk;

namespace IdpGie {
	public interface IHookSource {
		[HookType (EventType.Delete)]
		event EventHandler DeleteHook;
		[HookType (EventType.Destroy)]
		event EventHandler DestroyHook;
		[HookType (EventType.Expose)]
		event EventHandler ExposeHook;
		[HookType (EventType.MotionNotify)]
		event EventHandler MotionNotifyHook;
		[HookType (EventType.ButtonPress)]
		event EventHandler ButtonPressHook;
		[HookType (EventType.TwoButtonPress)]
		event EventHandler TwoButtonPressHook;
		[HookType (EventType.ThreeButtonPress)]
		event EventHandler ThreeButtonPressHook;
		[HookType (EventType.ButtonRelease)]
		event EventHandler ButtonReleaseHook;
		[HookType (EventType.KeyPress)]
		event EventHandler KeyPressHook;
		[HookType (EventType.KeyRelease)]
		event EventHandler KeyReleaseHook;
		[HookType (EventType.EnterNotify)]
		event EventHandler EnterNotifyHook;
		[HookType (EventType.LeaveNotify)]
		event EventHandler LeaveNotifyHook;
		[HookType (EventType.FocusChange)]
		event EventHandler FocusChangeHook;
		[HookType (EventType.Configure)]
		event EventHandler ConfigureHook;
		[HookType (EventType.Map)]
		event EventHandler MapHook;
		[HookType (EventType.Unmap)]
		event EventHandler UnmapHook;
		[HookType (EventType.PropertyNotify)]
		event EventHandler PropertyNotifyHook;
		[HookType (EventType.SelectionClear)]
		event EventHandler SelectionClearHook;
		[HookType (EventType.SelectionRequest)]
		event EventHandler SelectionRequestHook;
		[HookType (EventType.SelectionNotify)]
		event EventHandler SelectionNotifyHook;
		[HookType (EventType.ProximityIn)]
		event EventHandler ProximityInHook;
		[HookType (EventType.ProximityOut)]
		event EventHandler ProximityOutHook;
		[HookType (EventType.DragEnter)]
		event EventHandler DragEnterHook;
		[HookType (EventType.DragLeave)]
		event EventHandler DragLeaveHook;
		[HookType (EventType.DragMotion)]
		event EventHandler DragMotionHook;
		[HookType (EventType.DragStatus)]
		event EventHandler DragStatusHook;
		[HookType (EventType.DropStart)]
		event EventHandler DropStartHook;
		[HookType (EventType.DropFinished)]
		event EventHandler DropFinishedHook;
		[HookType (EventType.ClientEvent)]
		event EventHandler ClientEventHook;
		[HookType (EventType.VisibilityNotify)]
		event EventHandler VisibilityNotifyHook;
		[HookType (EventType.NoExpose)]
		event EventHandler NoExposeHook;
		[HookType (EventType.Scroll)]
		event EventHandler ScrollHook;
		[HookType (EventType.WindowState)]
		event EventHandler WindowStateHook;
		[HookType (EventType.Setting)]
		event EventHandler SettingHook;
		[HookType (EventType.OwnerChange)]
		event EventHandler OwnerChangeHook;
		[HookType (EventType.GrabBroken)]
		event EventHandler GrabBrokenHook;
	}
}