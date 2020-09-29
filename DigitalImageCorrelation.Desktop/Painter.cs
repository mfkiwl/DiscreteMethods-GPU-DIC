using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.ResultPainter;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        private readonly Pen _rectanglePen = new Pen(Color.Red, 2);
        private readonly Pen _cornerPen = new Pen(Color.Yellow, 2);
        private readonly Pen _circlePen = new Pen(Color.Red, 2);
        private IResultPainter _resultPainter;
        private object _painterLock = new object();
        public double CalculateDefaultScale(DrawRequest request)
        {
            var bmp = request.Image.Bmp;
            var scaleX = (request.PictureWidth / bmp.Width);
            var scaleY = (request.PictureHeight / bmp.Height);
            return Math.Min(scaleX, scaleY);
        }

        public Bitmap DrawColorScale(int width, int height)
        {
            var bmp = new Bitmap(width, height);
            var g = Graphics.FromImage(bmp);
            var linGrBrush = new LinearGradientBrush(new Rectangle(0, 0, (width / 4) + 2, height), Color.Blue, Color.Green, LinearGradientMode.Horizontal);
            g.FillRectangle(linGrBrush, new Rectangle(0, 0, (width / 4) + 2, height));

            var linGrBrush2 = new LinearGradientBrush(new Rectangle(width / 4, 0, (width / 4) + 2, height), Color.Green, Color.Yellow, LinearGradientMode.Horizontal);
            g.FillRectangle(linGrBrush2, new Rectangle(width / 4, 0, (width / 4) + 2, height));

            var linGrBrush3 = new LinearGradientBrush(new Rectangle(width / 2, 0, (width / 4) + 2, height), Color.Yellow, Color.Orange, LinearGradientMode.Horizontal);
            g.FillRectangle(linGrBrush3, new Rectangle(width / 2, 0, (width / 4) + 2, height));

            var linGrBrush4 = new LinearGradientBrush(new Rectangle(width * 3 / 4, 0, (width / 4) + 2, height), Color.Orange, Color.Red, LinearGradientMode.Horizontal);
            g.FillRectangle(linGrBrush4, new Rectangle(width * 3 / 4, 0, (width / 4) + 2, height));
            return bmp;
        }

        public async Task<Bitmap> DrawImage(DrawRequest request)
        {
            if (request.Image != null)
            {
                return await Task.Run(() =>
                {
                    lock (_painterLock)
                    {
                        _resultPainter = ChooseResultPainter(request.Type);
                        var bmp = new Bitmap(request.Image.BitmapWidth, request.Image.BitmapHeight);
                        _resultPainter.Paint(bmp, request);
                        DrawPoints(bmp, request.Image.square.CalculateStartingPoints(request.PointsinX, request.PointsinY), request.ShowCropBox);
                        bmp = ScaleBitmap(bmp, SquareLocation.Scale);
                        DrawRectagle(request, bmp, request.ShowCropBox);
                        return bmp;
                    }
                });
            }
            return await Task.FromResult<Bitmap>(null);
        }

        private IResultPainter ChooseResultPainter(DrawingType type)
        {
            switch (type)
            {
                case (DrawingType.Points):
                    return new PointResultPainter();
                case (DrawingType.DisplacementVectors):
                    return new ArrowResultPainter();
                case (DrawingType.DisplacementX):
                    return new InterpolateDisplacementdX();
                case (DrawingType.DisplacementY):
                    return new InterpolateDisplacementdY();
                case (DrawingType.StrainShear):
                case (DrawingType.StrainX):
                case (DrawingType.StrainY):
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
                g.DrawRectangle(_rectanglePen, new Rectangle((int)r.Image.square.ScaledLeft, (int)r.Image.square.ScaledTop, (int)r.Image.square.ScaledWidth, (int)r.Image.square.ScaledHeight));
                g.DrawEllipse(_cornerPen, (int)r.Image.square.ScaledLeft - Utils.DELTA, (int)r.Image.square.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.square.ScaledLeft + r.Image.square.ScaledWidth) - Utils.DELTA, (int)r.Image.square.ScaledTop - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)r.Image.square.ScaledLeft - Utils.DELTA, (int)(r.Image.square.ScaledTop + r.Image.square.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, (int)(r.Image.square.ScaledLeft + r.Image.square.ScaledWidth) - Utils.DELTA, (int)(r.Image.square.ScaledTop + r.Image.square.ScaledHeight) - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
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

