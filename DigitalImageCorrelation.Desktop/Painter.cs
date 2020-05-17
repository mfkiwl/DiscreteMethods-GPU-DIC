using System.Drawing;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class Painter
    {
        public PictureBox picture;

        Rectangle rect = new Rectangle(125, 125, 500, 500);
        bool isMouseDown = false;
        public Painter(PictureBox _pictureBox)
        {
            picture = _pictureBox;
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
                rect.Location = e.Location;

                if (rect.Right > picture.Width)
                {
                    rect.X = picture.Width - rect.Width;
                }
                if (rect.Top < 0)
                {
                    rect.Y = 0;
                }
                if (rect.Left < 0)
                {
                    rect.X = 0;
                }
                if (rect.Bottom > picture.Height)
                {
                    rect.Y = picture.Height - rect.Height;
                }
                picture.Refresh();
            }
        }
        public void MainPictureBox_Paint(object sender, PaintEventArgs e, bool shouldDraw)
        {
            if (shouldDraw)
                e.Graphics.DrawRectangle(new Pen(Color.RoyalBlue), rect);
        }

    }
}
