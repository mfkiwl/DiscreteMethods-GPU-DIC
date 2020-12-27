using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Drawing;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class InterpolateStressXX : InterpolateColorsTemplate, IResultPainter
    {
        public override Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                double max = request.AnalyzeResults.MaxStressXX;
                double min = request.AnalyzeResults.MinStressXX;
                var vertexes = ColorHelper.CalculateStressColorsXX(max, min, result.Vertexes);
                return Paint(bitmap, vertexes);
            }
            return bitmap;
        }
    }
}
