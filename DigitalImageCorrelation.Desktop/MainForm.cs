using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {
        public Dictionary<int, ImageContainer> imageContainers = new Dictionary<int, ImageContainer>();
        public ImageContainer CurrentImageContainer;
        public Dictionary<int, AnalyzeResult> results = new Dictionary<int, AnalyzeResult>();
        public Painter painter;
        private readonly Worker processor = new Worker();
        private double GetZoom()
        {
            return Position.scale;
        }

        private void SetZoom(double value)
        {
            Position.scale = value;
            zoomTextbox.Text = value.ToString("F");
        }
        private const double ZoomStep = 1.1;
        public MainForm()
        {
            InitializeComponent();
            painter = new Painter();
            processor.OnProgressUpdate += OnImageProcessor_ProgressChanged;
            processor.OnTaskDone += OnImageProcessor_RunWorkerCompleted;
            MainPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadImagesPanel.Controls.Clear();
                    progressBar.Minimum = 0;
                    progressBar.Maximum = loadImagesFileDialog.FileNames.Count();
                    for (int i = 0; i < loadImagesFileDialog.FileNames.Count(); i++)
                    {
                        Button imageBtn = new Button();
                        imageBtn.Click += ChangeImage_Click;
                        imageBtn.Location = new Point(i * 70, 0);
                        imageBtn.AutoSize = true;
                        imageBtn.Size = new Size(67, 13);
                        imageBtn.TabIndex = 0;
                        imageBtn.Text = (i + 1).ToString();
                        LoadImagesPanel.Controls.Add(imageBtn);
                    }
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
                SetImage(imageContainers[int.Parse(button.Text) - 1]);
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void DrawCurrentImage(object sender, EventArgs e)
        {
            try
            {
                SetImage(CurrentImageContainer);
            }
            catch (Exception) { }
        }

        private void SetImage(ImageContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            CurrentImageContainer = container;
            MainPictureBox.BackgroundImage = container.BmpRaw;
            MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());
            ImageNameLabel.Text = CurrentImageContainer.Filename;
            sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (analyzeButton.Enabled)
                {
                    CurrentImageContainer?.MouseDown(e.Location);
                }
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
                SetZoom(painter.CalculateDefaultScale(CreateDrawRequest()));
                MainPictureBox.Image = painter.DrawImage(CreateDrawRequest());
                MainPictureBox.BackgroundImage = CurrentImageContainer.BmpRaw;
            }
        }

        private DrawRequest CreateDrawRequest()
        {
            return new DrawRequest()
            {
                AnalyzeResults = results,
                Image = CurrentImageContainer,
                PointsinX = int.Parse(pointsXTextbox.Text),
                PointsinY = int.Parse(pointsYTextbox.Text),
                ShowCropBox = showCropBoxCheckbox.Checked,
                PictureHeight = MainPictureBox.Parent.ClientSize.Height,
                PictureWidth = MainPictureBox.Parent.ClientSize.Width,
                SubsetDelta = int.Parse(subsetDeltaTextbox.Text),
                WindowDelta = int.Parse(windowDeltaTextbox.Text),
                Type = GetDrawingType()
            };
        }

        private DrawingType GetDrawingType()
        {
            try
            {
                var checkedButton = RadioButtonsPanel.Controls.OfType<RadioButton>()
                                          .FirstOrDefault(r => r.Checked);
                return (DrawingType)int.Parse(checkedButton.Tag.ToString());
            }
            catch (Exception ex)
            {
                Error(ex);
                return DrawingType.Image;

            }

        }

        private AnalyzeRequest CreateAnalyseRequest()
        {
            return new AnalyzeRequest()
            {
                Arrays = imageContainers.ToDictionary(x => x.Key, x => x.Value.GrayScaleImage),
                SubsetDelta = int.Parse(subsetDeltaTextbox.Text),
                WindowDelta = int.Parse(windowDeltaTextbox.Text),
                PointsinX = int.Parse(pointsXTextbox.Text),
                PointsinY = int.Parse(pointsYTextbox.Text),
                StartingPoints = imageContainers.First().Value.pos.CalculateStartingPoints(int.Parse(pointsXTextbox.Text), int.Parse(pointsYTextbox.Text))
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
            imageContainers = new Dictionary<int, ImageContainer>();
            Parallel.ForEach(loadImagesFileDialog.FileNames, (fileName, state, index) =>
            {
                Bitmap bitmap = new Bitmap(fileName);
                var image = new ImageContainer(bitmap, Path.GetFileName(fileName), (int)index);
                imageContainers[(int)index] = image;
                worker.ReportProgress((int)index);
            });
            e.Result = imageContainers;
        }

        private void LoadImagesBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += 1;
            }
            progresLabel.Text = progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString();
            if (e.ProgressPercentage == 0)
            {
                CurrentImageContainer = imageContainers[0];
                InitializeImageScale(null, null);
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

        private void OnImageProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is AnalyzeResult)
            {
                var result = e.UserState as AnalyzeResult;
                results[result.Index] = result;
                if (result.Index == CurrentImageContainer.Index)
                {
                    SetImage(CurrentImageContainer);
                }
            }
            progresLabel.Text = e.ProgressPercentage.ToString() + "/" + imageContainers.Count;
            progressBar.Value = e.ProgressPercentage;
        }

        private void OnImageProcessor_RunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                progresLabel.Text = "Canceled!";
                analyzeButton.Enabled = true;
            }
            else if (e.Error != null)
            {
                progresLabel.Text = "Error: " + e.Error.Message;
                Error(e.Error);
                analyzeButton.Enabled = true;
            }
            else
            {
                SetImage(CurrentImageContainer);
                progresLabel.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }

        }

        private void ZoomDownButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                SetZoom(GetZoom() / ZoomStep);
                MainPictureBox.Image = painter.DrawImage(request);
            }
        }

        private void ZoomUpButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                SetZoom(GetZoom() * ZoomStep);
                MainPictureBox.Image = painter.DrawImage(request);
            }
        }
    }
}
