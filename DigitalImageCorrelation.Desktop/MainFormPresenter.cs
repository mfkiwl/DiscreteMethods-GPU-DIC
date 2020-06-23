using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace DigitalImageCorrelation.Desktop
{
    public class MainFormPresenter : BasePresenter
    {
        public MainFormPresenter()
        {
        }

        public List<ImageContainer> OpenImages(string[] filenames)
        {
            try
            {
                var imageContainers = new List<ImageContainer>();
                foreach (var fileName in filenames)
                {
                    Image image = Image.FromFile(fileName);
                    Bitmap bitmap = new Bitmap(fileName);
                    imageContainers.Add(new ImageContainer(bitmap, Path.GetFileName(fileName)));
                }
                return imageContainers;
            }
            catch (Exception ex)
            {
                Error(ex, "Error during loading files.");
            }
            return null;
        }

    }
}
