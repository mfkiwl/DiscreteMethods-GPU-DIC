using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalImageCorrelation.Core
{
    public class ImageContainer
    {
        public string Filename { get; set; }
        private bool isMouseDown = false;
        public byte[,] GrayScaleImage;
        public int Index;
        public Bitmap Bmp
        {
            get { return BmpRaw.Clone() as Bitmap; }
            set { BmpRaw = value; }
        }
        public Bitmap BmpRaw { get; private set; }
        public Position pos = new Position();
        private SelectedCorner DragedCorner = SelectedCorner.None;

        public ImageContainer(Bitmap bitmap, string name, int index)
        {
            BmpRaw = bitmap;
            Filename = name;
            ReloadSizes(bitmap);
            Index = index;
            GrayScaleImage = ToGrayScale(bitmap);
        }

        public void MouseDown(Point point)
        {
            if (IsInCorner(point))
            {
                isMouseDown = true;
            }
        }

        private void ReloadSizes(Bitmap bmp)
        {
            Position.width = Convert.ToInt32(bmp.Width * 0.8);
            Position.height = Convert.ToInt32(bmp.Height * 0.8);
            Position.left = Convert.ToInt32(bmp.Width * 0.1);
            Position.top = Convert.ToInt32(bmp.Height * 0.1);
        }

        public bool IsInCorner(Point point)
        {
            if (Math.Abs(pos.ScaledLeft - point.X) < Utils.DELTA && Math.Abs(pos.ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                return true;
            }
            else if (Math.Abs(pos.ScaledLeft - point.X) < Utils.DELTA && Math.Abs(pos.ScaledTop + pos.ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                return true;
            }
            else if (Math.Abs(pos.ScaledLeft + pos.ScaledWidth - point.X) < Utils.DELTA && Math.Abs(pos.ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                return true;
            }
            else if (Math.Abs(pos.ScaledLeft + pos.ScaledWidth - point.X) < Utils.DELTA && Math.Abs(pos.ScaledTop + pos.ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightBottom;
                return true;
            }
            return false;
        }

        public void MouseUp(Point p)
        {
            if (isMouseDown)
            {
                var point = new Point() { X = (int)(p.X * 1.0 / Position.scale), Y = (int)(p.Y * 1.0 / Position.scale) };
                if (point.X <= 0 || point.Y <= 0 || point.X >= BmpRaw.Width || point.Y >= BmpRaw.Height)
                {
                    return;
                }
                var xVector = 0;
                var yVector = 0;
                if (DragedCorner == SelectedCorner.LeftTop)
                {
                    xVector = Position.left - point.X;
                    yVector = Position.top - point.Y;
                    Position.left = point.X;
                    Position.top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.LeftBottom)
                {
                    xVector = Position.left - point.X;
                    yVector = point.Y - Position.top - Position.height;
                    Position.left = point.X;
                }
                else if (DragedCorner == SelectedCorner.RightTop)
                {
                    xVector = point.X - Position.left - Position.width;
                    yVector = Position.top - point.Y;
                    Position.top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.RightBottom)
                {
                    xVector = point.X - Position.left - Position.width;
                    yVector = point.Y - Position.top - Position.height;
                }
                Position.width += xVector;
                Position.height += yVector;
                DragedCorner = SelectedCorner.None;
                isMouseDown = false;
            }
        }

        private byte[,] ToGrayScale(Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat);

            int pixelsize = Image.GetPixelFormatSize(bitmapData.PixelFormat) / 8;

            IntPtr pointer = bitmapData.Scan0;
            int nbytes = bitmapData.Height * bitmapData.Stride;
            byte[] imagebytes = new byte[nbytes];
            System.Runtime.InteropServices.Marshal.Copy(pointer, imagebytes, 0, nbytes);

            double red;
            double green;
            double blue;
            double gray;

            var grayScaleArray = new byte[bitmapData.Height, bitmapData.Width];

            if (pixelsize >= 3)
            {
                for (int I = 0; I < bitmapData.Height; I++)
                {
                    for (int J = 0; J < bitmapData.Width; J++)
                    {
                        int position = (I * bitmapData.Stride) + (J * pixelsize);
                        blue = imagebytes[position];
                        green = imagebytes[position + 1];
                        red = imagebytes[position + 2];
                        gray = 0.299 * red + 0.587 * green + 0.114 * blue;
                        grayScaleArray[I, J] = (byte)gray;
                    }
                }
            }
            image.UnlockBits(bitmapData);
            return grayScaleArray;
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
