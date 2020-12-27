using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateStressEq : InterpolateColorsTemplate, IResultPainter
    {
        public override Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double max = request.AnalyzeResults.MaxStressEq;
                double min = request.AnalyzeResults.MinStressEq;
                var vertexes = ColorHelper.CalculateStressColorsEq(max, min, result.Vertexes);
                return Paint(bitmap, vertexes);
            }
            return bitmap;
        }
    }
}
