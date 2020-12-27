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
        public double MaxStrainYY => Vertexes.Max(x => x.strain.YY);
        public double MinStrainYY => Vertexes.Min(x => x.strain.YY);
        public double MaxStrainXY => Vertexes.Max(x => x.strain.XY);
        public double MinStrainXY => Vertexes.Min(x => x.strain.XY);

        public double MaxStressXX => Vertexes.Max(x => x.stress.XX);
        public double MinStressXX => Vertexes.Min(x => x.stress.XX);
        public double MaxStressYY => Vertexes.Max(x => x.stress.YY);
        public double MinStressYY => Vertexes.Min(x => x.stress.YY);
        public double MaxStressEq => Vertexes.Max(x => x.stress.Eq);
        public double MinStressEq => Vertexes.Min(x => x.stress.Eq);

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
