using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        private PictureBox _picture;
        private ImageContainer _imageContainter;
        private Bitmap _img;
        private static int left;
        private static int top;
        private static int width;
        private static int height;
        private Pen _rectanglePen = new Pen(Color.Red, 2);
        private Pen _circlePen = new Pen(Color.Yellow, 2);
        private double _scale = 1.0;
        private const int DELTA = 5;
        bool isMouseDown = false;
        private SelectedCorner DragedCorner = SelectedCorner.None;

        public double ScaledLeft { get => left * _scale; }
        public double ScaledTop { get => top * _scale; }
        public double ScaledWidth { get => width * _scale; }
        public double ScaledHeight { get => height * _scale; }

        public bool ShouldDraw { get; set; }
        public ImageContainer imageContainer
        {
            get { return _imageContainter; }
            set
            {
                _imageContainter = value;
                _img = value.Image;
            }
        }

        public Painter(PictureBox pictureBox, bool shouldDraw)
        {
            _picture = pictureBox;
            ShouldDraw = shouldDraw;
        }

        public void LoadImage(ImageContainer container)
        {

            imageContainer = container;
            var bmp = imageContainer.Image;
            if (width == 0)
            {
                ReloadSizes(bmp);
            }
            RedrawImage(bmp);
        }

        public void ReloadSizes(Bitmap bmp)
        {
            width = Convert.ToInt32(bmp.Width * 0.8);
            height = Convert.ToInt32(bmp.Height * 0.8);
            left = Convert.ToInt32(bmp.Width * 0.1);
            top = Convert.ToInt32(bmp.Height * 0.1);
        }

        public bool IsInCorner(Point point)
        {
            if (Math.Abs(ScaledLeft - point.X) < DELTA && Math.Abs(ScaledTop - point.Y) < DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft - point.X) < DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < DELTA && Math.Abs(ScaledTop - point.Y) < DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < DELTA)
            {
                DragedCorner = SelectedCorner.RightBottom;
                return true;
            }
            return false;
        }

        public int CalculateDefaultScale()
        {
            var bmp = imageContainer.Image;
            var scaleX = ((double)_picture.Parent.ClientSize.Width / (double)bmp.Width) * 100.0;
            var scaleY = ((double)_picture.Parent.ClientSize.Height / (double)bmp.Height) * 100.0;
            return Math.Min((int)scaleX, (int)scaleY);
        }

        internal void MouseDown(object sender, MouseEventArgs e)
        {
            if (IsInCorner(e.Location))
            {
                isMouseDown = true;
            }
        }

        internal void MouseUp(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                var point = new Point() { X = (int)(e.Location.X * 1.0 / _scale), Y = (int)(e.Location.Y * 1.0 / _scale) };
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
                RedrawImage();
            }
        }

        internal void DrawSquareChange(bool value)
        {
            ShouldDraw = value;
            if (_img != null)
            {
                RedrawImage();
            }
        }

        internal void SetScaleOfImage(double value)
        {
            _scale = value / 100.0;
            if (_img != null)
            {
                RedrawImage();
            }
        }

        internal void ResetZoom()
        {
            if (_img != null)
            {
                RedrawImage();
            }
        }

        private Bitmap ScaleBitmap(Bitmap img)
        {
            var scaleWidth = (int)(img.Width * _scale);
            var scaleHeight = (int)(img.Height * _scale);
            return new Bitmap(img, (int)scaleWidth, (int)scaleHeight);
        }

        public void RedrawImage()
        {
            RedrawImage(_img.Clone() as Bitmap);
        }

        private void RedrawImage(Bitmap bmp)
        {
            bmp = ScaleBitmap(bmp);
            DrawRectagle(bmp);
            _picture.Image = bmp;
        }

        private Bitmap DrawRectagle(Bitmap img)
        {
            if (ShouldDraw)
            {
                Graphics g = Graphics.FromImage(img);
                g.DrawRectangle(_rectanglePen, new Rectangle((int)(ScaledLeft), (int)(ScaledTop), (int)(ScaledWidth), (int)(ScaledHeight)));
                g.DrawEllipse(_circlePen, (int)(ScaledLeft) - DELTA, (int)(ScaledTop) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_circlePen, (int)(ScaledLeft + ScaledWidth) - DELTA, (int)(ScaledTop) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_circlePen, (int)(ScaledLeft) - DELTA, (int)(ScaledTop + ScaledHeight) - DELTA, 2 * DELTA, 2 * DELTA);
                g.DrawEllipse(_circlePen, (int)(ScaledLeft + ScaledWidth) - DELTA, (int)(ScaledTop + ScaledHeight) - DELTA, 2 * DELTA, 2 * DELTA);

            }
            return img;
        }

    }
    enum SelectedCorner
    {
        None,
        LeftTop,
        LeftBottom,
        RightTop,
        RightBottom
    }
}

