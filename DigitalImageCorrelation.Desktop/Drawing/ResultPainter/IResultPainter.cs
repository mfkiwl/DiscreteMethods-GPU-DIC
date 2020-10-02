using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public interface IResultPainter
    {
        Bitmap Paint(Bitmap bitmap, DrawRequest request);
    }
}
