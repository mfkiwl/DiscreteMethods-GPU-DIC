namespace DigitalImageCorrelation.Desktop
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
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.pointsRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementVRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementXRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementYRadiobutton = new System.Windows.Forms.RadioButton();
            this.strainXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainYRadioButton = new System.Windows.Forms.RadioButton();
            this.strainShearRadioButton = new System.Windows.Forms.RadioButton();
            this.tensionRadioButton = new System.Windows.Forms.RadioButton();
            this.MainImagePanel = new System.Windows.Forms.Panel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.imageSliderPanel = new System.Windows.Forms.Panel();
            this.LoadImagesPanel = new System.Windows.Forms.Panel();
            this.loadImagesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.progresLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ResetZoomButton = new System.Windows.Forms.Button();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.zoomTrackBar = new System.Windows.Forms.TrackBar();
            this.LoadImagesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.MainImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.imageSliderPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // openImagesButton
            // 
            this.openImagesButton.Location = new System.Drawing.Point(6, 6);
            this.openImagesButton.Name = "openImagesButton";
            this.openImagesButton.Size = new System.Drawing.Size(202, 41);
            this.openImagesButton.TabIndex = 1;
            this.openImagesButton.Text = "Open images";
            this.openImagesButton.UseVisualStyleBackColor = true;
            this.openImagesButton.Click += new System.EventHandler(this.OpenImagesButton_Click);
            // 
            // sizeNumberLabel
            // 
            this.sizeNumberLabel.AutoSize = true;
            this.sizeNumberLabel.Location = new System.Drawing.Point(8, 72);
            this.sizeNumberLabel.Name = "sizeNumberLabel";
            this.sizeNumberLabel.Size = new System.Drawing.Size(38, 13);
            this.sizeNumberLabel.TabIndex = 3;
            this.sizeNumberLabel.Text = "0x0 px";
            // 
            // pointsXLabel
            // 
            this.pointsXLabel.AutoSize = true;
            this.pointsXLabel.Location = new System.Drawing.Point(8, 95);
            this.pointsXLabel.Name = "pointsXLabel";
            this.pointsXLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsXLabel.TabIndex = 4;
            this.pointsXLabel.Text = "Points in X";
            // 
            // pointsXTextbox
            // 
            this.pointsXTextbox.Location = new System.Drawing.Point(7, 112);
            this.pointsXTextbox.Name = "pointsXTextbox";
            this.pointsXTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsXTextbox.TabIndex = 5;
            this.pointsXTextbox.Text = "40";
            this.pointsXTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // pointsYTextbox
            // 
            this.pointsYTextbox.Location = new System.Drawing.Point(141, 112);
            this.pointsYTextbox.Name = "pointsYTextbox";
            this.pointsYTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsYTextbox.TabIndex = 7;
            this.pointsYTextbox.Text = "40";
            this.pointsYTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // pointsYLabel
            // 
            this.pointsYLabel.AutoSize = true;
            this.pointsYLabel.Location = new System.Drawing.Point(142, 95);
            this.pointsYLabel.Name = "pointsYLabel";
            this.pointsYLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsYLabel.TabIndex = 6;
            this.pointsYLabel.Text = "Points in Y";
            // 
            // subsetDeltaTextbox
            // 
            this.subsetDeltaTextbox.Location = new System.Drawing.Point(7, 154);
            this.subsetDeltaTextbox.Name = "subsetDeltaTextbox";
            this.subsetDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.subsetDeltaTextbox.TabIndex = 9;
            this.subsetDeltaTextbox.Text = "15";
            this.subsetDeltaTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // subsetDeltaLabel
            // 
            this.subsetDeltaLabel.AutoSize = true;
            this.subsetDeltaLabel.Location = new System.Drawing.Point(8, 137);
            this.subsetDeltaLabel.Name = "subsetDeltaLabel";
            this.subsetDeltaLabel.Size = new System.Drawing.Size(66, 13);
            this.subsetDeltaLabel.TabIndex = 8;
            this.subsetDeltaLabel.Text = "Subset delta";
            // 
            // windowDeltaTextbox
            // 
            this.windowDeltaTextbox.Location = new System.Drawing.Point(141, 154);
            this.windowDeltaTextbox.Name = "windowDeltaTextbox";
            this.windowDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.windowDeltaTextbox.TabIndex = 11;
            this.windowDeltaTextbox.Text = "20";
            this.windowDeltaTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // windowDeltaLabel
            // 
            this.windowDeltaLabel.AutoSize = true;
            this.windowDeltaLabel.Location = new System.Drawing.Point(142, 137);
            this.windowDeltaLabel.Name = "windowDeltaLabel";
            this.windowDeltaLabel.Size = new System.Drawing.Size(72, 13);
            this.windowDeltaLabel.TabIndex = 10;
            this.windowDeltaLabel.Text = "Window delta";
            // 
            // analyzeButton
            // 
            this.analyzeButton.Enabled = false;
            this.analyzeButton.Location = new System.Drawing.Point(7, 180);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(202, 41);
            this.analyzeButton.TabIndex = 12;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            // 
            // showCropBoxCheckbox
            // 
            this.showCropBoxCheckbox.AutoSize = true;
            this.showCropBoxCheckbox.Checked = true;
            this.showCropBoxCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCropBoxCheckbox.Location = new System.Drawing.Point(7, 227);
            this.showCropBoxCheckbox.Name = "showCropBoxCheckbox";
            this.showCropBoxCheckbox.Size = new System.Drawing.Size(97, 17);
            this.showCropBoxCheckbox.TabIndex = 13;
            this.showCropBoxCheckbox.Text = "Show crop box";
            this.showCropBoxCheckbox.UseVisualStyleBackColor = true;
            this.showCropBoxCheckbox.CheckedChanged += new System.EventHandler(this.showCropBoxCheckbox_CheckedChanged);
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.Location = new System.Drawing.Point(10, 311);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(68, 13);
            this.displayModeLabel.TabIndex = 14;
            this.displayModeLabel.Text = "DisplayMode";
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Checked = true;
            this.imageRadioButton.Location = new System.Drawing.Point(13, 327);
            this.imageRadioButton.Name = "imageRadioButton";
            this.imageRadioButton.Size = new System.Drawing.Size(54, 17);
            this.imageRadioButton.TabIndex = 15;
            this.imageRadioButton.TabStop = true;
            this.imageRadioButton.Text = "Image";
            this.imageRadioButton.UseVisualStyleBackColor = true;
            // 
            // pointsRadioButton
            // 
            this.pointsRadioButton.AutoSize = true;
            this.pointsRadioButton.Location = new System.Drawing.Point(13, 350);
            this.pointsRadioButton.Name = "pointsRadioButton";
            this.pointsRadioButton.Size = new System.Drawing.Size(54, 17);
            this.pointsRadioButton.TabIndex = 16;
            this.pointsRadioButton.Text = "Points";
            this.pointsRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementVRadioButton
            // 
            this.displacementVRadioButton.AutoSize = true;
            this.displacementVRadioButton.Location = new System.Drawing.Point(13, 373);
            this.displacementVRadioButton.Name = "displacementVRadioButton";
            this.displacementVRadioButton.Size = new System.Drawing.Size(127, 17);
            this.displacementVRadioButton.TabIndex = 17;
            this.displacementVRadioButton.Text = "Displacement vectors";
            this.displacementVRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementXRadioButton
            // 
            this.displacementXRadioButton.AutoSize = true;
            this.displacementXRadioButton.Location = new System.Drawing.Point(13, 396);
            this.displacementXRadioButton.Name = "displacementXRadioButton";
            this.displacementXRadioButton.Size = new System.Drawing.Size(105, 17);
            this.displacementXRadioButton.TabIndex = 18;
            this.displacementXRadioButton.Text = "Displacement (X)";
            this.displacementXRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementYRadiobutton
            // 
            this.displacementYRadiobutton.AutoSize = true;
            this.displacementYRadiobutton.Location = new System.Drawing.Point(13, 419);
            this.displacementYRadiobutton.Name = "displacementYRadiobutton";
            this.displacementYRadiobutton.Size = new System.Drawing.Size(105, 17);
            this.displacementYRadiobutton.TabIndex = 19;
            this.displacementYRadiobutton.Text = "Displacement (Y)";
            this.displacementYRadiobutton.UseVisualStyleBackColor = true;
            // 
            // strainXRadioButton
            // 
            this.strainXRadioButton.AutoSize = true;
            this.strainXRadioButton.Location = new System.Drawing.Point(13, 442);
            this.strainXRadioButton.Name = "strainXRadioButton";
            this.strainXRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainXRadioButton.TabIndex = 20;
            this.strainXRadioButton.Text = "Strain (X)";
            this.strainXRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainYRadioButton
            // 
            this.strainYRadioButton.AutoSize = true;
            this.strainYRadioButton.Location = new System.Drawing.Point(13, 465);
            this.strainYRadioButton.Name = "strainYRadioButton";
            this.strainYRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainYRadioButton.TabIndex = 21;
            this.strainYRadioButton.Text = "Strain (Y)";
            this.strainYRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainShearRadioButton
            // 
            this.strainShearRadioButton.AutoSize = true;
            this.strainShearRadioButton.Location = new System.Drawing.Point(13, 488);
            this.strainShearRadioButton.Name = "strainShearRadioButton";
            this.strainShearRadioButton.Size = new System.Drawing.Size(89, 17);
            this.strainShearRadioButton.TabIndex = 22;
            this.strainShearRadioButton.Text = "Strain (Shear)";
            this.strainShearRadioButton.UseVisualStyleBackColor = true;
            // 
            // tensionRadioButton
            // 
            this.tensionRadioButton.AutoSize = true;
            this.tensionRadioButton.Location = new System.Drawing.Point(13, 511);
            this.tensionRadioButton.Name = "tensionRadioButton";
            this.tensionRadioButton.Size = new System.Drawing.Size(63, 17);
            this.tensionRadioButton.TabIndex = 23;
            this.tensionRadioButton.Text = "Tension";
            this.tensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainImagePanel
            // 
            this.MainImagePanel.AutoScroll = true;
            this.MainImagePanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.MainImagePanel.Controls.Add(this.MainPictureBox);
            this.MainImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainImagePanel.Location = new System.Drawing.Point(0, 53);
            this.MainImagePanel.Name = "MainImagePanel";
            this.MainImagePanel.Size = new System.Drawing.Size(890, 714);
            this.MainImagePanel.TabIndex = 34;
            this.MainImagePanel.SizeChanged += new System.EventHandler(this.InitializeImageScale);
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(890, 714);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // imageSliderPanel
            // 
            this.imageSliderPanel.AutoScroll = true;
            this.imageSliderPanel.Controls.Add(this.LoadImagesPanel);
            this.imageSliderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageSliderPanel.Location = new System.Drawing.Point(0, 0);
            this.imageSliderPanel.Name = "imageSliderPanel";
            this.imageSliderPanel.Size = new System.Drawing.Size(1108, 53);
            this.imageSliderPanel.TabIndex = 35;
            // 
            // LoadImagesPanel
            // 
            this.LoadImagesPanel.AutoScroll = true;
            this.LoadImagesPanel.AutoSize = true;
            this.LoadImagesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadImagesPanel.Location = new System.Drawing.Point(0, 0);
            this.LoadImagesPanel.Name = "LoadImagesPanel";
            this.LoadImagesPanel.Size = new System.Drawing.Size(1108, 53);
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
            this.optionsPanel.Controls.Add(this.progresLabel);
            this.optionsPanel.Controls.Add(this.progressBar);
            this.optionsPanel.Controls.Add(this.ResetZoomButton);
            this.optionsPanel.Controls.Add(this.ImageNameLabel);
            this.optionsPanel.Controls.Add(this.zoomLabel);
            this.optionsPanel.Controls.Add(this.zoomTrackBar);
            this.optionsPanel.Controls.Add(this.openImagesButton);
            this.optionsPanel.Controls.Add(this.sizeNumberLabel);
            this.optionsPanel.Controls.Add(this.tensionRadioButton);
            this.optionsPanel.Controls.Add(this.pointsXLabel);
            this.optionsPanel.Controls.Add(this.strainShearRadioButton);
            this.optionsPanel.Controls.Add(this.pointsXTextbox);
            this.optionsPanel.Controls.Add(this.strainYRadioButton);
            this.optionsPanel.Controls.Add(this.pointsYLabel);
            this.optionsPanel.Controls.Add(this.strainXRadioButton);
            this.optionsPanel.Controls.Add(this.pointsYTextbox);
            this.optionsPanel.Controls.Add(this.displacementYRadiobutton);
            this.optionsPanel.Controls.Add(this.subsetDeltaLabel);
            this.optionsPanel.Controls.Add(this.displacementXRadioButton);
            this.optionsPanel.Controls.Add(this.subsetDeltaTextbox);
            this.optionsPanel.Controls.Add(this.displacementVRadioButton);
            this.optionsPanel.Controls.Add(this.windowDeltaLabel);
            this.optionsPanel.Controls.Add(this.pointsRadioButton);
            this.optionsPanel.Controls.Add(this.windowDeltaTextbox);
            this.optionsPanel.Controls.Add(this.imageRadioButton);
            this.optionsPanel.Controls.Add(this.analyzeButton);
            this.optionsPanel.Controls.Add(this.displayModeLabel);
            this.optionsPanel.Controls.Add(this.showCropBoxCheckbox);
            this.optionsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsPanel.Location = new System.Drawing.Point(890, 53);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(218, 714);
            this.optionsPanel.TabIndex = 36;
            // 
            // progresLabel
            // 
            this.progresLabel.AutoSize = true;
            this.progresLabel.Location = new System.Drawing.Point(6, 539);
            this.progresLabel.Name = "progresLabel";
            this.progresLabel.Size = new System.Drawing.Size(51, 13);
            this.progresLabel.TabIndex = 29;
            this.progresLabel.Text = "Progress:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(7, 555);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(203, 23);
            this.progressBar.TabIndex = 28;
            // 
            // ResetZoomButton
            // 
            this.ResetZoomButton.Location = new System.Drawing.Point(134, 227);
            this.ResetZoomButton.Name = "ResetZoomButton";
            this.ResetZoomButton.Size = new System.Drawing.Size(75, 23);
            this.ResetZoomButton.TabIndex = 27;
            this.ResetZoomButton.Text = "Reset zoom";
            this.ResetZoomButton.UseVisualStyleBackColor = true;
            this.ResetZoomButton.Click += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Location = new System.Drawing.Point(8, 50);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(65, 13);
            this.ImageNameLabel.TabIndex = 26;
            this.ImageNameLabel.Text = "Image name";
            // 
            // zoomLabel
            // 
            this.zoomLabel.AutoSize = true;
            this.zoomLabel.Location = new System.Drawing.Point(9, 247);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(37, 13);
            this.zoomLabel.TabIndex = 25;
            this.zoomLabel.Text = "Zoom:";
            // 
            // zoomTrackBar
            // 
            this.zoomTrackBar.LargeChange = 20;
            this.zoomTrackBar.Location = new System.Drawing.Point(7, 263);
            this.zoomTrackBar.Maximum = 250;
            this.zoomTrackBar.Minimum = 10;
            this.zoomTrackBar.Name = "zoomTrackBar";
            this.zoomTrackBar.Size = new System.Drawing.Size(199, 45);
            this.zoomTrackBar.SmallChange = 2;
            this.zoomTrackBar.TabIndex = 24;
            this.zoomTrackBar.Value = 100;
            this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
            // 
            // LoadImagesBackgroundWorker
            // 
            this.LoadImagesBackgroundWorker.WorkerReportsProgress = true;
            this.LoadImagesBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadImagesBackgroundWorker_DoWork);
            this.LoadImagesBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadImagesBackgroundWorker_ProgressChanged);
            this.LoadImagesBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadImagesBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 767);
            this.Controls.Add(this.MainImagePanel);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.imageSliderPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Digital Image Correlation";
            this.MainImagePanel.ResumeLayout(false);
            this.MainImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.imageSliderPanel.ResumeLayout(false);
            this.imageSliderPanel.PerformLayout();
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
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
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.RadioButton pointsRadioButton;
        private System.Windows.Forms.RadioButton displacementVRadioButton;
        private System.Windows.Forms.RadioButton displacementXRadioButton;
        private System.Windows.Forms.RadioButton displacementYRadiobutton;
        private System.Windows.Forms.RadioButton strainXRadioButton;
        private System.Windows.Forms.RadioButton strainYRadioButton;
        private System.Windows.Forms.RadioButton strainShearRadioButton;
        private System.Windows.Forms.RadioButton tensionRadioButton;
        private System.Windows.Forms.Panel MainImagePanel;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Panel imageSliderPanel;
        private System.Windows.Forms.OpenFileDialog loadImagesFileDialog;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.Panel LoadImagesPanel;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.Button ResetZoomButton;
        private System.Windows.Forms.Label progresLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker LoadImagesBackgroundWorker;
    }
}

