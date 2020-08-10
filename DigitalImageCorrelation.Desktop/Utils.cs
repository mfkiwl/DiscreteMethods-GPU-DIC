using System.Collections.Generic;
using System.Linq;

namespace DigitalImageCorrelation.Desktop
{
    public static class Utils
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
                => self.Select((item, index) => (item, index));
    }
}
