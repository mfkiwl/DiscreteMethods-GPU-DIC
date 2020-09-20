using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public interface IResultPainter
    {
        Bitmap Paint(Bitmap bitmap, AnalyzeResult result, DrawRequest request);
    }
}
