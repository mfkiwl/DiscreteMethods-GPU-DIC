using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalImageCorrelation.Core
{
    public class ImageContainer
    {
        public string Filename { get; set; }
        public Bitmap Bmp
        {
            get { return BmpRaw.Clone() as Bitmap; }
            set { BmpRaw = value; }
        }
        public byte[,] GrayScaleImage;
        public IEnumerable<Point> Points;
        public Bitmap BmpRaw { get; private set; }
        public static int left;
        public static int top;
        public static int width;
        public static int height;
        public static double scale = 1.0;
        public double ScaledLeft { get => left * scale; }
        public double ScaledTop { get => top * scale; }
        public double ScaledWidth { get => width * scale; }
        public double ScaledHeight { get => height * scale; }

        public int Index;
        private bool isMouseDown = false;
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
            width = Convert.ToInt32(bmp.Width * 0.8);
            height = Convert.ToInt32(bmp.Height * 0.8);
            left = Convert.ToInt32(bmp.Width * 0.1);
            top = Convert.ToInt32(bmp.Height * 0.1);
        }

        public bool IsInCorner(Point point)
        {
            if (Math.Abs(ScaledLeft - point.X) < Utils.DELTA && Math.Abs(ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft - point.X) < Utils.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.LeftBottom;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Utils.DELTA && Math.Abs(ScaledTop - point.Y) < Utils.DELTA)
            {
                DragedCorner = SelectedCorner.RightTop;
                return true;
            }
            else if (Math.Abs(ScaledLeft + ScaledWidth - point.X) < Utils.DELTA && Math.Abs(ScaledTop + ScaledHeight - point.Y) < Utils.DELTA)
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
                var point = new Point() { X = (int)(p.X * 1.0 / scale), Y = (int)(p.Y * 1.0 / scale) };
                if (point.X <= 0 || point.Y <= 0 || point.X >= BmpRaw.Width || point.Y >= BmpRaw.Height)
                {
                    return;
                }
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

        public IEnumerable<Point> CalculateStartingPoints(int w, int h)
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
