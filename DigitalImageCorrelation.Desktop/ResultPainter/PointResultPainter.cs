using DigitalImageCorrelation.Desktop.Requests;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.ResultPainter
{
    public class PointResultPainter : IResultPainter
    {
        private readonly Pen _rectanglePen = new Pen(Color.FromArgb(200, 0, 0, 255), 1);
        private readonly Pen _elipsePen = new Pen(Color.FromArgb(200, 255, 0, 0), 1);
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            if (request.AnalyzeResults != null && request.AnalyzeResults.ContainsKey(request.Image.Index))
            {
                var result = request.AnalyzeResults[request.Image.Index];
                var g = Graphics.FromImage(bitmap);
                foreach (var point in result.Points)
                {
                    g.DrawRectangle(_rectanglePen, new Rectangle(point.X - request.SubsetDelta, point.Y - request.SubsetDelta, request.SubsetDelta * 2, request.SubsetDelta * 2));
                    g.DrawEllipse(_elipsePen, new Rectangle(point.X, point.Y, 1, 1));
                }
            }
            return bitmap;
        }
    }
}
