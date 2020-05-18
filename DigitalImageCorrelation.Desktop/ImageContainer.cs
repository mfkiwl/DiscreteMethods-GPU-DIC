using System.Drawing;

namespace DigitalImageCorrelation.Desktop
{
    public class ImageContainer
    {
        private Bitmap _image;
        public Bitmap Image
        {
            get { return _image.Clone() as Bitmap; }
            set { _image = value; }
        }
        public ImageContainer(Bitmap image)
        {
            this._image = image;
        }
    }
}
