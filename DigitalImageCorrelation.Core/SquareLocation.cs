using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Core
{
    public class SquareLocation
    {
        public int Left;
        public int Top;
        public int Width;
        public int Height;
        public double Scale = 1.0;
        private SelectedCorner DragedCorner = SelectedCorner.None;
        private bool isMouseDown = false;

        public double ScaledLeft { get => Left * Scale; }
        public double ScaledTop { get => Top * Scale; }
        public double ScaledWidth { get => Width * Scale; }
        public double ScaledHeight { get => Height * Scale; }
        public SquareLocation() { }
        public SquareLocation(int bitmapWidth, int BitmapHeight)
        {
            ReloadSizes(bitmapWidth, BitmapHeight);
        }
        public void ReloadSizes(int bitmapWidth, int BitmapHeight)
        {
            Width = Convert.ToInt32(bitmapWidth * 0.8);
            Height = Convert.ToInt32(BitmapHeight * 0.8);
            Left = Convert.ToInt32(bitmapWidth * 0.1);
            Top = Convert.ToInt32(BitmapHeight * 0.1);
        }

        public IEnumerable<Point> CalculateStartingPoints(int w, int h)
        {
            double spaceX = Width / (w + 1.0);
            double spaceY = Height / (h + 1.0);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    yield return new Point((int)((i + 1.0) * spaceX + Left), (int)((j + 1.0) * spaceY + Top));
                }
            }
        }
        public Vertex[] CalculateStartingVertexes(int w, int h)
        {
            var result = new Vertex[w * h];
            double spaceX = Width / (w + 1.0);
            double spaceY = Height / (h + 1.0);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    result[i * h + j] = new Vertex((int)((i + 1.0) * spaceX + Left), (int)((j + 1.0) * spaceY + Top), 0, 0);
                }
            }
            return result;
        }

        public void MouseDown(Point point)
        {
            if (Math.Abs(ScaledLeft - point.X) < Utils.DELTA && Math.Abs(ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                isMouseDown = true;
            }
            else if (Math.Abs(ScaledLeft - point.X) < Utils.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                isMouseDown = true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Utils.DELTA && Math.Abs(ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                isMouseDown = true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Utils.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightBottom;
                isMouseDown = true;
            }
        }
        public void MouseUp(Point p, int bitmapWidth, int bitmapHeight)
        {
            if (isMouseDown)
            {
                var point = new Point() { X = (int)(p.X * 1.0 / Scale), Y = (int)(p.Y * 1.0 / Scale) };
                if (point.X <= 0 || point.Y <= 0 || point.X >= bitmapWidth || point.Y >= bitmapHeight)
                {
                    return;
                }
                var xVector = 0;
                var yVector = 0;
                switch (DragedCorner)
                {
                    case SelectedCorner.LeftTop:
                        xVector = Left - point.X;
                        yVector = Top - point.Y;
                        Left = point.X;
                        Top = point.Y;
                        break;
                    case SelectedCorner.LeftBottom:
                        xVector = Left - point.X;
                        yVector = point.Y - Top - Height;
                        Left = point.X;
                        break;
                    case SelectedCorner.RightTop:
                        xVector = point.X - Left - Width;
                        yVector = Top - point.Y;
                        Top = point.Y;
                        break;
                    case SelectedCorner.RightBottom:
                        xVector = point.X - Left - Width;
                        yVector = point.Y - Top - Height;
                        break;
                }
                Width += xVector;
                Height += yVector;
                DragedCorner = SelectedCorner.None;
                isMouseDown = false;
            }
        }
    }
}
