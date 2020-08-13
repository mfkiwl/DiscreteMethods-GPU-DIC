using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class ImageContainer
    {
        private Bitmap _image;
        public string filename { get; set; }
        public Bitmap Bmp
        {
            get { return _image.Clone() as Bitmap; }
            set { _image = value; }
        }
        public static int left;
        public static int top;
        public static int width;
        public static int height;
        public double scale = 1.0;
        public double ScaledLeft { get => left * scale; }
        public double ScaledTop { get => top * scale; }
        public double ScaledWidth { get => width * scale; }
        public double ScaledHeight { get => height * scale; }

        public int Index;
        private bool isMouseDown = false;
        private SelectedCorner DragedCorner = SelectedCorner.None;

        public ImageContainer(Bitmap bitmap, string name, int index)
        {
            _image = bitmap;
            filename = name;
            ReloadSizes(bitmap);
            Index = index;
        }

        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (IsInCorner(e.Location))
            {
                isMouseDown = true;
            }
        }

        private void ReloadSizes(Bitmap bmp)
        {
            width = Convert.ToInt32(bmp.Width * 0.8);
            height = Convert.ToInt32(bmp.Height * 0.8);
            left = Convert.ToInt32(bmp.Width * 0.1);
            top = Convert.ToInt32(bmp.Height * 0.1);
        }

        public bool IsInCorner(Point point)
        {
            if (Math.Abs(ScaledLeft - point.X) < Painter.DELTA && Math.Abs(ScaledTop - point.Y) < Painter.DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft - point.X) < Painter.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Painter.DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Painter.DELTA && Math.Abs(ScaledTop - point.Y) < Painter.DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Painter.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Painter.DELTA)
            {
                DragedCorner = SelectedCorner.RightBottom;
                return true;
            }
            return false;
        }

        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                var point = new Point() { X = (int)(e.Location.X * 1.0 / scale), Y = (int)(e.Location.Y * 1.0 / scale) };
                var xVector = 0;
                var yVector = 0;
                if (DragedCorner == SelectedCorner.LeftTop)
                {
                    xVector = left - point.X;
                    yVector = top - point.Y;
                    left = point.X;
                    top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.LeftBottom)
                {
                    xVector = left - point.X;
                    yVector = point.Y - top - height;
                    left = point.X;
                }
                else if (DragedCorner == SelectedCorner.RightTop)
                {
                    xVector = point.X - left - width;
                    yVector = top - point.Y;
                    top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.RightBottom)
                {
                    xVector = point.X - left - width;
                    yVector = point.Y - top - height;
                }
                width += xVector;
                height += yVector;
                DragedCorner = SelectedCorner.None;
                isMouseDown = false;
            }
        }


        public IEnumerable<Point> CalculatePoints(int w, int h)
        {
            var spaceX = ScaledWidth / (w + 1);
            var spaceY = ScaledHeight / (h + 1);
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    yield return new Point((int)((i + 1) * spaceX + ScaledLeft), (int)((j + 1) * spaceY + ScaledTop));
                }
            }
        }

        internal void SetScaleOfImage(double zoom)
        {
            scale = zoom / 100.0;
        }
    }
    enum SelectedCorner
    {
        None,
        RightBottom,
        RightTop,
        LeftBottom,
        LeftTop
    }
}
