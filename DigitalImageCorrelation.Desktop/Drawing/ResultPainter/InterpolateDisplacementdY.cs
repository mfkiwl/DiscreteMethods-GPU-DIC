using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateDisplacementdY : InterpolateColorsTemplate, IResultPainter
    {
        public override Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double maxdY = request.AnalyzeResults.MaxDy;
                double mindY = request.AnalyzeResults.MinDy;
                var vertexes = ColorHelper.CalculateDisplacementColorsDY(maxdY, mindY, result.Vertexes);
                return Paint(bitmap, vertexes);
            }
            return bitmap;
        }
    }
}
