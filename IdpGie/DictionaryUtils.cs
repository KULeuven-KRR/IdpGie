//
//  DictionaryUtils.cs
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

namespace IdpGie.Utils {

	public static class DictionaryUtils {
		public static bool TryGetCastValue<T,Q,R> (this IDictionary<T,Q> dictionary, T key, out R value) where R : Q {
			Q qval;
			if (dictionary.TryGetValue (key, out qval) && qval is R) {
				value = (R)qval;
				return true;
			} else {
				value = default(R);
				return false;
			}
		}

		public static Dictionary<TKey,TValue> ToDictionary<TKey,TValue> (IEnumerable<Tuple<TKey,TValue>> tuples) {
			Dictionary<TKey,TValue> result = new Dictionary<TKey, TValue> ();
			foreach (Tuple<TKey,TValue> tuple in tuples) {
				result.Add (tuple.Item1, tuple.Item2);
			}
			return result;
		}

		public static LazyDictionary<TKey,TValue> ToLazyDictionary<TKey,TValue> (this IEnumerable<Tuple<TKey,TValue>> tuples) {
			return new LazyDictionary<TKey, TValue> (tuples);
		}

		public static IEnumerable<T> Tail<T> (this IEnumerable<T> source) {
			IEnumerator<T> tor = source.GetEnumerator ();
			if (tor.MoveNext ()) {
				while (tor.MoveNext ()) {
					yield return tor.Current;
				}
			}
		}
	}
}

