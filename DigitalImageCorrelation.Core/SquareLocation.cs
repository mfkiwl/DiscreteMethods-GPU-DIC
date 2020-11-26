using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Core
{
    public class SquareLocation
    {
        public static int Left;
        public static int Top;
        public static int Width;
        public static int Height;
        public static double Scale = 1.0;
        public double ScaledLeft { get => Left * Scale; }
        public double ScaledTop { get => Top * Scale; }
        public double ScaledWidth { get => Width * Scale; }
        public double ScaledHeight { get => Height * Scale; }

        public IEnumerable<Point> CalculateStartingPoints(int w, int h)
        {
            double spaceX = Width / (w + 1.0);
            double spaceY = Height / (h + 1.0);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    yield return new Point((int)((i + 1.0) * spaceX + Left), (int)((j + 1.0) * spaceY + Top));
                }
            }
        }
        public Vertex[] CalculateStartingVertexes(int w, int h)
        {
            var result = new Vertex[w * h];
            double spaceX = Width / (w + 1.0);
            double spaceY = Height / (h + 1.0);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[i * w + j] = new Vertex((int)((i + 1.0) * spaceX + Left), (int)((j + 1.0) * spaceY + Top), 0, 0);
                }
            }
            return result;
        }
    }
}
