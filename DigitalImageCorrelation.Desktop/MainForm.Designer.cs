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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagesButton
            // 
            this.openImagesButton.Location = new System.Drawing.Point(894, 71);
            this.openImagesButton.Name = "openImagesButton";
            this.openImagesButton.Size = new System.Drawing.Size(202, 41);
            this.openImagesButton.TabIndex = 1;
            this.openImagesButton.Text = "Open images";
            this.openImagesButton.UseVisualStyleBackColor = true;
            // 
            // sizeLabel
            // 
            this.sizeLabel.AutoSize = true;
            this.sizeLabel.Location = new System.Drawing.Point(895, 119);
            this.sizeLabel.Name = "sizeLabel";
            this.sizeLabel.Size = new System.Drawing.Size(27, 13);
            this.sizeLabel.TabIndex = 2;
            this.sizeLabel.Text = "Size";
            // 
            // sizeNumberLabel
            // 
            this.sizeNumberLabel.AutoSize = true;
            this.sizeNumberLabel.Location = new System.Drawing.Point(895, 141);
            this.sizeNumberLabel.Name = "sizeNumberLabel";
            this.sizeNumberLabel.Size = new System.Drawing.Size(38, 13);
            this.sizeNumberLabel.TabIndex = 3;
            this.sizeNumberLabel.Text = "0x0 px";
            // 
            // pointsXLabel
            // 
            this.pointsXLabel.AutoSize = true;
            this.pointsXLabel.Location = new System.Drawing.Point(895, 164);
            this.pointsXLabel.Name = "pointsXLabel";
            this.pointsXLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsXLabel.TabIndex = 4;
            this.pointsXLabel.Text = "Points in X";
            // 
            // pointsXTextbox
            // 
            this.pointsXTextbox.Location = new System.Drawing.Point(894, 181);
            this.pointsXTextbox.Name = "pointsXTextbox";
            this.pointsXTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsXTextbox.TabIndex = 5;
            // 
            // pointsYTextbox
            // 
            this.pointsYTextbox.Location = new System.Drawing.Point(1028, 181);
            this.pointsYTextbox.Name = "pointsYTextbox";
            this.pointsYTextbox.Size = new System.Drawing.Size(68, 20);
            this.pointsYTextbox.TabIndex = 7;
            // 
            // pointsYLabel
            // 
            this.pointsYLabel.AutoSize = true;
            this.pointsYLabel.Location = new System.Drawing.Point(1029, 164);
            this.pointsYLabel.Name = "pointsYLabel";
            this.pointsYLabel.Size = new System.Drawing.Size(57, 13);
            this.pointsYLabel.TabIndex = 6;
            this.pointsYLabel.Text = "Points in Y";
            // 
            // subsetDeltaTextbox
            // 
            this.subsetDeltaTextbox.Location = new System.Drawing.Point(894, 223);
            this.subsetDeltaTextbox.Name = "subsetDeltaTextbox";
            this.subsetDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.subsetDeltaTextbox.TabIndex = 9;
            // 
            // subsetDeltaLabel
            // 
            this.subsetDeltaLabel.AutoSize = true;
            this.subsetDeltaLabel.Location = new System.Drawing.Point(895, 206);
            this.subsetDeltaLabel.Name = "subsetDeltaLabel";
            this.subsetDeltaLabel.Size = new System.Drawing.Size(66, 13);
            this.subsetDeltaLabel.TabIndex = 8;
            this.subsetDeltaLabel.Text = "Subset delta";
            // 
            // windowDeltaTextbox
            // 
            this.windowDeltaTextbox.Location = new System.Drawing.Point(1028, 223);
            this.windowDeltaTextbox.Name = "windowDeltaTextbox";
            this.windowDeltaTextbox.Size = new System.Drawing.Size(68, 20);
            this.windowDeltaTextbox.TabIndex = 11;
            // 
            // windowDeltaLabel
            // 
            this.windowDeltaLabel.AutoSize = true;
            this.windowDeltaLabel.Location = new System.Drawing.Point(1029, 206);
            this.windowDeltaLabel.Name = "windowDeltaLabel";
            this.windowDeltaLabel.Size = new System.Drawing.Size(72, 13);
            this.windowDeltaLabel.TabIndex = 10;
            this.windowDeltaLabel.Text = "Window delta";
            // 
            // analyzeButton
            // 
            this.analyzeButton.Location = new System.Drawing.Point(894, 249);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(202, 41);
            this.analyzeButton.TabIndex = 12;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            // 
            // showCropBoxCheckbox
            // 
            this.showCropBoxCheckbox.AutoSize = true;
            this.showCropBoxCheckbox.Location = new System.Drawing.Point(894, 297);
            this.showCropBoxCheckbox.Name = "showCropBoxCheckbox";
            this.showCropBoxCheckbox.Size = new System.Drawing.Size(97, 17);
            this.showCropBoxCheckbox.TabIndex = 13;
            this.showCropBoxCheckbox.Text = "Show crop box";
            this.showCropBoxCheckbox.UseVisualStyleBackColor = true;
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.Location = new System.Drawing.Point(895, 317);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(68, 13);
            this.displayModeLabel.TabIndex = 14;
            this.displayModeLabel.Text = "DisplayMode";
            // 
            // imageRadioButton
            // 
            this.imageRadioButton.AutoSize = true;
            this.imageRadioButton.Location = new System.Drawing.Point(894, 334);
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
            this.pointsRadioButton.Location = new System.Drawing.Point(894, 357);
            this.pointsRadioButton.Name = "pointsRadioButton";
            this.pointsRadioButton.Size = new System.Drawing.Size(54, 17);
            this.pointsRadioButton.TabIndex = 16;
            this.pointsRadioButton.TabStop = true;
            this.pointsRadioButton.Text = "Points";
            this.pointsRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementVRadioButton
            // 
            this.displacementVRadioButton.AutoSize = true;
            this.displacementVRadioButton.Location = new System.Drawing.Point(894, 380);
            this.displacementVRadioButton.Name = "displacementVRadioButton";
            this.displacementVRadioButton.Size = new System.Drawing.Size(127, 17);
            this.displacementVRadioButton.TabIndex = 17;
            this.displacementVRadioButton.TabStop = true;
            this.displacementVRadioButton.Text = "Displacement vectors";
            this.displacementVRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementXRadioButton
            // 
            this.displacementXRadioButton.AutoSize = true;
            this.displacementXRadioButton.Location = new System.Drawing.Point(894, 403);
            this.displacementXRadioButton.Name = "displacementXRadioButton";
            this.displacementXRadioButton.Size = new System.Drawing.Size(105, 17);
            this.displacementXRadioButton.TabIndex = 18;
            this.displacementXRadioButton.TabStop = true;
            this.displacementXRadioButton.Text = "Displacement (X)";
            this.displacementXRadioButton.UseVisualStyleBackColor = true;
            // 
            // displacementYRadiobutton
            // 
            this.displacementYRadiobutton.AutoSize = true;
            this.displacementYRadiobutton.Location = new System.Drawing.Point(894, 426);
            this.displacementYRadiobutton.Name = "displacementYRadiobutton";
            this.displacementYRadiobutton.Size = new System.Drawing.Size(105, 17);
            this.displacementYRadiobutton.TabIndex = 19;
            this.displacementYRadiobutton.TabStop = true;
            this.displacementYRadiobutton.Text = "Displacement (Y)";
            this.displacementYRadiobutton.UseVisualStyleBackColor = true;
            // 
            // strainXRadioButton
            // 
            this.strainXRadioButton.AutoSize = true;
            this.strainXRadioButton.Location = new System.Drawing.Point(894, 449);
            this.strainXRadioButton.Name = "strainXRadioButton";
            this.strainXRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainXRadioButton.TabIndex = 20;
            this.strainXRadioButton.TabStop = true;
            this.strainXRadioButton.Text = "Strain (X)";
            this.strainXRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainYRadioButton
            // 
            this.strainYRadioButton.AutoSize = true;
            this.strainYRadioButton.Location = new System.Drawing.Point(894, 472);
            this.strainYRadioButton.Name = "strainYRadioButton";
            this.strainYRadioButton.Size = new System.Drawing.Size(68, 17);
            this.strainYRadioButton.TabIndex = 21;
            this.strainYRadioButton.TabStop = true;
            this.strainYRadioButton.Text = "Strain (Y)";
            this.strainYRadioButton.UseVisualStyleBackColor = true;
            // 
            // strainShearRadioButton
            // 
            this.strainShearRadioButton.AutoSize = true;
            this.strainShearRadioButton.Location = new System.Drawing.Point(894, 495);
            this.strainShearRadioButton.Name = "strainShearRadioButton";
            this.strainShearRadioButton.Size = new System.Drawing.Size(89, 17);
            this.strainShearRadioButton.TabIndex = 22;
            this.strainShearRadioButton.TabStop = true;
            this.strainShearRadioButton.Text = "Strain (Shear)";
            this.strainShearRadioButton.UseVisualStyleBackColor = true;
            // 
            // tensionRadioButton
            // 
            this.tensionRadioButton.AutoSize = true;
            this.tensionRadioButton.Location = new System.Drawing.Point(894, 518);
            this.tensionRadioButton.Name = "tensionRadioButton";
            this.tensionRadioButton.Size = new System.Drawing.Size(63, 17);
            this.tensionRadioButton.TabIndex = 23;
            this.tensionRadioButton.TabStop = true;
            this.tensionRadioButton.Text = "Tension";
            this.tensionRadioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(13, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 667);
            this.panel1.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(869, 661);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 53);
            this.panel2.TabIndex = 35;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Example btn";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 767);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tensionRadioButton);
            this.Controls.Add(this.strainShearRadioButton);
            this.Controls.Add(this.strainYRadioButton);
            this.Controls.Add(this.strainXRadioButton);
            this.Controls.Add(this.displacementYRadiobutton);
            this.Controls.Add(this.displacementXRadioButton);
            this.Controls.Add(this.displacementVRadioButton);
            this.Controls.Add(this.pointsRadioButton);
            this.Controls.Add(this.imageRadioButton);
            this.Controls.Add(this.displayModeLabel);
            this.Controls.Add(this.showCropBoxCheckbox);
            this.Controls.Add(this.analyzeButton);
            this.Controls.Add(this.windowDeltaTextbox);
            this.Controls.Add(this.windowDeltaLabel);
            this.Controls.Add(this.subsetDeltaTextbox);
            this.Controls.Add(this.subsetDeltaLabel);
            this.Controls.Add(this.pointsYTextbox);
            this.Controls.Add(this.pointsYLabel);
            this.Controls.Add(this.pointsXTextbox);
            this.Controls.Add(this.pointsXLabel);
            this.Controls.Add(this.sizeNumberLabel);
            this.Controls.Add(this.sizeLabel);
            this.Controls.Add(this.openImagesButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
    }
}

