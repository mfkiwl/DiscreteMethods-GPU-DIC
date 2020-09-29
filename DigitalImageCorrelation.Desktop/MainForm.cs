using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {
        public Dictionary<int, ImageContainer> imageContainers = new Dictionary<int, ImageContainer>();
        public ImageContainer CurrentImageContainer;
        public AnalyzeResult analyzeResult = new AnalyzeResult();
        public Painter painter;
        private readonly Worker processor = new Worker();
        private double GetZoom()
        {
            return SquareLocation.Scale;
        }

        private void SetZoom(double value)
        {
            SquareLocation.Scale = value < 2.0 ? value : 2.0;
            zoomTextbox.Text = SquareLocation.Scale.ToString("F");
        }
        private const double ZoomStep = 1.1;
        public MainForm()
        {
            InitializeComponent();
            painter = new Painter();
            processor.OnProgressUpdate += OnImageProcessor_ProgressChanged;
            processor.OnTaskDone += OnImageProcessor_RunWorkerCompleted;
            MainPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ScalePicturebox.Image = painter.DrawColorScale(ScalePicturebox.Width, ScalePicturebox.Height);
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

        private async Task SetImage(ImageContainer container)
        {
            if (container is null)
            {
                throw new ArgumentNullException(nameof(container));
            }
            CurrentImageContainer = container;
            MainPictureBox.BackgroundImage = container.BmpRaw;
            var drawRequest = CreateDrawRequest();
            MainPictureBox.Image = await painter.DrawImage(drawRequest);
            ImageNameLabel.Text = CurrentImageContainer.Filename;
            sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
            if (analyzeResult.ImageResults.Any())
            {
                if (drawRequest.Type == DrawingType.DisplacementX)
                {
                    MaxValLabel.Text = $"Max: {analyzeResult.MaxDx}";
                    MinValLabel.Text = $"Min: {analyzeResult.MinDx}";
                }
                else if (drawRequest.Type == DrawingType.DisplacementY)
                {
                    MaxValLabel.Text = $"Max: {analyzeResult.MaxDy}";
                    MinValLabel.Text = $"Min: {analyzeResult.MinDy}";
                }
            }
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

        private async void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseUp(e.Location);
                MainPictureBox.Image = await painter.DrawImage(CreateDrawRequest());
            }
            catch (Exception) { }
        }

        private async void ShowCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Image = await painter.DrawImage(CreateDrawRequest());
        }

        private async void InitializeImageScale(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                SetZoom(painter.CalculateDefaultScale(CreateDrawRequest()));
                MainPictureBox.Image = await painter.DrawImage(CreateDrawRequest());
                MainPictureBox.BackgroundImage = CurrentImageContainer.BmpRaw;
            }
        }

        private DrawRequest CreateDrawRequest()
        {
            return new DrawRequest()
            {
                AnalyzeResults = analyzeResult,
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
                StartingVertexes = imageContainers.First().Value.square.CalculateStartingVertexes(int.Parse(pointsXTextbox.Text), int.Parse(pointsYTextbox.Text))
            };
        }

        private async void ValidateTextAndRefreshImage(object sender, EventArgs e)
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
                MainPictureBox.Image = await painter.DrawImage(request);
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

        private async void OnImageProcessor_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState is ImageResult)
            {
                var result = e.UserState as ImageResult;
                analyzeResult.ImageResults[result.Index] = result;
                if (result.Index == CurrentImageContainer.Index)
                {
                    await SetImage(CurrentImageContainer);
                }
            }
            progresLabel.Text = e.ProgressPercentage.ToString() + "/" + imageContainers.Count;
            progressBar.Value = e.ProgressPercentage;
        }

        private async void OnImageProcessor_RunWorkerCompleted(RunWorkerCompletedEventArgs e)
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
                analyzeResult = e.Result as AnalyzeResult;
                await SetImage(CurrentImageContainer);
                progresLabel.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }

        }

        private async void ZoomDownButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                SetZoom(GetZoom() / ZoomStep);
                MainPictureBox.Image = await painter.DrawImage(request);
            }
        }

        private async void ZoomUpButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                SetZoom(GetZoom() * ZoomStep);
                MainPictureBox.Image = await painter.DrawImage(request);
            }
        }

        private async void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var x = (int)(e.Location.X / GetZoom());
                var y = (int)(e.Location.Y / GetZoom());
                XPosLabel.Text = $"X:{x}";
                YPosLabel.Text = $"Y:{y}";
                var drawingType = GetDrawingType();
                StringBuilder stringBuilder = new StringBuilder($"X: {x} Y: {y}");
                if (analyzeResult.ImageResults.ContainsKey(CurrentImageContainer.Index))
                {
                    var closestVertex = analyzeResult.ImageResults[CurrentImageContainer.Index].GetClosestVertex(x, y);
                    if (drawingType == DrawingType.DisplacementX)
                    {
                        ValueLabel.Text = $"Value:{closestVertex.dX}";
                        stringBuilder.AppendLine($"\nValue: {closestVertex.dX}");
                    }
                    else if (drawingType == DrawingType.DisplacementY)
                    {
                        ValueLabel.Text = $"Value:{closestVertex.dY}";
                        stringBuilder.AppendLine($"\nValue: {closestVertex.dY}");
                    }
                }
                PictureboxToolTip.SetToolTip(MainPictureBox, stringBuilder.ToString());
            }
        }
    }
}

