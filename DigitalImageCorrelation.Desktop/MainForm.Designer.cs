﻿namespace DigitalImageCorrelation.Desktop
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.openImagesButton = new System.Windows.Forms.Button();
            this.sizeNumberLabel = new System.Windows.Forms.Label();
            this.pointsXLabel = new System.Windows.Forms.Label();
            this.pointsXTextbox = new System.Windows.Forms.TextBox();
            this.pointsYTextbox = new System.Windows.Forms.TextBox();
            this.pointsYLabel = new System.Windows.Forms.Label();
            this.subsetDeltaTextbox = new System.Windows.Forms.TextBox();
            this.subsetDeltaLabel = new System.Windows.Forms.Label();
            this.windowDeltaTextbox = new System.Windows.Forms.TextBox();
            this.windowDeltaLabel = new System.Windows.Forms.Label();
            this.analyzeButton = new System.Windows.Forms.Button();
            this.showCropBoxCheckbox = new System.Windows.Forms.CheckBox();
            this.displayModeLabel = new System.Windows.Forms.Label();
            this.MainImagePanel = new System.Windows.Forms.Panel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.imageSliderPanel = new System.Windows.Forms.Panel();
            this.LoadImagesPanel = new System.Windows.Forms.Panel();
            this.loadImagesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.zoomUpButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.progresLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.ResetZoomButton = new System.Windows.Forms.Button();
            this.zoomTextbox = new System.Windows.Forms.TextBox();
            this.ZoomDownButton = new System.Windows.Forms.Button();
            this.RadioButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tensionRadioButton = new System.Windows.Forms.RadioButton();
            this.strainYRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementYRadiobutton = new System.Windows.Forms.RadioButton();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.pointsRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementVRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainShearRadioButton = new System.Windows.Forms.RadioButton();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ColorScaleLabel = new System.Windows.Forms.Label();
            this.YPosLabel = new System.Windows.Forms.Label();
            this.ScalePicturebox = new System.Windows.Forms.PictureBox();
            this.MinValLabel = new System.Windows.Forms.Label();
            this.XPosLabel = new System.Windows.Forms.Label();
            this.MaxValLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.LoadImagesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PictureboxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.MainImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.imageSliderPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RadioButtonsPanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // openImagesButton
            // 
            this.openImagesButton.Location = new System.Drawing.Point(7, 7);
            this.openImagesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openImagesButton.Name = "openImagesButton";
            this.openImagesButton.Size = new System.Drawing.Size(236, 47);
            this.openImagesButton.TabIndex = 1;
            this.openImagesButton.Text = "Open images";
            this.openImagesButton.UseVisualStyleBackColor = true;
            this.openImagesButton.Click += new System.EventHandler(this.OpenImagesButton_Click);
            // 
            // sizeNumberLabel
            // 
            this.sizeNumberLabel.AutoSize = true;
            this.sizeNumberLabel.Location = new System.Drawing.Point(9, 83);
            this.sizeNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sizeNumberLabel.Name = "sizeNumberLabel";
            this.sizeNumberLabel.Size = new System.Drawing.Size(41, 15);
            this.sizeNumberLabel.TabIndex = 3;
            this.sizeNumberLabel.Text = "0x0 px";
            // 
            // pointsXLabel
            // 
            this.pointsXLabel.AutoSize = true;
            this.pointsXLabel.Location = new System.Drawing.Point(9, 110);
            this.pointsXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pointsXLabel.Name = "pointsXLabel";
            this.pointsXLabel.Size = new System.Drawing.Size(63, 15);
            this.pointsXLabel.TabIndex = 4;
            this.pointsXLabel.Text = "Points in X";
            // 
            // pointsXTextbox
            // 
            this.pointsXTextbox.Location = new System.Drawing.Point(8, 129);
            this.pointsXTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pointsXTextbox.Name = "pointsXTextbox";
            this.pointsXTextbox.Size = new System.Drawing.Size(79, 23);
            this.pointsXTextbox.TabIndex = 5;
            this.pointsXTextbox.Text = "40";
            this.pointsXTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // pointsYTextbox
            // 
            this.pointsYTextbox.Location = new System.Drawing.Point(164, 129);
            this.pointsYTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pointsYTextbox.Name = "pointsYTextbox";
            this.pointsYTextbox.Size = new System.Drawing.Size(79, 23);
            this.pointsYTextbox.TabIndex = 7;
            this.pointsYTextbox.Text = "40";
            this.pointsYTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // pointsYLabel
            // 
            this.pointsYLabel.AutoSize = true;
            this.pointsYLabel.Location = new System.Drawing.Point(166, 110);
            this.pointsYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pointsYLabel.Name = "pointsYLabel";
            this.pointsYLabel.Size = new System.Drawing.Size(63, 15);
            this.pointsYLabel.TabIndex = 6;
            this.pointsYLabel.Text = "Points in Y";
            // 
            // subsetDeltaTextbox
            // 
            this.subsetDeltaTextbox.Location = new System.Drawing.Point(8, 178);
            this.subsetDeltaTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.subsetDeltaTextbox.Name = "subsetDeltaTextbox";
            this.subsetDeltaTextbox.Size = new System.Drawing.Size(79, 23);
            this.subsetDeltaTextbox.TabIndex = 9;
            this.subsetDeltaTextbox.Text = "10";
            this.subsetDeltaTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // subsetDeltaLabel
            // 
            this.subsetDeltaLabel.AutoSize = true;
            this.subsetDeltaLabel.Location = new System.Drawing.Point(9, 158);
            this.subsetDeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subsetDeltaLabel.Name = "subsetDeltaLabel";
            this.subsetDeltaLabel.Size = new System.Drawing.Size(71, 15);
            this.subsetDeltaLabel.TabIndex = 8;
            this.subsetDeltaLabel.Text = "Subset delta";
            // 
            // windowDeltaTextbox
            // 
            this.windowDeltaTextbox.Location = new System.Drawing.Point(164, 178);
            this.windowDeltaTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.windowDeltaTextbox.Name = "windowDeltaTextbox";
            this.windowDeltaTextbox.Size = new System.Drawing.Size(79, 23);
            this.windowDeltaTextbox.TabIndex = 11;
            this.windowDeltaTextbox.Text = "14";
            this.windowDeltaTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // windowDeltaLabel
            // 
            this.windowDeltaLabel.AutoSize = true;
            this.windowDeltaLabel.Location = new System.Drawing.Point(166, 158);
            this.windowDeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowDeltaLabel.Name = "windowDeltaLabel";
            this.windowDeltaLabel.Size = new System.Drawing.Size(80, 15);
            this.windowDeltaLabel.TabIndex = 10;
            this.windowDeltaLabel.Text = "Window delta";
            // 
            // analyzeButton
            // 
            this.analyzeButton.Enabled = false;
            this.analyzeButton.Location = new System.Drawing.Point(8, 208);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(236, 47);
            this.analyzeButton.TabIndex = 12;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // showCropBoxCheckbox
            // 
            this.showCropBoxCheckbox.AutoSize = true;
            this.showCropBoxCheckbox.Checked = true;
            this.showCropBoxCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCropBoxCheckbox.Location = new System.Drawing.Point(8, 262);
            this.showCropBoxCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showCropBoxCheckbox.Name = "showCropBoxCheckbox";
            this.showCropBoxCheckbox.Size = new System.Drawing.Size(105, 19);
            this.showCropBoxCheckbox.TabIndex = 13;
            this.showCropBoxCheckbox.Text = "Show crop box";
            this.showCropBoxCheckbox.UseVisualStyleBackColor = true;
            this.showCropBoxCheckbox.CheckedChanged += new System.EventHandler(this.ShowCropBoxCheckbox_CheckedChanged);
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.Location = new System.Drawing.Point(6, 331);
            this.displayModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(79, 15);
            this.displayModeLabel.TabIndex = 14;
            this.displayModeLabel.Text = "DisplayMode:";
            // 
            // MainImagePanel
            // 
            this.MainImagePanel.AutoScroll = true;
            this.MainImagePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainImagePanel.Controls.Add(this.MainPictureBox);
            this.MainImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainImagePanel.Location = new System.Drawing.Point(0, 61);
            this.MainImagePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainImagePanel.Name = "MainImagePanel";
            this.MainImagePanel.Size = new System.Drawing.Size(1259, 1000);
            this.MainImagePanel.TabIndex = 34;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(890, 714);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // imageSliderPanel
            // 
            this.imageSliderPanel.AutoScroll = true;
            this.imageSliderPanel.Controls.Add(this.LoadImagesPanel);
            this.imageSliderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageSliderPanel.Location = new System.Drawing.Point(0, 0);
            this.imageSliderPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.imageSliderPanel.Name = "imageSliderPanel";
            this.imageSliderPanel.Size = new System.Drawing.Size(1513, 61);
            this.imageSliderPanel.TabIndex = 35;
            // 
            // LoadImagesPanel
            // 
            this.LoadImagesPanel.AutoScroll = true;
            this.LoadImagesPanel.AutoSize = true;
            this.LoadImagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadImagesPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadImagesPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.LoadImagesPanel.Name = "LoadImagesPanel";
            this.LoadImagesPanel.Size = new System.Drawing.Size(1513, 61);
            this.LoadImagesPanel.TabIndex = 0;
            // 
            // loadImagesFileDialog
            // 
            this.loadImagesFileDialog.Filter = "*.BMP;*.JPG;*.GIF|";
            this.loadImagesFileDialog.Multiselect = true;
            this.loadImagesFileDialog.Title = "Load Images to analyze";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.panel1);
            this.optionsPanel.Controls.Add(this.ResultPanel);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsPanel.Location = new System.Drawing.Point(1259, 61);
            this.optionsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(254, 1000);
            this.optionsPanel.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.zoomUpButton);
            this.panel1.Controls.Add(this.zoomLabel);
            this.panel1.Controls.Add(this.pointsXTextbox);
            this.panel1.Controls.Add(this.windowDeltaTextbox);
            this.panel1.Controls.Add(this.sizeNumberLabel);
            this.panel1.Controls.Add(this.progresLabel);
            this.panel1.Controls.Add(this.subsetDeltaTextbox);
            this.panel1.Controls.Add(this.progressBar);
            this.panel1.Controls.Add(this.openImagesButton);
            this.panel1.Controls.Add(this.analyzeButton);
            this.panel1.Controls.Add(this.windowDeltaLabel);
            this.panel1.Controls.Add(this.showCropBoxCheckbox);
            this.panel1.Controls.Add(this.pointsYTextbox);
            this.panel1.Controls.Add(this.displayModeLabel);
            this.panel1.Controls.Add(this.subsetDeltaLabel);
            this.panel1.Controls.Add(this.ImageNameLabel);
            this.panel1.Controls.Add(this.pointsYLabel);
            this.panel1.Controls.Add(this.pointsXLabel);
            this.panel1.Controls.Add(this.ResetZoomButton);
            this.panel1.Controls.Add(this.zoomTextbox);
            this.panel1.Controls.Add(this.ZoomDownButton);
            this.panel1.Controls.Add(this.RadioButtonsPanel);
            this.panel1.Location = new System.Drawing.Point(0, 7);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 640);
            this.panel1.TabIndex = 15;
            // 
            // zoomUpButton
            // 
            this.zoomUpButton.Location = new System.Drawing.Point(103, 292);
            this.zoomUpButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zoomUpButton.Name = "zoomUpButton";
            this.zoomUpButton.Size = new System.Drawing.Size(34, 27);
            this.zoomUpButton.TabIndex = 31;
            this.zoomUpButton.Text = "+";
            this.zoomUpButton.UseVisualStyleBackColor = true;
            this.zoomUpButton.Click += new System.EventHandler(this.ZoomUpButton_Click);
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(12, 299);
            this.zoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(42, 15);
            this.zoomLabel.TabIndex = 25;
            this.zoomLabel.Text = "Zoom:";
            // 
            // progresLabel
            // 
            this.progresLabel.AutoSize = true;
            this.progresLabel.Location = new System.Drawing.Point(1, 594);
            this.progresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progresLabel.Name = "progresLabel";
            this.progresLabel.Size = new System.Drawing.Size(55, 15);
            this.progresLabel.TabIndex = 29;
            this.progresLabel.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(2, 613);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(248, 27);
            this.progressBar.TabIndex = 28;
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Location = new System.Drawing.Point(9, 58);
            this.ImageNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(73, 15);
            this.ImageNameLabel.TabIndex = 26;
            this.ImageNameLabel.Text = "Image name";
            // 
            // ResetZoomButton
            // 
            this.ResetZoomButton.Location = new System.Drawing.Point(156, 262);
            this.ResetZoomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ResetZoomButton.Name = "ResetZoomButton";
            this.ResetZoomButton.Size = new System.Drawing.Size(88, 27);
            this.ResetZoomButton.TabIndex = 27;
            this.ResetZoomButton.Text = "Reset zoom";
            this.ResetZoomButton.UseVisualStyleBackColor = true;
            this.ResetZoomButton.Click += new System.EventHandler(this.InitializeImageScale);
            // 
            // zoomTextbox
            // 
            this.zoomTextbox.Enabled = false;
            this.zoomTextbox.Location = new System.Drawing.Point(156, 294);
            this.zoomTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zoomTextbox.Name = "zoomTextbox";
            this.zoomTextbox.Size = new System.Drawing.Size(86, 23);
            this.zoomTextbox.TabIndex = 32;
            // 
            // ZoomDownButton
            // 
            this.ZoomDownButton.Location = new System.Drawing.Point(62, 292);
            this.ZoomDownButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ZoomDownButton.Name = "ZoomDownButton";
            this.ZoomDownButton.Size = new System.Drawing.Size(34, 27);
            this.ZoomDownButton.TabIndex = 30;
            this.ZoomDownButton.Text = "-";
            this.ZoomDownButton.UseVisualStyleBackColor = true;
            this.ZoomDownButton.Click += new System.EventHandler(this.ZoomDownButton_Click);
            // 
            // RadioButtonsPanel
            // 
            this.RadioButtonsPanel.AutoSize = true;
            this.RadioButtonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RadioButtonsPanel.ColumnCount = 1;
            this.RadioButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RadioButtonsPanel.Controls.Add(this.tensionRadioButton, 0, 8);
            this.RadioButtonsPanel.Controls.Add(this.strainYRadioButton, 0, 6);
            this.RadioButtonsPanel.Controls.Add(this.displacementYRadiobutton, 0, 4);
            this.RadioButtonsPanel.Controls.Add(this.imageRadioButton, 0, 0);
            this.RadioButtonsPanel.Controls.Add(this.pointsRadioButton, 0, 1);
            this.RadioButtonsPanel.Controls.Add(this.displacementVRadioButton, 0, 2);
            this.RadioButtonsPanel.Controls.Add(this.displacementXRadioButton, 0, 3);
            this.RadioButtonsPanel.Controls.Add(this.strainXRadioButton, 0, 5);
            this.RadioButtonsPanel.Controls.Add(this.strainShearRadioButton, 0, 7);
            this.RadioButtonsPanel.Location = new System.Drawing.Point(7, 350);
            this.RadioButtonsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RadioButtonsPanel.Name = "RadioButtonsPanel";
            this.RadioButtonsPanel.RowCount = 9;
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.RadioButtonsPanel.Size = new System.Drawing.Size(146, 225);
            this.RadioButtonsPanel.TabIndex = 37;
            // 
            // tensionRadioButton
            // 
            this.tensionRadioButton.AutoSize = true;
            this.tensionRadioButton.Location = new System.Drawing.Point(4, 203);
            this.tensionRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tensionRadioButton.Name = "tensionRadioButton";
            this.tensionRadioButton.Size = new System.Drawing.Size(65, 19);
            this.tensionRadioButton.TabIndex = 25;
            this.tensionRadioButton.Tag = "8";
            this.tensionRadioButton.Text = "Tension";
            this.tensionRadioButton.UseVisualStyleBackColor = true;
            this.tensionRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // strainYRadioButton
            // 
            this.strainYRadioButton.AutoSize = true;
            this.strainYRadioButton.Location = new System.Drawing.Point(4, 153);
            this.strainYRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.strainYRadioButton.Name = "strainYRadioButton";
            this.strainYRadioButton.Size = new System.Drawing.Size(73, 19);
            this.strainYRadioButton.TabIndex = 23;
            this.strainYRadioButton.Tag = "6";
            this.strainYRadioButton.Text = "Strain (Y)";
            this.strainYRadioButton.UseVisualStyleBackColor = true;
            this.strainYRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // displacementYRadiobutton
            // 
            this.displacementYRadiobutton.AutoSize = true;
            this.displacementYRadiobutton.Location = new System.Drawing.Point(4, 103);
            this.displacementYRadiobutton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displacementYRadiobutton.Name = "displacementYRadiobutton";
            this.displacementYRadiobutton.Size = new System.Drawing.Size(115, 19);
            this.displacementYRadiobutton.TabIndex = 21;
            this.displacementYRadiobutton.Tag = "4";
            this.displacementYRadiobutton.Text = "Displacement (Y)";
            this.displacementYRadiobutton.UseVisualStyleBackColor = true;
            this.displacementYRadiobutton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Checked = true;
            this.imageRadioButton.Location = new System.Drawing.Point(4, 3);
            this.imageRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(58, 19);
            this.imageRadioButton.TabIndex = 16;
            this.imageRadioButton.TabStop = true;
            this.imageRadioButton.Tag = "0";
            this.imageRadioButton.Text = "Image";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            this.imageRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // pointsRadioButton
            // 
            this.pointsRadioButton.AutoSize = true;
            this.pointsRadioButton.Location = new System.Drawing.Point(4, 28);
            this.pointsRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pointsRadioButton.Name = "pointsRadioButton";
            this.pointsRadioButton.Size = new System.Drawing.Size(58, 19);
            this.pointsRadioButton.TabIndex = 18;
            this.pointsRadioButton.Tag = "1";
            this.pointsRadioButton.Text = "Points";
            this.pointsRadioButton.UseVisualStyleBackColor = true;
            this.pointsRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // displacementVRadioButton
            // 
            this.displacementVRadioButton.AutoSize = true;
            this.displacementVRadioButton.Location = new System.Drawing.Point(4, 53);
            this.displacementVRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displacementVRadioButton.Name = "displacementVRadioButton";
            this.displacementVRadioButton.Size = new System.Drawing.Size(138, 19);
            this.displacementVRadioButton.TabIndex = 19;
            this.displacementVRadioButton.Tag = "2";
            this.displacementVRadioButton.Text = "Displacement vectors";
            this.displacementVRadioButton.UseVisualStyleBackColor = true;
            this.displacementVRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // displacementXRadioButton
            // 
            this.displacementXRadioButton.AutoSize = true;
            this.displacementXRadioButton.Location = new System.Drawing.Point(4, 78);
            this.displacementXRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.displacementXRadioButton.Name = "displacementXRadioButton";
            this.displacementXRadioButton.Size = new System.Drawing.Size(115, 19);
            this.displacementXRadioButton.TabIndex = 20;
            this.displacementXRadioButton.Tag = "3";
            this.displacementXRadioButton.Text = "Displacement (X)";
            this.displacementXRadioButton.UseVisualStyleBackColor = true;
            this.displacementXRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // strainXRadioButton
            // 
            this.strainXRadioButton.AutoSize = true;
            this.strainXRadioButton.Location = new System.Drawing.Point(4, 128);
            this.strainXRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.strainXRadioButton.Name = "strainXRadioButton";
            this.strainXRadioButton.Size = new System.Drawing.Size(73, 19);
            this.strainXRadioButton.TabIndex = 22;
            this.strainXRadioButton.Tag = "5";
            this.strainXRadioButton.Text = "Strain (X)";
            this.strainXRadioButton.UseVisualStyleBackColor = true;
            this.strainXRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // strainShearRadioButton
            // 
            this.strainShearRadioButton.AutoSize = true;
            this.strainShearRadioButton.Location = new System.Drawing.Point(4, 178);
            this.strainShearRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.strainShearRadioButton.Name = "strainShearRadioButton";
            this.strainShearRadioButton.Size = new System.Drawing.Size(95, 19);
            this.strainShearRadioButton.TabIndex = 24;
            this.strainShearRadioButton.Tag = "7";
            this.strainShearRadioButton.Text = "Strain (Shear)";
            this.strainShearRadioButton.UseVisualStyleBackColor = true;
            this.strainShearRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // ResultPanel
            // 
            this.ResultPanel.Controls.Add(this.ColorScaleLabel);
            this.ResultPanel.Controls.Add(this.YPosLabel);
            this.ResultPanel.Controls.Add(this.ScalePicturebox);
            this.ResultPanel.Controls.Add(this.MinValLabel);
            this.ResultPanel.Controls.Add(this.XPosLabel);
            this.ResultPanel.Controls.Add(this.MaxValLabel);
            this.ResultPanel.Controls.Add(this.ValueLabel);
            this.ResultPanel.Location = new System.Drawing.Point(0, 647);
            this.ResultPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(254, 107);
            this.ResultPanel.TabIndex = 38;
            // 
            // ColorScaleLabel
            // 
            this.ColorScaleLabel.AutoSize = true;
            this.ColorScaleLabel.Location = new System.Drawing.Point(6, 38);
            this.ColorScaleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ColorScaleLabel.Name = "ColorScaleLabel";
            this.ColorScaleLabel.Size = new System.Drawing.Size(72, 15);
            this.ColorScaleLabel.TabIndex = 15;
            this.ColorScaleLabel.Text = "Color Scale: ";
            // 
            // YPosLabel
            // 
            this.YPosLabel.AutoSize = true;
            this.YPosLabel.Location = new System.Drawing.Point(190, 13);
            this.YPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YPosLabel.Name = "YPosLabel";
            this.YPosLabel.Size = new System.Drawing.Size(26, 15);
            this.YPosLabel.TabIndex = 14;
            this.YPosLabel.Text = "Y: 0";
            // 
            // ScalePicturebox
            // 
            this.ScalePicturebox.Location = new System.Drawing.Point(0, 77);
            this.ScalePicturebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ScalePicturebox.Name = "ScalePicturebox";
            this.ScalePicturebox.Size = new System.Drawing.Size(254, 23);
            this.ScalePicturebox.TabIndex = 11;
            this.ScalePicturebox.TabStop = false;
            // 
            // MinValLabel
            // 
            this.MinValLabel.AutoSize = true;
            this.MinValLabel.Location = new System.Drawing.Point(5, 59);
            this.MinValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinValLabel.Name = "MinValLabel";
            this.MinValLabel.Size = new System.Drawing.Size(37, 15);
            this.MinValLabel.TabIndex = 9;
            this.MinValLabel.Text = "Min:0";
            // 
            // XPosLabel
            // 
            this.XPosLabel.AutoSize = true;
            this.XPosLabel.Location = new System.Drawing.Point(91, 13);
            this.XPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XPosLabel.Name = "XPosLabel";
            this.XPosLabel.Size = new System.Drawing.Size(26, 15);
            this.XPosLabel.TabIndex = 13;
            this.XPosLabel.Text = "X: 0";
            // 
            // MaxValLabel
            // 
            this.MaxValLabel.AutoSize = true;
            this.MaxValLabel.Location = new System.Drawing.Point(190, 59);
            this.MaxValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxValLabel.Name = "MaxValLabel";
            this.MaxValLabel.Size = new System.Drawing.Size(39, 15);
            this.MaxValLabel.TabIndex = 10;
            this.MaxValLabel.Text = "Max:0";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(6, 13);
            this.ValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(47, 15);
            this.ValueLabel.TabIndex = 12;
            this.ValueLabel.Text = "Value: 0";
            // 
            // LoadImagesBackgroundWorker
            // 
            this.LoadImagesBackgroundWorker.WorkerReportsProgress = true;
            this.LoadImagesBackgroundWorker.WorkerSupportsCancellation = false;
            this.LoadImagesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadImagesBackgroundWorker_DoWork);
            this.LoadImagesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadImagesBackgroundWorker_ProgressChanged);
            this.LoadImagesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadImagesBackgroundWorker_RunWorkerCompleted);
            // 
            // PictureboxToolTip
            // 
            this.PictureboxToolTip.AutomaticDelay = 0;
            this.PictureboxToolTip.ShowAlways = true;
            this.PictureboxToolTip.UseAnimation = false;
            this.PictureboxToolTip.UseFading = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 1061);
            this.Controls.Add(this.MainImagePanel);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.imageSliderPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Digital Image Correlation";
            this.MainImagePanel.ResumeLayout(false);
            this.MainImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.imageSliderPanel.ResumeLayout(false);
            this.imageSliderPanel.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.RadioButtonsPanel.ResumeLayout(false);
            this.RadioButtonsPanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicturebox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button openImagesButton;
        private System.Windows.Forms.Label sizeNumberLabel;
        private System.Windows.Forms.Label pointsXLabel;
        private System.Windows.Forms.TextBox pointsXTextbox;
        private System.Windows.Forms.TextBox pointsYTextbox;
        private System.Windows.Forms.Label pointsYLabel;
        private System.Windows.Forms.TextBox subsetDeltaTextbox;
        private System.Windows.Forms.Label subsetDeltaLabel;
        private System.Windows.Forms.TextBox windowDeltaTextbox;
        private System.Windows.Forms.Label windowDeltaLabel;
        private System.Windows.Forms.Button analyzeButton;
        private System.Windows.Forms.CheckBox showCropBoxCheckbox;
        private System.Windows.Forms.Label displayModeLabel;
        private System.Windows.Forms.Panel MainImagePanel;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Panel imageSliderPanel;
        private System.Windows.Forms.OpenFileDialog loadImagesFileDialog;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel LoadImagesPanel;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.Button ResetZoomButton;
        private System.Windows.Forms.Label progresLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker LoadImagesBackgroundWorker;
        private System.Windows.Forms.TextBox zoomTextbox;
        private System.Windows.Forms.Button zoomUpButton;
        private System.Windows.Forms.Button ZoomDownButton;
        private System.Windows.Forms.TableLayoutPanel RadioButtonsPanel;
        private System.Windows.Forms.RadioButton tensionRadioButton;
        private System.Windows.Forms.RadioButton strainYRadioButton;
        private System.Windows.Forms.RadioButton displacementYRadiobutton;
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.RadioButton pointsRadioButton;
        private System.Windows.Forms.RadioButton displacementVRadioButton;
        private System.Windows.Forms.RadioButton displacementXRadioButton;
        private System.Windows.Forms.RadioButton strainXRadioButton;
        private System.Windows.Forms.RadioButton strainShearRadioButton;
        private System.Windows.Forms.Panel ResultPanel;
        private System.Windows.Forms.Label YPosLabel;
        private System.Windows.Forms.Label XPosLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.PictureBox ScalePicturebox;
        private System.Windows.Forms.Label MaxValLabel;
        private System.Windows.Forms.Label MinValLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label ColorScaleLabel;
        private System.Windows.Forms.ToolTip PictureboxToolTip;
    }
}

