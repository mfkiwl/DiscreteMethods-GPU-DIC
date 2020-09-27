using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public interface IResultPainter
    {
        Task<Bitmap> Paint(Bitmap bitmap, DrawRequest request);
    }
}
