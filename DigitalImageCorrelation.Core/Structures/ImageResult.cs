using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

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

        public double MaxStrainXX => Vertexes.Max(x => x.strain.XX);
        public double MinStrainXX => Vertexes.Min(x => x.strain.XX);
        public double MaxStrainXY => Vertexes.Max(x => x.strain.XY);
        public double MinStrainXY => Vertexes.Min(x => x.strain.XY);
        public double MaxStrainYY => Vertexes.Max(x => x.strain.YY);
        public double MinStrainYY => Vertexes.Min(x => x.strain.YY);


        public IList<Vertex> CalculateDisplacementColorsDX(double maxDx, double minDx)
        {
            var denominatorDx = (maxDx - minDx) != 0 ? (maxDx - minDx) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.ColorDx = GetColor(vertex.dX, minDx, denominatorDx);
            }
            return Vertexes.ToList();
        }

        public IList<Vertex> CalculateDisplacementColorsDY(double maxDy, double minDy)
        {
            var denominatorDy = (maxDy - minDy) != 0 ? (maxDy - minDy) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.ColorDy = GetColor(vertex.dY, minDy, denominatorDy);
            }
            return Vertexes.ToList();
        }

        public IList<Vertex> CalculateStrainColorsXX(double maxStrainXX, double minxStrainXX)
        {
            var denominatorXX = (maxStrainXX - minxStrainXX) != 0 ? (maxStrainXX - minxStrainXX) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.strain.ColorXX = GetColor(vertex.strain.XX, minxStrainXX, denominatorXX);
            }
            return Vertexes.ToList();
        }

        public IList<Vertex> CalculateStrainColorsXY(double maxStrainXY, double minxStrainXY)
        {
            var denominatorXY = (maxStrainXY - minxStrainXY) != 0 ? (maxStrainXY - minxStrainXY) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.strain.ColorXY = GetColor(vertex.strain.XY, minxStrainXY, denominatorXY);
            }
            return Vertexes.ToList();
        }

        public IList<Vertex> CalculateStrainColorsYY(double maxStrainYY, double minxStrainYY)
        {
            var denominatorYY = (maxStrainYY - minxStrainYY) != 0 ? (maxStrainYY - minxStrainYY) : 1;
            foreach (var vertex in Vertexes)
            {
                vertex.strain.ColorYY = GetColor(vertex.strain.YY, minxStrainYY, denominatorYY);
            }
            return Vertexes.ToList();
        }

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

        public Vertex GetClosestVertex(int x, int y)
        {
            Vertex closest = Vertexes.First();
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                var distanceClosest = Math.Sqrt(Math.Pow(x - closest.X, 2) + Math.Pow(y - closest.Y, 2));
                var distance = Math.Sqrt(Math.Pow(x - vertex.X, 2) + Math.Pow(y - vertex.Y, 2));
                if (distanceClosest > distance)
                {
                    closest = vertex;
                    distanceClosest = Math.Sqrt(Math.Pow(x - closest.X, 2) + Math.Pow(y - closest.Y, 2));
                };
            });
            return closest;
        }
    }
}
