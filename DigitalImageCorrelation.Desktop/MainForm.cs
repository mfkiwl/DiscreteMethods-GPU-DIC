using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {
        private List<Button> _buttons = new List<Button>();
        public List<ImageContainer> imageContainers = new List<ImageContainer>();
        public ImageContainer CurrentImageContainer;
        public Painter painter;
        public MainForm()
        {
            InitializeComponent();
            painter = new Painter(MainPictureBox);
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
                {
                    _buttons = new List<Button>();
                    LoadImagesPanel.Controls.Clear();
                    progressBar.Minimum = 0;
                    progressBar.Maximum = loadImagesFileDialog.FileNames.Count();
                    LoadImagesBackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void ChangeImage_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                CurrentImageContainer = imageContainers[int.Parse(button.Text) - 1];
                SetImage(CurrentImageContainer);
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void SetImage(ImageContainer container)
        {

            CurrentImageContainer.SetScaleOfImage(zoomTrackBar.Value);
            painter.RedrawImage(CreateDrawRequest());
            ImageNameLabel.Text = CurrentImageContainer.filename;
            sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
            zoomTrackBar.Value = painter.CalculateDefaultScale(CreateDrawRequest());
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseDown(sender, e);
            }
            catch (Exception) { }
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseUp(sender, e);
                painter.RedrawImage(CreateDrawRequest());
            }
            catch (Exception) { }
        }

        private void showCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            painter.RedrawImage(CreateDrawRequest());
        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                CurrentImageContainer.SetScaleOfImage(zoomTrackBar.Value);
                painter.RedrawImage(request);
            }
        }

        private void InitializeImageScale(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                zoomTrackBar.Value = painter.CalculateDefaultScale(request);
                painter.RedrawImage(request);
            }
        }

        private DrawRequest CreateDrawRequest()
        {
            return new DrawRequest()
            {
                image = CurrentImageContainer,
                PointsinX = int.Parse(pointsXTextbox.Text),
                PointsinY = int.Parse(pointsYTextbox.Text),
                ShowCropBox = showCropBoxCheckbox.Checked,
                PictureHeight = MainPictureBox.Parent.ClientSize.Height,
                PictureWidth = MainPictureBox.Parent.ClientSize.Width,
                SubsetDelta = int.Parse(subsetDeltaTextbox.Text),
                WindowsDelta = int.Parse(windowDeltaTextbox.Text),
                zoom = zoomTrackBar.Value
            };
        }

        private void ValidateTextAndRefreshImage(object sender, EventArgs e)
        {
            try
            {
                int val = int.Parse(pointsXTextbox.Text);
                if (val <= 0)
                    throw new ArgumentException();
            }
            catch (Exception)
            {
                (sender as TextBox).Text = "1";
            }
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                painter.RedrawImage(request);
            }
        }

        public void Error(Exception ex, string title = "exception occured")
        {
            Error(ex.Message + "Stack trace: " + ex.StackTrace, title);
        }

        public void Error(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LoadImagesBackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                imageContainers = new List<ImageContainer>();
                foreach (var (fileName, index) in loadImagesFileDialog.FileNames.WithIndex())
                {
                    Bitmap bitmap = new Bitmap(fileName);
                    var image = new ImageContainer(bitmap, Path.GetFileName(fileName), index);
                    imageContainers.Add(image);
                    worker.ReportProgress(index);
                }
                e.Result = imageContainers;
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void LoadImagesBackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progresLabel.Text = (e.ProgressPercentage.ToString() + "/" + progressBar.Maximum.ToString());
            progressBar.Value = e.ProgressPercentage;
            Button imageBtn = new Button();
            imageBtn.Click += ChangeImage_Click;
            if (_buttons.Any())
            {
                var last = _buttons.Last();
                imageBtn.Location = new Point(last.Location.X + 70, last.Location.Y);
            }
            imageBtn.AutoSize = true;
            imageBtn.Size = new Size(67, 13);
            imageBtn.TabIndex = 0;
            imageBtn.Text = (e.ProgressPercentage + 1).ToString();
            _buttons.Add(imageBtn);
            LoadImagesPanel.Controls.Add(imageBtn);

            if (e.ProgressPercentage == 0)
            {
                CurrentImageContainer = imageContainers.FirstOrDefault();
                SetImage(CurrentImageContainer);
            }
        }

        private void LoadImagesBackgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progresLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                progresLabel.Text = "Error: " + e.Error.Message;
            }
            else
            {
                progresLabel.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
            }
        }
    }
}
