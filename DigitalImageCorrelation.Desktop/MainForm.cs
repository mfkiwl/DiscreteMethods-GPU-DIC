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
            _presenter = new MainFormPresenter(this, new Painter(this.MainPictureBox, this.showCropBoxCheckbox, this.zoomTrackBar));
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
            _presenter.painter.MainPictureBox_MouseMove(sender, e);
        }

        private void showCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            _presenter.painter.showCropBoxCheckbox_CheckedChanged(sender, e);

        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            _presenter.painter.zoomTrackBar_ValueChanged(sender as TrackBar, e);
        }

        private void MainImagePanel_SizeChanged(object sender, EventArgs e)
        {
            _presenter.painter.MainPictureBox_Resize(sender, e);

        }
    }
}
