using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public interface IResultPainter
    {
        Bitmap Paint(Bitmap bitmap, DrawRequest request);
    }
}
