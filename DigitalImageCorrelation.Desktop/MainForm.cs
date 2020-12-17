using DigitalImageCorrelation.Calculation;
using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Drawing;
using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using NLog;
using System;
using System.Collections.Concurrent;
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
        public ConcurrentDictionary<int, ImageContainer> imageContainers = new ConcurrentDictionary<int, ImageContainer>();
        public AnalyzeResult analyzeResult = new AnalyzeResult();
        public ImageContainer CurrentImageContainer;
        private readonly Painter _painter;
        private readonly Worker _worker;
        private const double ZoomStep = 1.1;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        public MainForm(Painter painter, Worker worker)
        {
            InitializeComponent();
            _worker = worker;
            _worker.OnProgressUpdate += OnImageProcessor_ProgressChanged;
            _worker.OnTaskDone += OnImageProcessor_RunWorkerCompleted;
            _painter = painter;
            MainPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            ScalePicturebox.Image = painter.DrawColorScale(ScalePicturebox.Width, ScalePicturebox.Height);
        }

        private double GetZoom()
        {
            return SquareLocation.Scale;
        }

        private void SetZoom(double value)
        {
            SquareLocation.Scale = value < 2.0 ? value : 2.0;
            zoomTextbox.Text = SquareLocation.Scale.ToString("F");
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SetImageButtonsPanel.Controls.Clear();
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
                        SetImageButtonsPanel.Controls.Add(imageBtn);
                    }
                    LoadImagesBackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void ChangeImage_Click(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                await SetImage(imageContainers[int.Parse(button.Text) - 1]);
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void DrawCurrentImage(object sender, EventArgs e)
        {
            await SetImage(CurrentImageContainer);
        }

        private async Task<bool> SetImage(ImageContainer container)
        {
            try
            {
                if (container is null)
                {
                    return false;
                }
                CurrentImageContainer = container;
                MainPictureBox.BackgroundImage = container.BmpRaw;
                var drawRequest = CreateDrawRequest();
                MainPictureBox.Image = await _painter.DrawImage(drawRequest);
                ImageNameLabel.Text = CurrentImageContainer.Filename;
                sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
                if (analyzeResult.ImageResults.Any())
                {
                    MaxValLabel.Text = $"Max: {Math.Round(GetMaxValue(drawRequest.Type), 2)}";
                    MinValLabel.Text = $"Min: {Math.Round(GetMinValue(drawRequest.Type), 2)}";
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.Warn(ex, "Unable to SetImage");
            }
            return false;
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
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        private async void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                CurrentImageContainer?.MouseUp(e.Location);
                MainPictureBox.Image = await _painter.DrawImage(CreateDrawRequest());
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        private async void ShowCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            MainPictureBox.Image = await _painter.DrawImage(CreateDrawRequest());
        }

        private async void InitializeImageScale(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                SetZoom(_painter.CalculateDefaultScale(CreateDrawRequest()));
                MainPictureBox.Image = await _painter.DrawImage(CreateDrawRequest());
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
                FindPoints = ResolveFindPoints(),
                Arrays = imageContainers.ToDictionary(x => x.Key, x => x.Value.GrayScaleImage),
                SubsetDelta = int.Parse(subsetDeltaTextbox.Text),
                WindowDelta = int.Parse(windowDeltaTextbox.Text),
                PointsinX = int.Parse(pointsXTextbox.Text),
                PointsinY = int.Parse(pointsYTextbox.Text),
                StartingVertexes = imageContainers.First().Value.square.CalculateStartingVertexes(int.Parse(pointsXTextbox.Text), int.Parse(pointsYTextbox.Text)),
                BitmpHeight = CurrentImageContainer.BitmapHeight,
                BitmpWidth = CurrentImageContainer.BitmapWidth
            };
        }

        private ICalculation ResolveFindPoints()
        {
            var type = CalculationType.Cpu;
            var checkedButton = OpenImagesPanel.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            type = (CalculationType)int.Parse(checkedButton.Tag.ToString());


            return type switch
            {
                (CalculationType.Cpu) => new FindPointCpu(),
                (CalculationType.Gpu) => new FindPointCuda(),
                _ => new FindPointCpu(),
            };
        }

        private async void ValidateTextAndRefreshImage(object sender, EventArgs e)
        {
            int.TryParse(pointsXTextbox.Text, out int val);
            if (val <= 0)
            {
                (sender as TextBox).Text = "1";
            }
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                MainPictureBox.Image = await _painter.DrawImage(request);
            }
        }

        public void Error(Exception ex)
        {
            MessageBox.Show(ex.Message + " More information in logs.", "Exception occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _logger.Error(ex);
        }

        private void LoadImagesBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            imageContainers = new ConcurrentDictionary<int, ImageContainer>();
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
                _logger.Info("Loaded images");
                progresLabel.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                analyzeButton.Enabled = false;
                progresLabel.Text = "0/" + imageContainers.Count;
                progressBar.Maximum = imageContainers.Count;
                progressBar.Value = 0;
                var request = CreateAnalyseRequest();
                _worker.RunWorker(request);
            }
            catch (Exception ex)
            {
                Error(ex);
            }
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
                MainPictureBox.Image = await _painter.DrawImage(request);
            }
        }

        private async void ZoomUpButton_Click(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                var request = CreateDrawRequest();
                SetZoom(GetZoom() * ZoomStep);
                MainPictureBox.Image = await _painter.DrawImage(request);
            }
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            try
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
                        ValueLabel.Text = $"Value:{Math.Round(GetValue(drawingType, closestVertex), 2)}";
                        stringBuilder.AppendLine($"\nValue: {Math.Round(GetValue(drawingType, closestVertex), 2)}");
                    }
                    PictureboxToolTip.SetToolTip(MainPictureBox, stringBuilder.ToString());
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }
        private double GetValue(DrawingType type, Vertex vertex)
        {
            return type switch
            {
                (DrawingType.DisplacementX) => vertex.dX,
                (DrawingType.DisplacementY) => vertex.dY,
                (DrawingType.StrainX) => vertex.strain.XX,
                (DrawingType.StrainY) => vertex.strain.YY,
                (DrawingType.StrainShear) => vertex.strain.XY,
                _ => 0,
            };
        }

        private double GetMaxValue(DrawingType type)
        {
            return type switch
            {
                (DrawingType.DisplacementX) => analyzeResult.MaxDx,
                (DrawingType.DisplacementY) => analyzeResult.MaxDy,
                (DrawingType.StrainX) => analyzeResult.MaxStrainXX,
                (DrawingType.StrainY) => analyzeResult.MaxStrainYY,
                (DrawingType.StrainShear) => analyzeResult.MaxStrainXY,
                _ => 0,
            };
        }

        private double GetMinValue(DrawingType type)
        {
            return type switch
            {
                (DrawingType.DisplacementX) => analyzeResult.MinDx,
                (DrawingType.DisplacementY) => analyzeResult.MinDy,
                (DrawingType.StrainX) => analyzeResult.MinStrainXX,
                (DrawingType.StrainY) => analyzeResult.MinStrainYY,
                (DrawingType.StrainShear) => analyzeResult.MinStrainXY,
                _ => 0,
            };
        }
    }
}

