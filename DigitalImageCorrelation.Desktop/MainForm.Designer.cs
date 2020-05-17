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
            this.sizeLabel = new System.Windows.Forms.Label();
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
            this.loadImagesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.LoadImagesPanel = new System.Windows.Forms.Panel();
            this.LoadImagesLabel = new System.Windows.Forms.Label();
            this.MainImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            this.imageSliderPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.LoadImagesPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagesButton
            // 
            this.openImagesButton.Location = new System.Drawing.Point(3, 3);
            this.openImagesButton.Name = "openImagesButton";
            this.openImagesButton.Size = new System.Drawing.Size(202, 41);
            this.openImagesButton.TabIndex = 1;
            this.openImagesButton.Text = "Open images";
            this.openImagesButton.UseVisualStyleBackColor = true;
            this.openImagesButton.Click += new System.EventHandler(this.openImagesButton_Click);
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(4, 51);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "Size";
            // 
            // sizeNumberLabel
            // 
            this.sizeNumberLabel.AutoSize = true;
            this.sizeNumberLabel.Location = new System.Drawing.Point(4, 73);
            this.sizeNumberLabel.Name = "sizeNumberLabel";
            this.sizeNumberLabel.Size = new System.Drawing.Size(38, 13);
            this.sizeNumberLabel.TabIndex = 3;
            this.sizeNumberLabel.Text = "0x0 px";
            // 
            // pointsXLabel
            // 
            this.pointsXLabel.AutoSize = true;
            this.pointsXLabel.Location = new System.Drawing.Point(4, 96);
            this.pointsXLabel.Name = "pointsXLabel";
            this.pointsXLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsXLabel.TabIndex = 4;
            this.pointsXLabel.Text = "Points in X";
            // 
            // pointsXTextbox
            // 
            this.pointsXTextbox.Location = new System.Drawing.Point(3, 113);
            this.pointsXTextbox.Name = "pointsXTextbox";
            this.pointsXTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsXTextbox.TabIndex = 5;
            this.pointsXTextbox.Text = "40";
            // 
            // pointsYTextbox
            // 
            this.pointsYTextbox.Location = new System.Drawing.Point(137, 113);
            this.pointsYTextbox.Name = "pointsYTextbox";
            this.pointsYTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsYTextbox.TabIndex = 7;
            this.pointsYTextbox.Text = "40";
            // 
            // pointsYLabel
            // 
            this.pointsYLabel.AutoSize = true;
            this.pointsYLabel.Location = new System.Drawing.Point(138, 96);
            this.pointsYLabel.Name = "pointsYLabel";
            this.pointsYLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsYLabel.TabIndex = 6;
            this.pointsYLabel.Text = "Points in Y";
            // 
            // subsetDeltaTextbox
            // 
            this.subsetDeltaTextbox.Location = new System.Drawing.Point(3, 155);
            this.subsetDeltaTextbox.Name = "subsetDeltaTextbox";
            this.subsetDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.subsetDeltaTextbox.TabIndex = 9;
            this.subsetDeltaTextbox.Text = "15";
            // 
            // subsetDeltaLabel
            // 
            this.subsetDeltaLabel.AutoSize = true;
            this.subsetDeltaLabel.Location = new System.Drawing.Point(4, 138);
            this.subsetDeltaLabel.Name = "subsetDeltaLabel";
            this.subsetDeltaLabel.Size = new System.Drawing.Size(66, 13);
            this.subsetDeltaLabel.TabIndex = 8;
            this.subsetDeltaLabel.Text = "Subset delta";
            // 
            // windowDeltaTextbox
            // 
            this.windowDeltaTextbox.Location = new System.Drawing.Point(137, 155);
            this.windowDeltaTextbox.Name = "windowDeltaTextbox";
            this.windowDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.windowDeltaTextbox.TabIndex = 11;
            this.windowDeltaTextbox.Text = "20";
            // 
            // windowDeltaLabel
            // 
            this.windowDeltaLabel.AutoSize = true;
            this.windowDeltaLabel.Location = new System.Drawing.Point(138, 138);
            this.windowDeltaLabel.Name = "windowDeltaLabel";
            this.windowDeltaLabel.Size = new System.Drawing.Size(72, 13);
            this.windowDeltaLabel.TabIndex = 10;
            this.windowDeltaLabel.Text = "Window delta";
            // 
            // analyzeButton
            // 
            this.analyzeButton.Enabled = false;
            this.analyzeButton.Location = new System.Drawing.Point(3, 181);
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
            this.showCropBoxCheckbox.Location = new System.Drawing.Point(3, 229);
            this.showCropBoxCheckbox.Name = "showCropBoxCheckbox";
            this.showCropBoxCheckbox.Size = new System.Drawing.Size(97, 17);
            this.showCropBoxCheckbox.TabIndex = 13;
            this.showCropBoxCheckbox.Text = "Show crop box";
            this.showCropBoxCheckbox.UseVisualStyleBackColor = true;
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.Location = new System.Drawing.Point(4, 249);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(68, 13);
            this.displayModeLabel.TabIndex = 14;
            this.displayModeLabel.Text = "DisplayMode";
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Checked = true;
            this.imageRadioButton.Location = new System.Drawing.Point(3, 266);
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
            this.pointsRadioButton.Location = new System.Drawing.Point(3, 289);
            this.pointsRadioButton.Name = "pointsRadioButton";
            this.pointsRadioButton.Size = new System.Drawing.Size(54, 17);
            this.pointsRadioButton.TabIndex = 16;
            this.pointsRadioButton.Text = "Points";
            this.pointsRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementVRadioButton
            // 
            this.displacementVRadioButton.AutoSize = true;
            this.displacementVRadioButton.Location = new System.Drawing.Point(3, 312);
            this.displacementVRadioButton.Name = "displacementVRadioButton";
            this.displacementVRadioButton.Size = new System.Drawing.Size(127, 17);
            this.displacementVRadioButton.TabIndex = 17;
            this.displacementVRadioButton.Text = "Displacement vectors";
            this.displacementVRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementXRadioButton
            // 
            this.displacementXRadioButton.AutoSize = true;
            this.displacementXRadioButton.Location = new System.Drawing.Point(3, 335);
            this.displacementXRadioButton.Name = "displacementXRadioButton";
            this.displacementXRadioButton.Size = new System.Drawing.Size(105, 17);
            this.displacementXRadioButton.TabIndex = 18;
            this.displacementXRadioButton.Text = "Displacement (X)";
            this.displacementXRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementYRadiobutton
            // 
            this.displacementYRadiobutton.AutoSize = true;
            this.displacementYRadiobutton.Location = new System.Drawing.Point(3, 358);
            this.displacementYRadiobutton.Name = "displacementYRadiobutton";
            this.displacementYRadiobutton.Size = new System.Drawing.Size(105, 17);
            this.displacementYRadiobutton.TabIndex = 19;
            this.displacementYRadiobutton.Text = "Displacement (Y)";
            this.displacementYRadiobutton.UseVisualStyleBackColor = true;
            // 
            // strainXRadioButton
            // 
            this.strainXRadioButton.AutoSize = true;
            this.strainXRadioButton.Location = new System.Drawing.Point(3, 381);
            this.strainXRadioButton.Name = "strainXRadioButton";
            this.strainXRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainXRadioButton.TabIndex = 20;
            this.strainXRadioButton.Text = "Strain (X)";
            this.strainXRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainYRadioButton
            // 
            this.strainYRadioButton.AutoSize = true;
            this.strainYRadioButton.Location = new System.Drawing.Point(3, 404);
            this.strainYRadioButton.Name = "strainYRadioButton";
            this.strainYRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainYRadioButton.TabIndex = 21;
            this.strainYRadioButton.Text = "Strain (Y)";
            this.strainYRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainShearRadioButton
            // 
            this.strainShearRadioButton.AutoSize = true;
            this.strainShearRadioButton.Location = new System.Drawing.Point(3, 427);
            this.strainShearRadioButton.Name = "strainShearRadioButton";
            this.strainShearRadioButton.Size = new System.Drawing.Size(89, 17);
            this.strainShearRadioButton.TabIndex = 22;
            this.strainShearRadioButton.Text = "Strain (Shear)";
            this.strainShearRadioButton.UseVisualStyleBackColor = true;
            // 
            // tensionRadioButton
            // 
            this.tensionRadioButton.AutoSize = true;
            this.tensionRadioButton.Location = new System.Drawing.Point(3, 450);
            this.tensionRadioButton.Name = "tensionRadioButton";
            this.tensionRadioButton.Size = new System.Drawing.Size(63, 17);
            this.tensionRadioButton.TabIndex = 23;
            this.tensionRadioButton.Text = "Tension";
            this.tensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainImagePanel
            // 
            this.MainImagePanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MainImagePanel.Controls.Add(this.MainPictureBox);
            this.MainImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainImagePanel.Location = new System.Drawing.Point(0, 53);
            this.MainImagePanel.Name = "MainImagePanel";
            this.MainImagePanel.Size = new System.Drawing.Size(890, 714);
            this.MainImagePanel.TabIndex = 34;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.DimGray;
            this.MainPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 0);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(890, 714);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPictureBox_Paint);
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // imageSliderPanel
            // 
            this.imageSliderPanel.AutoScroll = true;
            this.imageSliderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageSliderPanel.Controls.Add(this.LoadImagesPanel);
            this.imageSliderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.imageSliderPanel.Location = new System.Drawing.Point(0, 0);
            this.imageSliderPanel.Name = "imageSliderPanel";
            this.imageSliderPanel.Size = new System.Drawing.Size(1108, 53);
            this.imageSliderPanel.TabIndex = 35;
            // 
            // loadImagesFileDialog
            // 
            this.loadImagesFileDialog.Filter = "*.BMP;*.JPG;*.GIF|";
            this.loadImagesFileDialog.Multiselect = true;
            this.loadImagesFileDialog.Title = "Load Images to analyze";
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(this.openImagesButton);
            this.optionsPanel.Controls.Add(this.sizeLabel);
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
            // LoadImagesPanel
            // 
            this.LoadImagesPanel.Controls.Add(this.LoadImagesLabel);
            this.LoadImagesPanel.Location = new System.Drawing.Point(4, 4);
            this.LoadImagesPanel.Name = "LoadImagesPanel";
            this.LoadImagesPanel.Size = new System.Drawing.Size(89, 32);
            this.LoadImagesPanel.TabIndex = 0;
            // 
            // LoadImagesLabel
            // 
            this.LoadImagesLabel.AutoSize = true;
            this.LoadImagesLabel.Location = new System.Drawing.Point(8, 8);
            this.LoadImagesLabel.Name = "LoadImagesLabel";
            this.LoadImagesLabel.Size = new System.Drawing.Size(67, 13);
            this.LoadImagesLabel.TabIndex = 0;
            this.LoadImagesLabel.Text = "Load images";
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
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            this.imageSliderPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.LoadImagesPanel.ResumeLayout(false);
            this.LoadImagesPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button openImagesButton;
        private System.Windows.Forms.Label sizeLabel;
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
        private System.Windows.Forms.Label LoadImagesLabel;
    }
}

