using DigitalImageCorrelation.Core;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public interface IResultPainter
    {
        Bitmap Paint(Bitmap bitmap, AnalyzeResult points);
    }
}
