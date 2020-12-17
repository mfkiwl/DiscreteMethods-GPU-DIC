using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Core.Structures
{
    public class ImageResult
    {
        public Vertex[] Vertexes;
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

        public void CalculateDisplacementColorsDX(double maxDx, double minDx)
        {
            var denominatorDx = (maxDx - minDx) != 0 ? (maxDx - minDx) : 1;
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                vertex.ColorDx = Utils.GetColor(vertex.dX, minDx, denominatorDx);
            });
        }

        public void CalculateDisplacementColorsDY(double maxDy, double minDy)
        {
            var denominatorDy = (maxDy - minDy) != 0 ? (maxDy - minDy) : 1;
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                vertex.ColorDy = Utils.GetColor(vertex.dY, minDy, denominatorDy);
            });
        }

        public void CalculateStrainColorsXX(double maxStrainXX, double minxStrainXX)
        {
            var denominatorXX = (maxStrainXX - minxStrainXX) != 0 ? (maxStrainXX - minxStrainXX) : 1;
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                vertex.strain.ColorXX = Utils.GetColor(vertex.strain.XX, minxStrainXX, denominatorXX);
            });
        }

        public void CalculateStrainColorsXY(double maxStrainXY, double minxStrainXY)
        {
            var denominatorXY = (maxStrainXY - minxStrainXY) != 0 ? (maxStrainXY - minxStrainXY) : 1;
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                vertex.strain.ColorXY = Utils.GetColor(vertex.strain.XY, minxStrainXY, denominatorXY);
            });
        }

        public void CalculateStrainColorsYY(double maxStrainYY, double minxStrainYY)
        {
            var denominatorYY = (maxStrainYY - minxStrainYY) != 0 ? (maxStrainYY - minxStrainYY) : 1;
            Parallel.ForEach(Vertexes.Cast<Vertex>(),
            vertex =>
            {
                vertex.strain.ColorYY = Utils.GetColor(vertex.strain.YY, minxStrainYY, denominatorYY);
            });
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
