using System;
using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        public PictureBox picture;
        private ImageContainer _imageContainter;
        private Bitmap _img;
        public ImageContainer imageContainer
        {
            get { return _imageContainter; }
            set
            {
                _imageContainter = value;
                DrawRectagle();
            }
        }

        private int left;
        private int top;
        private int width;
        private int height;
        bool isMouseDown = false;
        public Painter(PictureBox _pictureBox)
        {
            picture = _pictureBox;
            //ReloadSizes(_pictureBox);
        }

        public void LoadFirstImage(ImageContainer container)
        {
            ReloadSizes(container.image);
            imageContainer = container;
        }

        private void ReloadSizes(Bitmap bmp)
        {
            width = Convert.ToInt32(bmp.Width * 0.8);
            height = Convert.ToInt32(bmp.Height * 0.8);
            left = Convert.ToInt32(bmp.Width * 0.1);
            top = Convert.ToInt32(bmp.Height * 0.1);
        }

        internal void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
        }

        internal void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        internal void MainPictureBox_MouseMove(object sender, MouseEventArgs e, bool shouldDraw)
        {
            if (isMouseDown == true && shouldDraw)
            {
                //cropRectangle.Location = e.Location;

                //if (cropRectangle.Right > picture.Width)
                //{
                //    cropRectangle.X = picture.Width - cropRectangle.Width;
                //}
                //if (cropRectangle.Top < 0)
                //{
                //    cropRectangle.Y = 0;
                //}
                //if (cropRectangle.Left < 0)
                //{
                //    cropRectangle.X = 0;
                //}
                //if (cropRectangle.Bottom > picture.Height)
                //{
                //    cropRectangle.Y = picture.Height - cropRectangle.Height;
                //}
                picture.Refresh();
            }
        }

        internal void MainPictureBox_Resize(object sender, EventArgs e, bool shouldDraw)
        {
            //ReloadSizes(picture);
            //if (shouldDraw)
            //    picture.Refresh();
        }
        private void DrawRectagle()
        {
            _img = _imageContainter.image;
            Graphics g = Graphics.FromImage(_img);
            g.DrawRectangle(new Pen(Color.RoyalBlue), new Rectangle(left, top, width, height));
            picture.Image = _img;
        }

        private void CenterPictureBox(PictureBox picBox, Bitmap picImage)
        {
            picBox.Image = picImage;
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }

        internal void MainPictureBox_Paint(object sender, PaintEventArgs e, bool shouldDraw)
        {
            //    Graphics newGraphics = Graphics.FromImage(_img.image);
            //    if (shouldDraw)
            //        newGraphics.DrawRectangle(new Pen(Color.RoyalBlue), new Rectangle(left, top, width, height));
            //    e.Graphics.DrawImage(imageFile, new PointF(0.0F, 0.0F));
        }

    }
}
