using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
namespace DigitalImageCorrelation.Desktop
{
    public class MainFormPresenter
    {
        private MainForm _mainForm;
        public List<ImageContainer> imageContainers = new List<ImageContainer>();

        public MainFormPresenter(MainForm form)
        {
            _mainForm = form;
        }

        public void OpenImages(string[] filenames)
        {
            foreach (var fileName in filenames)
            {
                Image image = Image.FromFile(fileName);
                Bitmap bitmap = new Bitmap(fileName);
                imageContainers.Add(new ImageContainer(bitmap));
            }
        }
    }
}
