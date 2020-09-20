using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class ArrowResultPainter : IResultPainter
    {
        private readonly Pen _arrowPen = new Pen(Color.FromArgb(255, 0, 0, 255), 5);

        public Bitmap Paint(Bitmap bitmap, AnalyzeResult result, DrawRequest request)
        {
            var startingPoints = request.Image.pos.CalculateStartingPoints(request.PointsinX, request.PointsinY).ToArray();
            if (result != null)
            {
                Graphics g = Graphics.FromImage(bitmap);
                foreach (var (endpoint, index) in result.Points.WithIndex())
                {
                    _arrowPen.StartCap = LineCap.Flat;
                    _arrowPen.EndCap = LineCap.ArrowAnchor;
                    g.DrawLine(_arrowPen, startingPoints[index], endpoint);
                }
            }
            return bitmap;
        }
    }
}
