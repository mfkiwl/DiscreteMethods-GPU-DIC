using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        private PictureBox _picture;
        private CheckBox _checkbox;
        private TrackBar _zoomTrackBar;
        private ImageContainer _imageContainter;
        private Bitmap _img;
        private Label _imageNameLabel;
        private int left;
        private int top;
        private int width;
        private int height;
        private Pen _rectanglePen = new Pen(Color.Red, 2);
        private Pen _circlePen = new Pen(Color.Yellow, 2);
        private double _scale = 1.0;
        private const int DELTA = 5;
        bool isMouseDown = false;

        public double ScaledLeft { get => left * _scale; }
        public double ScaledTop { get => top * _scale; }
        public double ScaledWidth { get => width * _scale; }
        public double ScaledHeight { get => height * _scale; }

        private bool ShouldDraw
        {
            get => _checkbox.Checked;
        }
        public ImageContainer imageContainer
        {
            get { return _imageContainter; }
            set
            {
                _imageContainter = value;
                _img = value.Image;
            }
        }

        public Painter(PictureBox pictureBox, CheckBox showCropBoxCheckbox, TrackBar trackBar, Label imageNameLabel)
        {
            _picture = pictureBox;
            _checkbox = showCropBoxCheckbox;
            _zoomTrackBar = trackBar;
            _imageNameLabel = imageNameLabel;
        }

        public void LoadImage(ImageContainer container)
        {

            imageContainer = container;
            var bmp = imageContainer.Image;
            _imageNameLabel.Text = container.filename;
            CalculateDefaultScale(bmp);
            ReloadSizes(bmp);
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

            //left top
            if (Math.Abs(ScaledLeft - point.X) < DELTA && Math.Abs(ScaledTop - point.Y) < DELTA)
            {
                return true;
            }
            //left bottom
            else if (Math.Abs(ScaledLeft - point.X) < DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < DELTA)
            {
                return true;
            }
            //right top
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < DELTA && Math.Abs(ScaledTop - point.Y) < DELTA)
            {
                return true;
            }
            //right bottom
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < DELTA)
            {
                return true;
            }
            return false;

        }

        private void CalculateDefaultScale(Bitmap bmp)
        {
            var scaleX = ((double)_picture.Parent.ClientSize.Width / (double)bmp.Width) * 100.0;
            var scaleY = ((double)_picture.Parent.ClientSize.Height / (double)bmp.Height) * 100.0;
            _zoomTrackBar.Value = Math.Min((int)scaleX, (int)scaleY);
        }

        internal void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (IsInCorner(e.Location))
            {
                isMouseDown = true;
            }

        }

        internal void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        internal void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true && ShouldDraw)
            {
                var point = e.Location;

            }
        }

        internal void showCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (_img != null)
            {
                RedrawImage();
            }
        }

        internal void zoomTrackBar_ValueChanged(TrackBar sender, EventArgs e)
        {
            if (_img != null)
            {
                RedrawImage();
            }
        }

        internal void ResetZoom()
        {

            if (_img != null)
            {
                var bmp = _img.Clone() as Bitmap;
                CalculateDefaultScale(bmp);
                RedrawImage(bmp);
            }
        }

        private Bitmap ScaleBitmap(Bitmap img)
        {
            _scale = _zoomTrackBar.Value / 100.0;
            var scaleWidth = (int)(img.Width * _scale);
            var scaleHeight = (int)(img.Height * _scale);
            return new Bitmap(img, (int)scaleWidth, (int)scaleHeight);
        }

        private void RedrawImage()
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
}
