using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class EmptyResultPainter : IResultPainter
    {
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            return bitmap;
        }
    }
}
