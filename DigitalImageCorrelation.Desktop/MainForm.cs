using System;
using System.Linq;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {
        private MainFormPresenter _presenter;
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainFormPresenter(this);
        }

        private void openImagesButton_Click(object sender, EventArgs e)
        {
            if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
            {
                _presenter.OpenImages(loadImagesFileDialog.FileNames);
                var firstImage = _presenter.imageContainers.FirstOrDefault();
                if (firstImage != null)
                {
                    MainPictureBox.Image = firstImage.image;
                }
            }
        }
    }
}
