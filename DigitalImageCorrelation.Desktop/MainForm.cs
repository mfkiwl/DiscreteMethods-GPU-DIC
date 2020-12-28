using DigitalImageCorrelation.Calculation;
using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Drawing;
using DigitalImageCorrelation.Desktop.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using DigitalImageCorrelation.FileManagement;
using NLog;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
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
        private SquareLocation square = new SquareLocation();

        public delegate void OnProgressChanged(object sender, ProgressChangedEventArgs e);

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
            AppendLineToTextbox("Initialization ended");
        }

        private void SetZoom(double value)
        {
            square.Scale = value < 2.0 ? value : 2.0;
            zoomTextbox.Text = square.Scale.ToString("F");
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
                {
                    analyzeResult = new AnalyzeResult();
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
            try
            {
                await DrawImage();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private async Task DrawImage()
        {
            var request = CreateDrawRequest();
            MainPictureBox.Image = await _painter.DrawImage(request);
            if (CurrentImageContainer.Result != null)
            {

                LocalMaxLabel.Text = $"Local max: {GetFormat(GetLocalMaxValue(request.Type))}";
                LocalMinLabel.Text = $"Local min: {GetFormat(GetLocalMinValue(request.Type))}";
                GlobalMaxLabel.Text = $"Max: {GetFormat(GetGlobalMaxValue(request.Type))}";
                GlobalMinLabel.Text = $"Min: {GetFormat(GetGlobalMinValue(request.Type))}";

                ValueTypeLabel.Text = request.Type.ToString();
            }
            if (analyzeResult.ImageResults.Any())
            {
                MaxValLabel.Text = $"{GetFormat(GetMax(request.Type))}";
                MinValLabel.Text = $"{GetFormat(GetMin(request.Type))}";
            }
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
                ImageNameLabel.Text = CurrentImageContainer.Filename;
                sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
                await DrawImage();
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
                    square.MouseDown(e.Location);
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
                square.MouseUp(e.Location, CurrentImageContainer.BitmapWidth, CurrentImageContainer.BitmapHeight);
                await DrawImage();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
        }

        private async void ShowCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                await DrawImage();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private async void InitializeImageScale(object sender, EventArgs e)
        {
            if (CurrentImageContainer != null)
            {
                CustomScaleComboBox.SelectedItem = null;
                SetZoom(_painter.CalculateDefaultScale(CreateDrawRequest()));
                await DrawImage();
                MainPictureBox.BackgroundImage = CurrentImageContainer.BmpRaw;
            }
        }

        private DrawRequest CreateDrawRequest()
        {
            var type = GetDrawingType();
            var max = GetMax(type);
            var min = GetMin(type);
            if (max < min)
            {
                max = GetGlobalMaxValue(type);
                min = GetGlobalMinValue(type);
            }
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
                Type = type,
                Max = max,
                Min = min,
                Square = square
            };
        }

        private double GetMax(DrawingType type)
        {
            if (UseCustomRangeRadioBtn.Checked)
            {
                return double.Parse(customMaxTextbox.Text);
            }
            else if (UseLocalRangeRadioBtn.Checked)
            {
                return GetLocalMaxValue(type);
            }
            return GetGlobalMaxValue(type);
        }
        private double GetMin(DrawingType type)
        {
            if (UseCustomRangeRadioBtn.Checked)
            {
                return double.Parse(customMinTextbox.Text);
            }
            else if (UseLocalRangeRadioBtn.Checked)
            {
                return GetLocalMinValue(type);
            }
            return GetGlobalMinValue(type);
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
                StartingVertexes = square.CalculateStartingVertexes(int.Parse(pointsXTextbox.Text), int.Parse(pointsYTextbox.Text)),
                BitmapHeight = CurrentImageContainer.BitmapHeight,
                BitmapWidth = CurrentImageContainer.BitmapWidth,
                Size = imageContainers.Count,
                Square = square
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
                await DrawImage();
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
                if (index == 0)
                {
                    square.ReloadSizes(image.BitmapWidth, image.BitmapHeight);
                }
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
            AppendLineToTextbox($"Images loaded: {progressBar.Value}/{progressBar.Maximum}");
            if (e.ProgressPercentage == 0)
            {
                CurrentImageContainer = imageContainers[0];
                InitializeImageScale(null, null);
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value += 1;
            }
            AppendLineToTextbox($"Progress changed: {progressBar.Value}/{progressBar.Maximum}");
        }

        private void Import_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                AppendLineToTextbox("Error: " + e.Error.Message);
                Error(e.Error);
            }
            else
            {
                analyzeResult = e.Result as AnalyzeResult;
                _logger.Info("Import Completed");
                AppendLineToTextbox("Import Completed");
                progressBar.Value = progressBar.Maximum;
                pointsXTextbox.Text = analyzeResult.Request.PointsinX.ToString();
                pointsYTextbox.Text = analyzeResult.Request.PointsinY.ToString();
                subsetDeltaTextbox.Text = analyzeResult.Request.SubsetDelta.ToString();
                windowDeltaTextbox.Text = analyzeResult.Request.WindowDelta.ToString();
                square = analyzeResult.Request.Square;
                InitializeImageScale(null, null);
            }
        }

        private void Export_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                AppendLineToTextbox("Error: " + e.Error.Message);
                Error(e.Error);
            }
            else
            {
                var path = e.Result as AnalyzeResult;
                _logger.Info("Export Completed");
                AppendLineToTextbox($"Export Completed. Result in {path}");
                progressBar.Value = progressBar.Maximum;
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
                    CustomScaleComboBox.SelectedItem = null;
                    SetZoom(square.Scale / ZoomStep);
                    await DrawImage();
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
                    CustomScaleComboBox.SelectedItem = null;
                    SetZoom(square.Scale * ZoomStep);
                    await DrawImage();
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
                    var x = (int)(e.Location.X / square.Scale);
                    var y = (int)(e.Location.Y / square.Scale);
                    XPosLabel.Text = $"X:{x}";
                    YPosLabel.Text = $"Y:{y}";
                    var drawingType = GetDrawingType();
                    StringBuilder stringBuilder = new StringBuilder($"X: {x} Y: {y}");

                    if (analyzeResult.ImageResults.ContainsKey(CurrentImageContainer.Index))
                    {
                        var closestVertex = analyzeResult.ImageResults[CurrentImageContainer.Index].GetClosestVertex(x, y);
                        ValueLabel.Text = $"Value:{GetFormat(GetValue(drawingType, closestVertex))}";
                        stringBuilder.AppendLine($"\nValue: {GetFormat(GetValue(drawingType, closestVertex))}");
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
                (DrawingType.StrainX) => vertex.strain.X,
                (DrawingType.StrainY) => vertex.strain.Y,
                (DrawingType.StrainShear) => vertex.strain.XY,
                (DrawingType.StressX) => vertex.stress.X,
                (DrawingType.StressY) => vertex.stress.Y,
                (DrawingType.StressEq) => vertex.stress.Eq,
                _ => 0,
            };
        }

        private double GetGlobalMaxValue(DrawingType type)
        {
            try
            {
                return type switch
                {
                    (DrawingType.DisplacementX) => analyzeResult.MaxDx,
                    (DrawingType.DisplacementY) => analyzeResult.MaxDy,
                    (DrawingType.StrainX) => analyzeResult.MaxStrainXX,
                    (DrawingType.StrainY) => analyzeResult.MaxStrainYY,
                    (DrawingType.StrainShear) => analyzeResult.MaxStrainXY,
                    (DrawingType.StressX) => analyzeResult.MaxStressXX,
                    (DrawingType.StressY) => analyzeResult.MaxStressYY,
                    (DrawingType.StressEq) => analyzeResult.MaxStressEq,
                    _ => 0,
                };
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
            return 0;
        }

        private double GetLocalMaxValue(DrawingType type)
        {
            try
            {
                return type switch
                {
                    (DrawingType.DisplacementX) => CurrentImageContainer.Result.MaxDx,
                    (DrawingType.DisplacementY) => CurrentImageContainer.Result.MaxDy,
                    (DrawingType.StrainX) => CurrentImageContainer.Result.MaxStrainX,
                    (DrawingType.StrainY) => CurrentImageContainer.Result.MaxStrainY,
                    (DrawingType.StrainShear) => CurrentImageContainer.Result.MaxStrainXY,
                    (DrawingType.StressX) => CurrentImageContainer.Result.MaxStressX,
                    (DrawingType.StressY) => CurrentImageContainer.Result.MaxStressY,
                    (DrawingType.StressEq) => CurrentImageContainer.Result.MaxStressEq,
                    _ => 0,
                };
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
            return 0;
        }

        private double GetGlobalMinValue(DrawingType type)
        {
            try
            {
                return type switch
                {
                    (DrawingType.DisplacementX) => analyzeResult.MinDx,
                    (DrawingType.DisplacementY) => analyzeResult.MinDy,
                    (DrawingType.StrainX) => analyzeResult.MinStrainXX,
                    (DrawingType.StrainY) => analyzeResult.MinStrainYY,
                    (DrawingType.StrainShear) => analyzeResult.MinStrainXY,
                    (DrawingType.StressX) => analyzeResult.MinStressXX,
                    (DrawingType.StressY) => analyzeResult.MinStressYY,
                    (DrawingType.StressEq) => analyzeResult.MinStressEq,
                    _ => 0,
                };
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
            return 0;
        }

        private double GetLocalMinValue(DrawingType type)
        {
            try
            {
                return type switch
                {
                    (DrawingType.DisplacementX) => CurrentImageContainer.Result.MinDx,
                    (DrawingType.DisplacementY) => CurrentImageContainer.Result.MinDy,
                    (DrawingType.StrainX) => CurrentImageContainer.Result.MinStrainX,
                    (DrawingType.StrainY) => CurrentImageContainer.Result.MinStrainY,
                    (DrawingType.StrainShear) => CurrentImageContainer.Result.MinStrainXY,
                    (DrawingType.StressX) => CurrentImageContainer.Result.MinStressX,
                    (DrawingType.StressY) => CurrentImageContainer.Result.MinStressY,
                    (DrawingType.StressEq) => CurrentImageContainer.Result.MinStressEq,
                    _ => 0,
                };
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
            }
            return 0;
        }

        private string GetFormat(double number)
        {
            if (number > -1.0 && number < 1.0)
            {
                return number.ToString("0.00E0");
            }
            return Math.Round(number, 2).ToString();

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

        private async void UseCustomRangeRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            var radioBtn = sender as RadioButton;
            if (!radioBtn.Checked)
            {
                customMaxTextbox.Enabled = false;
                customMinTextbox.Enabled = false;
            }
            else
            {
                var type = GetDrawingType();
                customMaxTextbox.Enabled = true;
                customMinTextbox.Enabled = true;
                customMaxTextbox.Text = GetFormat(GetGlobalMaxValue(type));
                customMinTextbox.Text = GetFormat(GetGlobalMinValue(type));
            }
            try
            {
                await DrawImage();
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void ExportMetadataButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (analyzeResult.Request != null)
                {
                    ExportMetadataDialog.FileName = $"{analyzeResult.Request.PointsinX}x{analyzeResult.Request.PointsinY} - {analyzeResult.Request.Size} {DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss")}.xml";
                }
                else
                {
                    throw new Exception($"Unable to export metadata. There is no analyzed data to export. Please make sure that the data has been analyzed and it is ready to export.");
                }
                if (ExportMetadataDialog.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Value = 0;
                    var exportManager = new ExportManager(ExportMetadataDialog.FileName);
                    exportManager.ProgressChanged += ProgressChanged;
                    exportManager.RunWorkerCompleted += Export_RunWorkerCompleted;
                    exportManager.RunWorkerAsync(analyzeResult);
                    AppendLineToTextbox($"Exporting data started...");
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private void ImportMetadataButton_Click(object sender, EventArgs e)
        {
            try
            {
                ImportMetadataDialog.FileName = ".xml";
                if (ImportMetadataDialog.ShowDialog() == DialogResult.OK)
                {
                    progressBar.Value = 0;
                    var importManager = new ImportManager(ImportMetadataDialog.FileName);
                    importManager.ProgressChanged += ProgressChanged;
                    importManager.RunWorkerCompleted += Import_RunWorkerCompleted;
                    importManager.RunWorkerAsync(imageContainers);
                    AppendLineToTextbox($"Loading xml file {ImportMetadataDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                Error(ex);
            }
        }

        private async void SaveImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveImageDialog.FileName = Path.GetFileNameWithoutExtension(CurrentImageContainer.Filename) + "-DIC.png";
                if (SaveImageDialog.ShowDialog() == DialogResult.OK)
                {
                    AppendLineToTextbox($"Saving image...");
                    var request = CreateDrawRequest();
                    request.PictureHeight = CurrentImageContainer.BitmapHeight;
                    request.PictureWidth = CurrentImageContainer.BitmapWidth;
                    Bitmap bmp = await _painter.DrawImage(request, CurrentImageContainer.Bmp);
                    bmp.Save(SaveImageDialog.FileName, System.Drawing.Imaging.ImageFormat.Png);
                    bmp.Dispose();
                    AppendLineToTextbox($"Image successfully saved as {SaveImageDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                Error(ex);

            }
        }

        private async void CustomScaleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentImageContainer != null)
                {
                    var selectedRow = double.Parse(CustomScaleComboBox.SelectedItem.ToString(), CultureInfo.InvariantCulture);
                    SetZoom(selectedRow);
                    await DrawImage();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
            }
        }

        private void LeftPanel_DoubleClick(object sender, EventArgs e)
        {
            if (LeftPanel.Width > 100)
                LeftPanel.Width = 50;
            else
                LeftPanel.Width = 174;
        }

        private void RightPanel_DoubleClick(object sender, EventArgs e)
        {
            if (RightPanel.Width > 100)
                RightPanel.Width = 50;
            else
                RightPanel.Width = 183;
        }
    }
}

