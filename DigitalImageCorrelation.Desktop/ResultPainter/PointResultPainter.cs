using DigitalImageCorrelation.Core;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class PointResultPainter : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, AnalyzeResult result)
        {
            return bitmap;
        }
    }
}
