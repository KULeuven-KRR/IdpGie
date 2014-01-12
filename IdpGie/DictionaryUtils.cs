using System;
using System.Collections.Generic;

namespace IdpGie {
	public static class DictionaryUtils {
		public static void AddListDictionary<TKey,TList,TListValue> (this Dictionary<TKey,TList> dictionary, TKey key, TListValue item) where TList : ICollection<TListValue>, new() {
			TList lst;
			if (!dictionary.TryGetValue (key, out lst)) {
				lst = new TList ();
				dictionary.Add (key, lst);
			}
			lst.Add (item);
		}
	}
}

