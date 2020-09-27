using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.ResultPainter;
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
        private IResultPainter _resultPainter;

        public double CalculateDefaultScale(DrawRequest request)
        {
            var bmp = request.Image.Bmp;
            var scaleX = (request.PictureWidth / bmp.Width);
            var scaleY = (request.PictureHeight / bmp.Height);
            return Math.Min(scaleX, scaleY);
        }


        public Bitmap GetBackgroundImage(DrawRequest request)
        {
            return request.Image.BmpRaw;
        }

        public Bitmap DrawImage(DrawRequest request)
        {
            if (request.Image != null)
            {
                _resultPainter = ChooseResultPainter(request.Type);
                var bmp = new Bitmap(request.Image.BmpRaw.Width, request.Image.BmpRaw.Height);
                _resultPainter.Paint(bmp, request);
                DrawPoints(bmp, request.Image.pos.CalculateStartingPoints(request.PointsinX, request.PointsinY), request.ShowCropBox);
                bmp = ScaleBitmap(bmp, Position.scale);
                DrawRectagle(request, bmp, request.ShowCropBox);
                return bmp;
            }
            return null;
        }

        private IResultPainter ChooseResultPainter(DrawingType type)
        {
            switch (type)
            {
                case (DrawingType.Points):
                    return new PointResultPainter();
                case (DrawingType.DisplacementVectors):
                    return new ArrowResultPainter();
                case (DrawingType.StrainShear):
                case (DrawingType.StrainX):
                case (DrawingType.StrainY):
                    return new ColorInterpolationPainter();
                case (DrawingType.Image):
                default:
                    return new EmptyResultPainter();
            }
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
                g.DrawRectangle(_rectanglePen, new Rectangle((int)r.Image.pos.ScaledLeft, (int)r.Image.pos.ScaledTop, (int)r.Image.pos.ScaledWidth, (int)r.Image.pos.ScaledHeight));
                g.DrawEllipse(_cornerPen, (int)r.Image.pos.ScaledLeft - Utils.DELTA, (int)r.Image.pos.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.pos.ScaledLeft + r.Image.pos.ScaledWidth) - Utils.DELTA, (int)r.Image.pos.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)r.Image.pos.ScaledLeft - Utils.DELTA, (int)(r.Image.pos.ScaledTop + r.Image.pos.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.pos.ScaledLeft + r.Image.pos.ScaledWidth) - Utils.DELTA, (int)(r.Image.pos.ScaledTop + r.Image.pos.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
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

