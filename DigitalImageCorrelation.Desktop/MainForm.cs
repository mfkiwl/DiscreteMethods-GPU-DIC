﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {



        private MainFormPresenter _presenter;
        private List<Button> _buttons = new List<Button>();
        public List<ImageContainer> imageContainers = new List<ImageContainer>();
        public Painter painter;
        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainFormPresenter();
            painter = new Painter(MainPictureBox, showCropBoxCheckbox, zoomTrackBar, ImageNameLabel);
        }

        private void OpenImagesButton_Click(object sender, EventArgs e)
        {
            if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
            {
                imageContainers = _presenter.OpenImages(loadImagesFileDialog.FileNames);
                var container = imageContainers.FirstOrDefault();
                painter.LoadImage(container);
                sizeNumberLabel.Text = $"{container.Image.Width}x{container.Image.Height}px";
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
            var imageContainer = imageContainers[Int32.Parse(button.Text)];
            painter.LoadImage(imageContainer);
            sizeNumberLabel.Text = $"{imageContainer.Image.Width}x{imageContainer.Image.Height}px";
        }

        private void MainPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            painter.MainPictureBox_MouseDown(sender, e);
        }

        private void MainPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            painter.MainPictureBox_MouseUp(sender, e);
        }

        private void MainPictureBox_MouseMove(object sender, MouseEventArgs e)

        {
            painter.MainPictureBox_MouseMove(sender, e);
        }

        private void showCropBoxCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            painter.showCropBoxCheckbox_CheckedChanged(sender, e);

        }

        private void zoomTrackBar_ValueChanged(object sender, EventArgs e)
        {
            painter.zoomTrackBar_ValueChanged(sender as TrackBar, e);
        }

        private void MainImagePanel_SizeChanged(object sender, EventArgs e)
        {
            painter.ResetZoom();
        }

        private void ResetZoomButton_Click(object sender, EventArgs e)
        {
            painter.ResetZoom();

        }
    }
}
