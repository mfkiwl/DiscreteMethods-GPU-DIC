using DigitalImageCorrelation.Core.Structures;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace DigitalImageCorrelation.Core
{
    public class ImageContainer
    {
        public string Filename { get; set; }
        public byte[] GrayScaleImage;
        public int Index;
        public ImageResult Result;
        public Bitmap Bmp
        {
            get { return BmpRaw.Clone() as Bitmap; }
            set { BmpRaw = value; }
        }
        public Bitmap BmpRaw { get; private set; }
        public int BitmapWidth;
        public int BitmapHeight;

        public ImageContainer(Bitmap bitmap, string name, int index)
        {
            BmpRaw = bitmap;
            Filename = name;
            Index = index;
            GrayScaleImage = ToGrayScaleArray(bitmap);
            BitmapWidth = bitmap.Width;
            BitmapHeight = bitmap.Height;
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