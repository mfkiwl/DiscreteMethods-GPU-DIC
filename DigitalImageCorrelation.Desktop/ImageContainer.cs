using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalImageCorrelation.Core
{
    public class ImageContainer
    {
        public string Filename { get; set; }
        private bool isMouseDown = false;
        public byte[] GrayScaleImage;
        public int Index;
        public Bitmap Bmp
        {
            get { return BmpRaw.Clone() as Bitmap; }
            set { BmpRaw = value; }
        }
        public Bitmap BmpRaw { get; private set; }
        public SquareLocation square = new SquareLocation();
        private SelectedCorner DragedCorner = SelectedCorner.None;
        public int BitmapWidth;
        public int BitmapHeight;

        public ImageContainer(Bitmap bitmap, string name, int index)
        {
            BmpRaw = bitmap;
            Filename = name;
            ReloadSizes(bitmap);
            Index = index;
            GrayScaleImage = ToGrayScaleArray(bitmap);
            BitmapWidth = bitmap.Width;
            BitmapHeight = bitmap.Height;

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
            SquareLocation.Width = Convert.ToInt32(bmp.Width * 0.8);
            SquareLocation.Height = Convert.ToInt32(bmp.Height * 0.8);
            SquareLocation.Left = Convert.ToInt32(bmp.Width * 0.1);
            SquareLocation.Top = Convert.ToInt32(bmp.Height * 0.1);
        }

        public bool IsInCorner(Point point)
        {
            if (Math.Abs(square.ScaledLeft - point.X) < Utils.DELTA && Math.Abs(square.ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                return true;
            }
            else if (Math.Abs(square.ScaledLeft - point.X) < Utils.DELTA && Math.Abs(square.ScaledTop + square.ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                return true;
            }
            else if (Math.Abs(square.ScaledLeft + square.ScaledWidth - point.X) < Utils.DELTA && Math.Abs(square.ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                return true;
            }
            else if (Math.Abs(square.ScaledLeft + square.ScaledWidth - point.X) < Utils.DELTA && Math.Abs(square.ScaledTop + square.ScaledHeight - point.Y) < Utils.DELTA)
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
                var point = new Point() { X = (int)(p.X * 1.0 / SquareLocation.Scale), Y = (int)(p.Y * 1.0 / SquareLocation.Scale) };
                if (point.X <= 0 || point.Y <= 0 || point.X >= BmpRaw.Width || point.Y >= BmpRaw.Height)
                {
                    return;
                }
                var xVector = 0;
                var yVector = 0;
                if (DragedCorner == SelectedCorner.LeftTop)
                {
                    xVector = SquareLocation.Left - point.X;
                    yVector = SquareLocation.Top - point.Y;
                    SquareLocation.Left = point.X;
                    SquareLocation.Top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.LeftBottom)
                {
                    xVector = SquareLocation.Left - point.X;
                    yVector = point.Y - SquareLocation.Top - SquareLocation.Height;
                    SquareLocation.Left = point.X;
                }
                else if (DragedCorner == SelectedCorner.RightTop)
                {
                    xVector = point.X - SquareLocation.Left - SquareLocation.Width;
                    yVector = SquareLocation.Top - point.Y;
                    SquareLocation.Top = point.Y;
                }
                else if (DragedCorner == SelectedCorner.RightBottom)
                {
                    xVector = point.X - SquareLocation.Left - SquareLocation.Width;
                    yVector = point.Y - SquareLocation.Top - SquareLocation.Height;
                }
                SquareLocation.Width += xVector;
                SquareLocation.Height += yVector;
                DragedCorner = SelectedCorner.None;
                isMouseDown = false;
            }
        }

        private byte[] ToGrayScaleArray(Bitmap image)
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
            var grayScaleArray = new byte[bitmapData.Width * bitmapData.Height];
            if (pixelsize >= 3)
            {
                for (int I = 0; I < bitmapData.Width; I++)
                {
                    for (int J = 0; J < bitmapData.Height; J++)
                    {
                        int position = (J * bitmapData.Stride) + (I * pixelsize);
                        blue = imagebytes[position];
                        green = imagebytes[position + 1];
                        red = imagebytes[position + 2];
                        grayScaleArray[(I * bitmapData.Height) + J] = (byte)(0.299 * red + 0.587 * green + 0.114 * blue);
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