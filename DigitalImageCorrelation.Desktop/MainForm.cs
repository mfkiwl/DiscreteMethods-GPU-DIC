using DigitalImageCorrelation.Desktop.Requests;
using System;
using System.Collections.Generic;
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
            if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageContainers = OpenImages(loadImagesFileDialog.FileNames);
                CurrentImageContainer = imageContainers.FirstOrDefault();
                zoomTrackBar.Value = painter.CalculateDefaultScale(CreateDrawRequest());
                CurrentImageContainer.SetScaleOfImage(zoomTrackBar.Value);
                ImageNameLabel.Text = CurrentImageContainer.filename;
                sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
                _buttons = new List<Button>();
                LoadImagesPanel.Controls.Clear();
                for (var i = 0; i < imageContainers.Count; i++)
                {
                    var image = imageContainers[i];
                    Button imageBtn = new Button();
                    imageBtn.Click += ChangeImage_Click;
                    if (_buttons.Any())
                    {
                        var last = _buttons.Last();
                        imageBtn.Location = new System.Drawing.Point(last.Location.X + 70, last.Location.Y);
                    }
                    imageBtn.AutoSize = true;
                    imageBtn.Size = new System.Drawing.Size(67, 13);
                    imageBtn.TabIndex = 0;
                    imageBtn.Text = i.ToString();
                    _buttons.Add(imageBtn);
                    LoadImagesPanel.Controls.Add(imageBtn);
                }
            }
        }

        private void ChangeImage_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            CurrentImageContainer = imageContainers[int.Parse(button.Text)];
            CurrentImageContainer.SetScaleOfImage(zoomTrackBar.Value);
            painter.RedrawImage(CreateDrawRequest());
            ImageNameLabel.Text = CurrentImageContainer.filename;
            sizeNumberLabel.Text = $"{CurrentImageContainer.Bmp.Width}x{CurrentImageContainer.Bmp.Height}px";
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentImageContainer.MouseDown(sender, e);
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            CurrentImageContainer.MouseUp(sender, e);
            painter.RedrawImage(CreateDrawRequest());
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

        public List<ImageContainer> OpenImages(string[] filenames)
        {
            try
            {
                var imageContainers = new List<ImageContainer>();
                foreach (var fileName in filenames)
                {
                    Image image = Image.FromFile(fileName);
                    Bitmap bitmap = new Bitmap(fileName);
                    imageContainers.Add(new ImageContainer(bitmap, Path.GetFileName(fileName)));
                }
                return imageContainers;
            }
            catch (Exception ex)
            {
                Error(ex, "Error during loading files.");
            }
            return null;
        }

        public void Error(Exception ex, string title = "exception occured")
        {
            Error(ex.Message + "Stack trace: " + ex.StackTrace, title);
        }

        public void Error(string message, string title)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
