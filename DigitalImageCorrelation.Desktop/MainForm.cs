using System;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {



        private MainFormPresenter _presenter;
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainFormPresenter(this, new Painter(this.MainPictureBox));
        }

        private void openImagesButton_Click(object sender, EventArgs e)
        {
            if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
            {
                _presenter.OpenImages(loadImagesFileDialog.FileNames);
            }
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            _presenter.painter.MainPictureBox_MouseDown(sender, e);
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _presenter.painter.MainPictureBox_MouseUp(sender, e);
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)

        {
            _presenter.painter.MainPictureBox_MouseMove(sender, e, showCropBoxCheckbox.Checked);
        }

        private void MainPictureBox_Resize(object sender, EventArgs e)
        {
            _presenter.painter.MainPictureBox_Resize(sender, e, showCropBoxCheckbox.Checked);

        }
    }
}
