using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop.Drawing.ResultPainter
{
    public class PointResultPainter : IResultPainter
    {
        private readonly Pen _rectanglePen = new Pen(Color.FromArgb(200, 0, 0, 255), 1);
        private readonly Pen _elipsePen = new Pen(Color.FromArgb(200, 255, 0, 0), 1);
        public Bitmap Paint(Bitmap bitmap, DrawRequest request)
        {
            try
            {
                if (request.AnalyzeResults != null && request.AnalyzeResults.ImageResults.ContainsKey(request.Image.Index))
                {
                    var result = request.AnalyzeResults.ImageResults[request.Image.Index];
                    var g = Graphics.FromImage(bitmap);
                    foreach (var point in result.Vertexes)
                    {
                        g.DrawRectangle(_rectanglePen, new Rectangle(point.X - request.SubsetDelta, point.Y - request.SubsetDelta, request.SubsetDelta * 2, request.SubsetDelta * 2));
                        g.DrawEllipse(_elipsePen, new Rectangle(point.X, point.Y, 1, 1));
                    }
                }
                return bitmap;
            }
            catch (Exception ex)
            {

                var tmp = 0;


            }
            return bitmap;
        }
    }
}
