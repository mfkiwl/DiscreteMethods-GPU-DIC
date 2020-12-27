using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Core
{
    public interface ICalculation
    {
        Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] vertexes, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY);
        public void CalculateDisplacement(ImageResult image, Vertex[] StartingVertexes)
        {
            Parallel.For(0, StartingVertexes.Length, i =>
            {
                image.Vertexes[i].dX = image.Vertexes[i].X - StartingVertexes[i].X;
                image.Vertexes[i].dY = image.Vertexes[i].Y - StartingVertexes[i].Y;
            });
        }

        public void CalculateStrain(ImageResult image, int pointsinX, int pointsinY, Vertex[] StartingVertexes)
        {
            double sWidth = StartingVertexes[pointsinY + 1].X - StartingVertexes[0].X;
            double sHeight = StartingVertexes[1].Y - StartingVertexes[0].Y;
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
            Parallel.ForEach(image.Vertexes, vertex =>
            {
                double denominator = -(vertex.strain.YY + vertex.strain.XX);
                if (vertex.strain.YY == 0 || vertex.strain.XX == 0 || denominator == 0)
                {
                    return;
                }
                double r = vertex.strain.XX / denominator;
                double beta = vertex.strain.XX / vertex.strain.YY;
                double betaDenominator = (1.0 + r + r * beta);
                double alpha = ((1.0 + r) * beta + r) / betaDenominator;
                if (beta == 0 || alpha == 0 || betaDenominator == 0)
                    return;
                vertex.stress = new Stress()
                {
                    YY = vertex.dY * Math.Exp(vertex.strain.YY)
                };
                if ((1.0 + r) != 0)
                {
                    var underSqrt = 1.0 + Math.Pow(alpha, 2) - ((2.0 * r) / (1.0 + r)) * alpha;
                    if (underSqrt >= 0)
                        vertex.stress.Eq = vertex.stress.YY * Math.Sqrt(underSqrt);
                }
                vertex.stress.XX = alpha * vertex.stress.YY;
                if (double.IsNaN(vertex.stress.XX))
                {
                    throw new ArithmeticException();
                }
            });
        }
    }
}
