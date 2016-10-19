using System.Collections.Generic;

namespace Tongs
{
    static class MiscExtensions
    {
        public static Option<TValue> GetOrNone<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? Option.Some(value) : Option.None<TValue>();
        }
    }
}
