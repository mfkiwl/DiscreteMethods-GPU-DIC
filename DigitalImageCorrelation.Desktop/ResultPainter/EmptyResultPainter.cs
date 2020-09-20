using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class EmptyResultPainter : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, AnalyzeResult result, DrawRequest request)
        {
            return bitmap;
        }
    }
}
