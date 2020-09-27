using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class EmptyResultPainter : IResultPainter
    {
        public async Task<Bitmap> Paint(Bitmap bitmap, DrawRequest request)
        {
            return bitmap;
        }
    }
}
