using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Calculation
{
    public class FindPointCpu : ICalculation
    {
        public Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] vertexes, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {
            return vertexes
                .AsParallel()
                .AsOrdered()
                .Select(vertex => FindVertex(searchDelta, subsetDelta, baseImage, nextImage, vertex, BitmapHeight))
                .ToArray();
        }

        private Vertex FindVertex(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex vertex, int bitmapHeight)
        {
            int dx = 0;
            int dy = 0;
            int diff = int.MaxValue;
            for (var v = -searchDelta; v <= searchDelta; v++)
            {
                for (var u = -searchDelta; u <= searchDelta; u++)
                {
                    var sum = 0;
                    for (var y = -subsetDelta; y <= subsetDelta; y++)
                    {
                        for (var x = -subsetDelta; x <= subsetDelta; x++)
                        {
                            int v0 = baseImage[(vertex.X + x) * bitmapHeight + vertex.Y + y];
                            int v1 = nextImage[(vertex.X + x + u) * bitmapHeight + vertex.Y + y + v];
                            sum += (v0 - v1) * (v0 - v1);
                        }
                    }
                    if (sum < diff)
                    {
                        diff = sum;
                        dx = u;
                        dy = v;
                    }
                }
            }
            return new Vertex(vertex.X + dx, vertex.Y + dy);
        }
    }
}
