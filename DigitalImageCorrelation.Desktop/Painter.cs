using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        private readonly Pen _rectanglePen = new Pen(Color.Red, 2);
        private readonly Pen _cornerPen = new Pen(Color.Yellow, 2);
        private readonly Pen _circlePen = new Pen(Color.Red, 2);

        public int CalculateDefaultScale(DrawRequest request)
        {
            var bmp = request.Image.Bmp;
            var scaleX = request.PictureWidth / bmp.Width * 100.0;
            var scaleY = request.PictureHeight / bmp.Height * 100.0;
            return Math.Min((int)scaleX, (int)scaleY);
        }


        public Bitmap DrawImage(DrawRequest request)
        {
            if (request.Image != null)
            {
                var bmp = request.Image.Bmp;
                bmp = ScaleBitmap(bmp, request.Image.scale);
                DrawRectagle(request, bmp, request.ShowCropBox);
                DrawPoints(bmp, request.Image.CalculatePoints(request.PointsinX, request.PointsinY), request.ShowCropBox);
                return bmp;
            }
            return null;
        }
        private Bitmap ScaleBitmap(Bitmap bmp, double scale)
        {
            var scaleWidth = (int)(bmp.Width * scale);
            var scaleHeight = (int)(bmp.Height * scale);
            return new Bitmap(bmp, scaleWidth, scaleHeight);
        }

        private Bitmap DrawRectagle(DrawRequest r, Bitmap bmp, bool ShowCropBox)
        {
            if (ShowCropBox)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawRectangle(_rectanglePen, new Rectangle((int)r.Image.ScaledLeft, (int)r.Image.ScaledTop, (int)r.Image.ScaledWidth, (int)r.Image.ScaledHeight));
                g.DrawEllipse(_cornerPen, (int)r.Image.ScaledLeft - Utils.DELTA, (int)r.Image.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.ScaledLeft + r.Image.ScaledWidth) - Utils.DELTA, (int)r.Image.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)r.Image.ScaledLeft - Utils.DELTA, (int)(r.Image.ScaledTop + r.Image.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.ScaledLeft + r.Image.ScaledWidth) - Utils.DELTA, (int)(r.Image.ScaledTop + r.Image.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
            }
            return bmp;
        }

        private Bitmap DrawPoints(Bitmap img, IEnumerable<Point> points, bool ShouldDraw)
        {
            if (ShouldDraw)
            {
                Graphics g = Graphics.FromImage(img);
                foreach (var point in points)
                {
                    g.DrawEllipse(_circlePen, point.X, point.Y, 2, 2);
                }
            }
            return img;
        }
    }
}

