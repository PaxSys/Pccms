using System.Collections.Generic;
using System.Linq;

namespace PaxSys.Pcmms.Utils
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, T item)
        {
            return source.Concat(new[] {item});
        }
        
        public static IEnumerable<T> Except<T>(this IEnumerable<T> source, T item)
        {
            return source.Except(new[] {item});
        }
        
        public static IEnumerable<T> Union<T>(this IEnumerable<T> source, T item)
        {
            return source.Union(new[] {item});
        }
    }
}