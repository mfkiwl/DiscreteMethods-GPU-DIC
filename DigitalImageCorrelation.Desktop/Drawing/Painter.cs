﻿using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Drawing.ResultPainter;
using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Desktop.Drawing
{
    public class Painter
    {
        private readonly Pen _rectanglePen = new Pen(Color.Red, 2);
        private readonly Pen _cornerPen = new Pen(Color.Yellow, 2);
        private readonly Pen _circlePen = new Pen(Color.Red, 2);
        private IResultPainter _resultPainter;
        private readonly object _painterLock = new object();
        public double CalculateDefaultScale(DrawRequest request)
        {
            var bmp = request.Image.Bmp;
            var scaleX = request.PictureWidth / bmp.Width;
            var scaleY = request.PictureHeight / bmp.Height;
            return Math.Min(scaleX, scaleY);
        }

        public Bitmap DrawColorScale(int width, int height)
        {
            var bmp = new Bitmap(width, height);
            var g = Graphics.FromImage(bmp);
            var rect3 = new Rectangle(0, height * 3 / 4, width, height / 4 + 2);
            var linGrBrush4 = new LinearGradientBrush(rect3, Color.Green, Color.Blue, LinearGradientMode.Vertical);
            g.FillRectangle(linGrBrush4, rect3);
            var rect2 = new Rectangle(0, height / 2, width, height / 4 + 2);
            var linGrBrush3 = new LinearGradientBrush(rect2, Color.Yellow, Color.Green, LinearGradientMode.Vertical);
            g.FillRectangle(linGrBrush3, rect2);
            var rect1 = new Rectangle(0, height / 4, width, height / 4 + 2);
            var linGrBrush2 = new LinearGradientBrush(rect1, Color.Orange, Color.Yellow, LinearGradientMode.Vertical);
            g.FillRectangle(linGrBrush2, rect1);
            var rect0 = new Rectangle(0, 0, width, height / 4 + 2);
            var linGrBrush = new LinearGradientBrush(rect0, Color.Red, Color.Orange, LinearGradientMode.Vertical);
            g.FillRectangle(linGrBrush, rect0);
            return bmp;
        }

        public async Task<Bitmap> DrawImage(DrawRequest request)
        {
            if (request.Image != null)
            {
                return await Task.Run(() =>
                {
                    var bmp = new Bitmap(request.Image.BitmapWidth, request.Image.BitmapHeight);
                    lock (_painterLock)
                    {
                        _resultPainter = ChooseResultPainter(request.Type);
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

        public async Task<Bitmap> DrawImage(DrawRequest request, Bitmap bmp)
        {
            if (request.Image != null)
            {
                return await Task.Run(() =>
                {
                    lock (_painterLock)
                    {
                        _resultPainter = ChooseResultPainter(request.Type);
                        _resultPainter.Paint(bmp, request);
                        DrawPoints(bmp, request.Image.square.CalculateStartingPoints(request.PointsinX, request.PointsinY), request.ShowCropBox);
                        DrawRectagleNoScale(bmp, request.ShowCropBox);
                        return bmp;
                    }
                });
            }
            return await Task.FromResult<Bitmap>(null);
        }

        private IResultPainter ChooseResultPainter(DrawingType type)
        {
            return type switch
            {
                DrawingType.Points => new PointResultPainter(),
                DrawingType.DisplacementVectors => new ArrowResultPainter(),
                DrawingType.DisplacementX => new InterpolateDisplacementdX(),
                DrawingType.DisplacementY => new InterpolateDisplacementdY(),
                DrawingType.StrainX => new InterpolateStrainXX(),
                DrawingType.StrainY => new InterpolateStrainYY(),
                DrawingType.StrainShear => new InterpolateStrainXY(),
                DrawingType.StressX => new InterpolateStressXX(),
                DrawingType.StressY => new InterpolateStressYY(),
                DrawingType.StressEq => new InterpolateStressEq(),
                _ => new EmptyResultPainter(),
            };
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

        private Bitmap DrawRectagleNoScale(Bitmap bmp, bool ShowCropBox)
        {
            if (ShowCropBox)
            {
                Graphics g = Graphics.FromImage(bmp);
                g.DrawRectangle(_rectanglePen, new Rectangle(SquareLocation.Left, SquareLocation.Top, SquareLocation.Width, SquareLocation.Height));
                g.DrawEllipse(_cornerPen, SquareLocation.Left - Utils.DELTA, SquareLocation.Top - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, SquareLocation.Left + SquareLocation.Width - Utils.DELTA, SquareLocation.Top - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, SquareLocation.Left - Utils.DELTA, SquareLocation.Top + SquareLocation.Height - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
                g.DrawEllipse(_cornerPen, SquareLocation.Left + SquareLocation.Width - Utils.DELTA, SquareLocation.Top + SquareLocation.Height - Utils.DELTA, 2 * Utils.DELTA, 2 * Utils.DELTA);
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

