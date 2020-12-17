using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateDisplacementdY : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double maxdY = request.AnalyzeResults.MaxDy;
                double mindY = request.AnalyzeResults.MinDy;
                result.CalculateDisplacementColorsDY(maxdY, mindY);
                var g = Graphics.FromImage(bitmap);
                var trianguled = MIConvexHull.DelaunayTriangulation<Vertex, Cell>.Create(result.Vertexes, 0.001);
                foreach (var triangle in trianguled.Cells)
                {
                    PathGradientBrush pthGrBrush = new PathGradientBrush(triangle.Points)
                    {
                        SurroundColors = triangle.ColorsDy,
                        CenterColor = triangle.InterpolateColor(triangle.ColorsDy)
                    };
                    g.FillPolygon(pthGrBrush, triangle.Points);
                }
            }
            return bitmap;
        }
    }
}
