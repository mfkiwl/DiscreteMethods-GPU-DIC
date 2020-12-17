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
        public void CalculateDisplacement(ImageResult image)
        {
            Parallel.For(0, image.StartingVertexes.Length, i =>
             {
                 image.Vertexes[i].dX = image.Vertexes[i].X - image.StartingVertexes[i].X;
                 image.Vertexes[i].dY = image.Vertexes[i].Y - image.StartingVertexes[i].Y;
             });
        }

        public void CalculateStrain(ImageResult image, int pointsinX, int pointsinY)
        {
            double sWidth = image.StartingVertexes[pointsinY + 1].X - image.StartingVertexes[0].X;
            double sHeight = image.StartingVertexes[1].Y - image.StartingVertexes[0].Y;
            Parallel.For(0, pointsinY, y =>
            {
                for (var x = 0; x < pointsinX; x++)
                {
                    var currentVertex = image.Vertexes[x + y * pointsinX];
                    double du_dx = 0;
                    double du_dy = 0;
                    double dv_dx = 0;
                    double dv_dy = 0;
                    if (x - 1 >= 0 && x + 1 < pointsinX)
                    {
                        var nextVertex = image.Vertexes[x + 1 + y * pointsinX];
                        var prevVertex = image.Vertexes[x - 1 + y * pointsinX];
                        var du = nextVertex.dX - prevVertex.dX;
                        du_dx = du / (2.0 * sWidth);
                        du_dy = du / (2.0 * sHeight);
                    }

                    if (y - 1 >= 0 && y + 1 < pointsinY)
                    {
                        var nextVertex = image.Vertexes[x + (y + 1) * pointsinX];
                        var prevVertex = image.Vertexes[x + (y - 1) * pointsinX];
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
            });
        }

        public void CalculateStress(ImageResult image)
        {
            throw new System.NotImplementedException();
        }

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
