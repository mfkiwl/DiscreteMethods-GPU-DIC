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
                    imageListView.Items.Clear();
                    progressBar.Minimum = 0;
                    progressBar.Maximum = loadImagesFileDialog.FileNames.Count();
                    for (int i = 0; i < loadImagesFileDialog.FileNames.Count(); i++)
                    {
                        var path = loadImagesFileDialog.FileNames[i];
                        var args = new string[] { (i + 1).ToString(), Path.GetFileName(path) };
                        imageListView.Items.Add(new ListViewItem(args)
                        {
                            Tag = i,
                            ToolTipText = path,
                        });
                    }
                    LoadImagesBackgroundWorker.RunWorkerAsync();
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void DrawCurrentImage(object sender, EventArgs e)
        {
            var request = CreateDrawRequest();
            MainPictureBox.Image = await _painter.DrawImage(request);
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
                if (container.Result != null)
                {

                    MaxImageValLabel.Text = $"Local max: {Math.Round(GetLocalMaxValue(drawRequest.Type), 2)}";
                    MinImageValLabel.Text = $"Local min: {Math.Round(GetLocalMinValue(drawRequest.Type), 2)}";
                    ValueTypeLabel.Text = drawRequest.Type.ToString();
                }
                if (analyzeResult.ImageResults.Any())
                {
                    MaxValLabel.Text = $"{Math.Round(GetMaxValue(drawRequest.Type), 2)}";
                    MinValLabel.Text = $"{Math.Round(GetMinValue(drawRequest.Type), 2)}";
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
            CalculationType type;
            if (GpuRadioBtn.Checked)
                type = CalculationType.Gpu;
            else
                type = CalculationType.Cpu;
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
            AppendLineToTextbox(ex.Message);
            AppendLineToTextbox(ex.StackTrace);
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
            AppendLineToTextbox("Images loaded: " + progressBar.Value.ToString() + "/" + progressBar.Maximum.ToString());
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
                AppendLineToTextbox("Canceled loading images");
            }
            else if (e.Error != null)
            {
                AppendLineToTextbox("Error: " + e.Error.Message);
                Error(e.Error);
                analyzeButton.Enabled = false;
            }
            else
            {
                _logger.Info("Loaded images");
                AppendLineToTextbox("Images Loaded");
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }
        }

        private void AnalyzeButton_Click(object sender, EventArgs e)
        {
            try
            {
                analyzeButton.Enabled = false;
                AppendLineToTextbox("0/" + imageContainers.Count);
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
                imageContainers[result.Index].Result = result;
                if (result.Index == CurrentImageContainer.Index)
                {
                    await SetImage(CurrentImageContainer);
                }
            }
            AppendLineToTextbox(e.ProgressPercentage.ToString() + "/" + imageContainers.Count);
            progressBar.Value = e.ProgressPercentage;
        }

        private async void OnImageProcessor_RunWorkerCompleted(RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                AppendLineToTextbox("Canceled analyzing");
                analyzeButton.Enabled = true;
            }
            else if (e.Error != null)
            {
                AppendLineToTextbox("Error: " + e.Error.Message);
                Error(e.Error);
                analyzeButton.Enabled = true;
            }
            else
            {
                analyzeResult = e.Result as AnalyzeResult;
                await SetImage(CurrentImageContainer);
                AppendLineToTextbox("Analyze Done");
                progressBar.Value = progressBar.Maximum;
                analyzeButton.Enabled = true;
            }
        }

        private async void ZoomDownButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentImageContainer != null)
                {
                    var request = CreateDrawRequest();
                    SetZoom(GetZoom() / ZoomStep);
                    MainPictureBox.Image = await _painter.DrawImage(request);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private async void ZoomUpButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentImageContainer != null)
                {
                    var request = CreateDrawRequest();
                    SetZoom(GetZoom() * ZoomStep);
                    MainPictureBox.Image = await _painter.DrawImage(request);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
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
        private double GetLocalMaxValue(DrawingType type)
        {
            return type switch
            {
                (DrawingType.DisplacementX) => CurrentImageContainer.Result.MaxDx,
                (DrawingType.DisplacementY) => CurrentImageContainer.Result.MaxDy,
                (DrawingType.StrainX) => CurrentImageContainer.Result.MaxStrainXX,
                (DrawingType.StrainY) => CurrentImageContainer.Result.MaxStrainYY,
                (DrawingType.StrainShear) => CurrentImageContainer.Result.MaxStrainXY,
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
        private double GetLocalMinValue(DrawingType type)
        {
            return type switch
            {
                (DrawingType.DisplacementX) => CurrentImageContainer.Result.MinDx,
                (DrawingType.DisplacementY) => CurrentImageContainer.Result.MinDy,
                (DrawingType.StrainX) => CurrentImageContainer.Result.MinStrainXX,
                (DrawingType.StrainY) => CurrentImageContainer.Result.MinStrainYY,
                (DrawingType.StrainShear) => CurrentImageContainer.Result.MinStrainXY,
                _ => 0,
            };
        }

        private async void imageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (imageListView.SelectedItems.Count == 0)
                    return;
                var firstSelectedItem = imageListView.SelectedItems[0];
                await SetImage(imageContainers[(int)firstSelectedItem.Tag]);
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }
        private void AppendLineToTextbox(string line)
        {
            try
            {
                MessageRichTextBox.AppendText("\r\n" + line);
                MessageRichTextBox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void MessageRichTextBox_DoubleClick(object sender, EventArgs e)
        {
            if (DownPanel.Height < 100)
            {
                DownPanel.Height = 300;
            }
            else
            {
                DownPanel.Height = 22;
            }

            MessageRichTextBox.ScrollToCaret();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

