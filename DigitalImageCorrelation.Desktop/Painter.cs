using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        private PictureBox _picture;
        private Pen _rectanglePen = new Pen(Color.Red, 2);
        private Pen _cornerPen = new Pen(Color.Yellow, 2);
        private Pen _circlePen = new Pen(Color.Red, 2);

        public const int DELTA = 5;
        public Painter(PictureBox pictureBox)
        {
            _picture = pictureBox;
        }

        public int CalculateDefaultScale(DrawRequest request)
        {
            var bmp = request.image.Bmp;
            var scaleX = (request.PictureWidth / (double)bmp.Width) * 100.0;
            var scaleY = (request.PictureHeight / (double)bmp.Height) * 100.0;
            return Math.Min((int)scaleX, (int)scaleY);
        }


        public void RedrawImage(DrawRequest request)
        {
            var bmp = request.image.Bmp;
            bmp = ScaleBitmap(bmp, request.image.scale);
            DrawRectagle(request, bmp, request.ShowCropBox);
            DrawPoints(bmp, request.image.CalculatePoints(request.PointsinX, request.PointsinY), request.ShowCropBox);
            _picture.Image = bmp;
        }
        private Bitmap ScaleBitmap(Bitmap bmp, double scale)
        {
            var scaleWidth = (int)(bmp.Width * scale);
            var scaleHeight = (int)(bmp.Height * scale);
            return new Bitmap(bmp, (int)scaleWidth, (int)scaleHeight);
        }

        private Bitmap DrawRectagle(DrawRequest r, Bitmap bmp, bool ShowCropBox)
        {
            if (ShowCropBox)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawRectangle(_rectanglePen, new Rectangle((int)(r.image.ScaledLeft), (int)(r.image.ScaledTop), (int)(r.image.ScaledWidth), (int)(r.image.ScaledHeight)));
                g.DrawEllipse(_cornerPen, (int)(r.image.ScaledLeft) - DELTA, (int)(r.image.ScaledTop) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.image.ScaledLeft + r.image.ScaledWidth) - DELTA, (int)(r.image.ScaledTop) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.image.ScaledLeft) - DELTA, (int)(r.image.ScaledTop + r.image.ScaledHeight) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.image.ScaledLeft + r.image.ScaledWidth) - DELTA, (int)(r.image.ScaledTop + r.image.ScaledHeight) - DELTA, 2 * DELTA, 2 * DELTA);

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
                    g.DrawEllipse(_circlePen, (int)point.X, point.Y, 2, 2);

                }
            }
            return img;
        }
    }
}

