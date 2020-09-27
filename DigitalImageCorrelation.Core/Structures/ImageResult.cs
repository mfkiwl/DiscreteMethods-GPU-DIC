using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Core.Structures
{
    public class ImageResult
    {
        public Vertex[] Vertexes;
        public Vertex[] StartingVertexes;
        public int Index;

        public double MaxDx => Vertexes.Max(x => x.dX);
        public double MinDx => Vertexes.Min(x => x.dX);
        public double MaxDy => Vertexes.Max(x => x.dY);
        public double MinDy => Vertexes.Min(x => x.dY);

        public IList<Vertex> CalculateLocalColors()
        {
            return CalculateColors(MaxDx, MinDx, MaxDy, MinDy);
        }

        public void CalculateDisplacement(Vertex[] startingVertexes)
        {
            for (int i = 0; i < startingVertexes.Length; i++)
            {
                Vertexes[i].dX = Vertexes[i].X - startingVertexes[i].X;
                Vertexes[i].dY = Vertexes[i].Y - startingVertexes[i].Y;
            }
        }

        public IList<Vertex> CalculateColors(double maxDx, double minDx, double maxDy, double minDy)
        {
            var denominatorDx = (maxDx - minDx) != 0 ? (maxDx - minDx) : 1;
            var denominatorDy = (maxDy - minDy) != 0 ? (maxDy - minDy) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.ColorDx = GetColor(vertex.dX, minDx, denominatorDx);
                vertex.ColorDy = GetColor(vertex.dY, minDy, denominatorDy);
            }
            return Vertexes.ToList();
        }

        private Color GetColor(int value, double min, double denominatorDx)
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
        public Color InterpolateColors(Color a, Color b, double t)
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
