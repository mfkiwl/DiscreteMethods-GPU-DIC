using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class ColorInterpolationPainter : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults[request.Image.Index];
                var g = Graphics.FromImage(bitmap);
                var trianguled = MIConvexHull.DelaunayTriangulation<Vertex, Cell>.Create(result.Vertexes.ToList(), 20);
                foreach (var triangle in trianguled.Cells)
                {
                    PathGradientBrush pthGrBrush = new PathGradientBrush(triangle.Points)
                    {
                        SurroundColors = triangle.Colors,
                        CenterColor = triangle.InterpolateColor
                    };
                    g.FillPolygon(pthGrBrush, triangle.Points);
                }
            }
            return bitmap;
        }
    }
}
