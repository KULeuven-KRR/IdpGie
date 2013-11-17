//
//  IMediaWidget.cs
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
using System.Collections.Generic;

namespace IdpGie.GUI {
	public interface IMediaObject {
		MediaButtons SupportedMedia {
			get;
		}

		double MinTime {
			get;
		}

		double MaxTime {
			get;
		}

		double TimeSpan {
			get;
		}

		event EventHandler OnPlay;
		event EventHandler OnPause;
		event EventHandler OnRewind;
		event EventHandler OnForward;
		event EventHandler OnPreviousChapter;
		event EventHandler OnNextChapter;
		event EventHandler OnShuffle;
		event EventHandler OnRepeat;
		event EventHandler OnEject;
		event EventHandler OnRecord;
		event EventHandler OnStop;
		event EventHandler OnSeek;

		IEnumerable<double> Chapters {
			get;
		}

		void Play ();

		void Pause ();

		void Rewind ();

		void Forward ();

		void PreviousChapter ();

		void NextChapter ();

		void Shuffle ();

		void Repeat ();

		void Eject ();

		void Record ();

		void Stop ();

		void Seek (double time);
	}
}

