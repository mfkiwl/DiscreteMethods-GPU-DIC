using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Core
{
    public class Position
    {
        public static int left;
        public static int top;
        public static int width;
        public static int height;
        public static double scale = 1.0;
        public double ScaledLeft { get => left * scale; }
        public double ScaledTop { get => top * scale; }
        public double ScaledWidth { get => width * scale; }
        public double ScaledHeight { get => height * scale; }

        public IEnumerable<Point> CalculateStartingPoints(int w, int h)
        {
            var spaceX = width / (w + 1);
            var spaceY = height / (h + 1);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    yield return new Point((int)((i + 1) * spaceX + left), (int)((j + 1) * spaceY + top));
                }
            }
        }
        public IEnumerable<Vertex> CalculateStartingVertexes(int w, int h)
        {
            var spaceX = width / (w + 1);
            var spaceY = height / (h + 1);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    yield return new Vertex((int)((i + 1) * spaceX + left), (int)((j + 1) * spaceY + top));
                }
            }
        }
    }
}
