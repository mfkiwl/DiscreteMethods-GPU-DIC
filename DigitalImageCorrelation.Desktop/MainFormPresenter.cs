using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Desktop
{
    public class MainFormPresenter
    {
        private MainForm _mainForm;
        public Painter painter;
        public List<ImageContainer> imageContainers = new List<ImageContainer>();

        public MainFormPresenter(MainForm form, Painter painter)
        {
            _mainForm = form;
            this.painter = painter;
        }

        public void OpenImages(string[] filenames)
        {
            imageContainers = new List<ImageContainer>();
            foreach (var fileName in filenames)
            {
                Image image = Image.FromFile(fileName);
                Bitmap bitmap = new Bitmap(fileName);
                imageContainers.Add(new ImageContainer(bitmap));
            }
            painter.LoadFirstImage(imageContainers.FirstOrDefault());
        }
    }
}
