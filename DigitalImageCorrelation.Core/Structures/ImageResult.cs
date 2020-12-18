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
