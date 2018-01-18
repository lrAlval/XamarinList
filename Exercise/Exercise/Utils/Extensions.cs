using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exercise.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<TSource> Exclude<TSource, TKey>(this IEnumerable<TSource> source,
        IEnumerable<TSource> exclude, Func<TSource, TKey> keySelector)
        {
            var excludedSet = new HashSet<TKey>(exclude.Select(keySelector));
            return source.Where(item => !excludedSet.Contains(keySelector(item)));
        }
    }
}
