﻿using System;
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
        private double _scale = 1.0;

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
                RedrawImage();
            }
        }

        private int left;
        private int top;
        private int width;
        private int height;
        bool isMouseDown = false;
        public Painter(PictureBox pictureBox, CheckBox showCropBoxCheckbox, TrackBar trackBar)
        {
            _picture = pictureBox;
            _checkbox = showCropBoxCheckbox;
            _zoomTrackBar = trackBar;
        }

        public void LoadFirstImage(ImageContainer container)
        {
            var bmp = container.Image;
            ReloadSizes(bmp);
            imageContainer = container;
            CalculateDefaultScale(bmp);
        }

        private void ReloadSizes(Bitmap bmp)
        {
            width = Convert.ToInt32(bmp.Width * 0.8);
            height = Convert.ToInt32(bmp.Height * 0.8);
            left = Convert.ToInt32(bmp.Width * 0.1);
            top = Convert.ToInt32(bmp.Height * 0.1);
        }

        private void CalculateDefaultScale(Bitmap bmp)
        {
            var scaleX = ((double)_picture.Parent.ClientSize.Width / (double)bmp.Width) * 100.0;
            var scaleY = ((double)_picture.Parent.ClientSize.Height / (double)bmp.Height) * 100.0;
            _zoomTrackBar.Value = Math.Min((int)scaleX, (int)scaleY);
        }

        internal void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        internal void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        internal void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isMouseDown == true && ShouldDraw)
            //{
            //    //cropRectangle.Location = e.Location;

            //    //if (cropRectangle.Right > picture.Width)
            //    //{
            //    //    cropRectangle.X = picture.Width - cropRectangle.Width;
            //    //}
            //    //if (cropRectangle.Top < 0)
            //    //{
            //    //    cropRectangle.Y = 0;
            //    //}
            //    //if (cropRectangle.Left < 0)
            //    //{
            //    //    cropRectangle.X = 0;
            //    //}
            //    //if (cropRectangle.Bottom > picture.Height)
            //    //{
            //    //    cropRectangle.Y = picture.Height - cropRectangle.Height;
            //    //}
            //    _picture.Refresh();
            //}
        }

        internal void MainPictureBox_Resize(object sender, EventArgs e)
        {
            RedrawImage();
        }
        internal void showCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            RedrawImage();
        }

        internal void zoomTrackBar_ValueChanged(TrackBar sender, EventArgs e)
        {
            var img = _imageContainter.Image;
            _scale = sender.Value / 100.0;
            var scaleWidth = (int)(img.Width * _scale);
            var scaleHeight = (int)(img.Height * _scale);
            _img = new Bitmap(img, (int)scaleWidth, (int)scaleHeight);
            RedrawImage();

        }

        private void RedrawImage()
        {
            var img = _img.Clone() as Bitmap;
            DrawRectagle(img);
            CenterImage(img);
            _picture.Image = img;
        }

        private void CenterImage(Bitmap img)
        {
            if (_picture.Parent.ClientSize.Width > img.Width || _picture.Parent.ClientSize.Height > img.Height)
                _picture.Location = new Point((_picture.Parent.ClientSize.Width / 2) - (img.Width / 2),
                                  (_picture.Parent.ClientSize.Height / 2) - (img.Height / 2));
            else
            {
                _picture.Location = new Point(0, 0);
            }
        }

        private Bitmap DrawRectagle(Bitmap img)
        {
            if (ShouldDraw)
            {
                Graphics g = Graphics.FromImage(img);
                g.DrawRectangle(new Pen(Color.RoyalBlue), new Rectangle((int)(left * _scale), (int)(top * _scale), (int)(width * _scale), (int)(height * _scale)));
            }
            return img;
        }
    }
}
