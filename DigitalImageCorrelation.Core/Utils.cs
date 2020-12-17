using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Core
{
    public static class Utils
    {
        public const int DELTA = 6;
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> self)
                => self.Select((item, index) => (item, index));
        public static Color GetColor(double value, double min, double denominatorDx)
        {
            double percentage = (value - min) / denominatorDx;
            if (percentage < 0.25)
                return InterpolateColors(Color.Blue, Color.Green, percentage * 4.0);
            else if (percentage < 0.5)
                return InterpolateColors(Color.Green, Color.Yellow, (percentage - 0.25) * 4.0);
            else if (percentage < 0.75)
                return InterpolateColors(Color.Yellow, Color.Orange, (percentage - 0.5) * 4.0);
            else
                return InterpolateColors(Color.Orange, Color.Red, (percentage - 0.75) * 4.0);
        }

        public static Color InterpolateColors(Color a, Color b, double t)
        {
            return Color.FromArgb
            (
                150,
                a.R + (int)((b.R - a.R) * t),
                a.G + (int)((b.G - a.G) * t),
                a.B + (int)((b.B - a.B) * t)
            );
        }
    }
}
