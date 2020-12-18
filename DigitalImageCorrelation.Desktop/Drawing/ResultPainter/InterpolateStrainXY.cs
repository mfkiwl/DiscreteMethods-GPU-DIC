using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateStrainXY : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double maxStrainXY = request.AnalyzeResults.MaxStrainXY;
                double minStrainXY = request.AnalyzeResults.MinStrainXY;
                var vertexes = ColorHelper.CalculateStrainColorsXY(maxStrainXY, minStrainXY, result.Vertexes);
                var g = Graphics.FromImage(bitmap);
                var trianguled = MIConvexHull.DelaunayTriangulation<ColorVertex, Cell>.Create(vertexes.ToArray(), 0.001);
                foreach (var triangle in trianguled.Cells)
                {
                    PathGradientBrush pthGrBrush = new PathGradientBrush(triangle.Points)
                    {
                        SurroundColors = triangle.Colors,
                        CenterColor = triangle.InterpolateColor(triangle.Colors)
                    };
                    g.FillPolygon(pthGrBrush, triangle.Points);
                }
            }
            return bitmap;
        }
    }
}
