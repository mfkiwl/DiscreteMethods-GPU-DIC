using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
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
        private readonly WorkerProcessor processor = new WorkerProcessor();
        private double Zoom
        {
            get => ImageContainer.scale;
            set
            {
                ImageContainer.scale = value;
                zoomTextbox.Text = value.ToString("F");
            }
        }
        private const double ZoomStep = 1.1;
        public MainForm()
        {
            InitializeComponent();
            painter = new Painter();
            processor.OnProgressUpdate += OnImageProcessor_ProgressChanged;
            processor.OnTaskDone += OnImageProcessor_RunWorkerCompleted;
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
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());
            ImageNameLabel.Text = CurrentImageContainer.Filename;
            sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseDown(e.Location);
            }
            catch (Exception) { }
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseUp(e.Location);
                MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());

            }
            catch (Exception) { }
        }

        private void ShowCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());

        }

        private void InitializeImageScale(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                Zoom = painter.CalculateDefaultScale(CreateDrawRequest());
                MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());
            }
        }

        private DrawRequest CreateDrawRequest()
        {
            return new DrawRequest()
            {
                Image = CurrentImageContainer,
                PointsinX = int.Parse(pointsXTextbox.Text),
                PointsinY = int.Parse(pointsYTextbox.Text),
                ShowCropBox = showCropBoxCheckbox.Checked,
                PictureHeight = MainPictureBox.Parent.ClientSize.Height,
                PictureWidth = MainPictureBox.Parent.ClientSize.Width,
                SubsetDelta = int.Parse(subsetDeltaTextbox.Text),
                WindowsDelta = int.Parse(windowDeltaTextbox.Text)
            };
        }

        private AnalyzeRequest CreateAnalyseRequest()
        {
            return new AnalyzeRequest()
            {
                Containers = imageContainers
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
                MainPictureBox.Image = painter.DrawImage(request);
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

        private void LoadImagesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
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

        private void LoadImagesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progresLabel.Text = e.ProgressPercentage.ToString() + "/" + progressBar.Maximum.ToString();
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
                InitializeImageScale(null, null);
                SetImage(CurrentImageContainer);
            }
        }

        private void LoadImagesBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progresLabel.Text = "Canceled!";
            }
            else if (e.Error != null)
            {
                progresLabel.Text = "Error: " + e.Error.Message;
                Error(e.Error);
                analyzeButton.Enabled = false;
            }
            else
            {
                progresLabel.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            analyzeButton.Enabled = false;
            progresLabel.Text = "0/" + imageContainers.Count;
            progressBar.Maximum = imageContainers.Count;
            progressBar.Value = 0;
            processor.RunWorker(CreateAnalyseRequest());
        }

        private void OnImageProcessor_ProgressChanged(int progres)
        {
            progresLabel.Text = progres.ToString() + "/" + imageContainers.Count;
            progressBar.Value = progres;
        }

        private void OnImageProcessor_RunWorkerCompleted()
        {
            progresLabel.Text = "Done!";
            progressBar.Value = progressBar.Maximum;
            analyzeButton.Enabled = true;
        }

        private void ZoomDownButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                Zoom = Zoom / ZoomStep;
                MainPictureBox.Image = painter.DrawImage(request);
            }
        }

        private void zoomUpButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                Zoom = Zoom * ZoomStep;
                MainPictureBox.Image = painter.DrawImage(request);
            }
        }
    }
}
