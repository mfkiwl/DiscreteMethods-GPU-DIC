using System.Collections.Generic;
using System.Linq;

namespace DigitalImageCorrelation.Core
{
    public static class Utils
    {
        public const int DELTA = 5;
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
                => self.Select((item, index) => (item, index));
    }
}
