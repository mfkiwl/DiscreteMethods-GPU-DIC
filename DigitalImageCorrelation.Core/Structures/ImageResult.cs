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

        public void CalculateDisplacement(Vertex[] startingVertexes)
        {
            for (int i = 0; i < startingVertexes.Length; i++)
            {
                Vertexes[i].dX = Vertexes[i].X - startingVertexes[i].X;
                Vertexes[i].dY = Vertexes[i].Y - startingVertexes[i].Y;
            }
        }
        public void CalculateStrain(int pointsinX, int pointsinY)
        {
            double sWidth = StartingVertexes[pointsinY + 1].X - StartingVertexes[0].X;
            double sHeight = StartingVertexes[1].Y - StartingVertexes[0].Y;
            for (var y = 0; y < pointsinY; y++)
            {
                for (var x = 0; x < pointsinX; x++)
                {
                    var currentVertex = Vertexes[x + y * pointsinX];
                    double du_dx = 0;
                    double du_dy = 0;
                    double dv_dx = 0;
                    double dv_dy = 0;
                    if (x - 1 >= 0 && x + 1 < pointsinX)
                    {
                        var nextVertex = Vertexes[x + 1 + y * pointsinX];
                        var prevVertex = Vertexes[x - 1 + y * pointsinX];
                        var du = nextVertex.dX - prevVertex.dX;
                        du_dx = du / (2.0 * sWidth);
                        du_dy = du / (2.0 * sHeight);
                    }

                    if (y - 1 >= 0 && y + 1 < pointsinY)
                    {
                        var nextVertex = Vertexes[x + (y + 1) * pointsinX];
                        var prevVertex = Vertexes[x + (y - 1) * pointsinX];
                        var dv = nextVertex.dY - prevVertex.dY;
                        dv_dx = dv / (2 * sWidth);
                        dv_dy = dv / (2 * sHeight);
                    }
                    Strain strain = new Strain()
                    {
                        XX = du_dx + 0.5 * (Math.Pow(du_dx, 2) + Math.Pow(dv_dy, 2)),
                        YY = dv_dy + 0.5 * (Math.Pow(du_dx, 2) + Math.Pow(dv_dy, 2)),
                        XY = 0.5 * (du_dy + dv_dx + du_dx * du_dy + dv_dx * dv_dy)
                    };
                    currentVertex.strain = strain;
                }
            }
        }

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
