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
            this.displayModeLabel = new System.Windows.Forms.Label();
            this.FillPanel = new System.Windows.Forms.Panel();
            this.ImagePanel = new System.Windows.Forms.Panel();
            this.MainPictureBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.ScalePicturebox = new System.Windows.Forms.PictureBox();
            this.MaxValLabel = new System.Windows.Forms.Label();
            this.MinValLabel = new System.Windows.Forms.Label();
            this.YPosLabel = new System.Windows.Forms.Label();
            this.XPosLabel = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.OpenImagesPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.MinImageValLabel = new System.Windows.Forms.Label();
            this.MaxImageValLabel = new System.Windows.Forms.Label();
            this.ValueTypeLabel = new System.Windows.Forms.Label();
            this.CurrentImageLabel = new System.Windows.Forms.Label();
            this.ImageNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.imageListView = new System.Windows.Forms.ListView();
            this.indexColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.NameColumnHeader = new System.Windows.Forms.ColumnHeader();
            this.GpuRadioBtn = new System.Windows.Forms.RadioButton();
            this.CpuRadioBtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DownPanel = new System.Windows.Forms.Panel();
            this.MessageRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.zoomTextbox = new System.Windows.Forms.TextBox();
            this.ResetZoomButton = new System.Windows.Forms.Button();
            this.showCropBoxCheckbox = new System.Windows.Forms.CheckBox();
            this.zoomUpButton = new System.Windows.Forms.Button();
            this.zoomLabel = new System.Windows.Forms.Label();
            this.ZoomDownButton = new System.Windows.Forms.Button();
            this.loadImagesFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.AnalyzeDataPanel = new System.Windows.Forms.Panel();
            this.DisplayModePanel = new System.Windows.Forms.Panel();
            this.RadioButtonsPanel = new System.Windows.Forms.TableLayoutPanel();
            this.stressEqRadioButton = new System.Windows.Forms.RadioButton();
            this.stressYRadioButton = new System.Windows.Forms.RadioButton();
            this.stressXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainYRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementYRadiobutton = new System.Windows.Forms.RadioButton();
            this.imageRadioButton = new System.Windows.Forms.RadioButton();
            this.pointsRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementVRadioButton = new System.Windows.Forms.RadioButton();
            this.displacementXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainXRadioButton = new System.Windows.Forms.RadioButton();
            this.strainShearRadioButton = new System.Windows.Forms.RadioButton();
            this.LoadImagesBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.PictureboxToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ZoomPanel = new System.Windows.Forms.Panel();
            this.FillPanel.SuspendLayout();
            this.ImagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicturebox)).BeginInit();
            this.ScalePicturebox.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.OpenImagesPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.DownPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.AnalyzeDataPanel.SuspendLayout();
            this.DisplayModePanel.SuspendLayout();
            this.RadioButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // openImagesButton
            // 
            this.openImagesButton.Location = new System.Drawing.Point(9, 271);
            this.openImagesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.openImagesButton.Name = "openImagesButton";
            this.openImagesButton.Size = new System.Drawing.Size(157, 39);
            this.openImagesButton.TabIndex = 1;
            this.openImagesButton.Text = "Open images";
            this.openImagesButton.UseVisualStyleBackColor = true;
            this.openImagesButton.Click += new System.EventHandler(this.OpenImagesButton_Click);
            // 
            // sizeNumberLabel
            // 
            this.sizeNumberLabel.AutoSize = true;
            this.sizeNumberLabel.Location = new System.Drawing.Point(5, 46);
            this.sizeNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sizeNumberLabel.Name = "sizeNumberLabel";
            this.sizeNumberLabel.Size = new System.Drawing.Size(41, 15);
            this.sizeNumberLabel.TabIndex = 3;
            this.sizeNumberLabel.Text = "0x0 px";
            // 
            // pointsXLabel
            // 
            this.pointsXLabel.AutoSize = true;
            this.pointsXLabel.Location = new System.Drawing.Point(9, 10);
            this.pointsXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pointsXLabel.Name = "pointsXLabel";
            this.pointsXLabel.Size = new System.Drawing.Size(63, 15);
            this.pointsXLabel.TabIndex = 4;
            this.pointsXLabel.Text = "Points in X";
            // 
            // pointsXTextbox
            // 
            this.pointsXTextbox.Location = new System.Drawing.Point(91, 6);
            this.pointsXTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pointsXTextbox.Name = "pointsXTextbox";
            this.pointsXTextbox.Size = new System.Drawing.Size(79, 23);
            this.pointsXTextbox.TabIndex = 5;
            this.pointsXTextbox.Text = "40";
            this.pointsXTextbox.Leave += new System.EventHandler(this.ValidateTextAndRefreshImage);
            // 
            // pointsYTextbox
            // 
            this.pointsYTextbox.Location = new System.Drawing.Point(91, 35);
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
            this.pointsYLabel.Location = new System.Drawing.Point(9, 38);
            this.pointsYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.pointsYLabel.Name = "pointsYLabel";
            this.pointsYLabel.Size = new System.Drawing.Size(63, 15);
            this.pointsYLabel.TabIndex = 6;
            this.pointsYLabel.Text = "Points in Y";
            // 
            // subsetDeltaTextbox
            // 
            this.subsetDeltaTextbox.Location = new System.Drawing.Point(91, 64);
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
            this.subsetDeltaLabel.Location = new System.Drawing.Point(10, 67);
            this.subsetDeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.subsetDeltaLabel.Name = "subsetDeltaLabel";
            this.subsetDeltaLabel.Size = new System.Drawing.Size(71, 15);
            this.subsetDeltaLabel.TabIndex = 8;
            this.subsetDeltaLabel.Text = "Subset delta";
            // 
            // windowDeltaTextbox
            // 
            this.windowDeltaTextbox.Location = new System.Drawing.Point(91, 93);
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
            this.windowDeltaLabel.Location = new System.Drawing.Point(10, 93);
            this.windowDeltaLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.windowDeltaLabel.Name = "windowDeltaLabel";
            this.windowDeltaLabel.Size = new System.Drawing.Size(80, 15);
            this.windowDeltaLabel.TabIndex = 10;
            this.windowDeltaLabel.Text = "Window delta";
            // 
            // analyzeButton
            // 
            this.analyzeButton.Enabled = false;
            this.analyzeButton.Location = new System.Drawing.Point(7, 122);
            this.analyzeButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.analyzeButton.Name = "analyzeButton";
            this.analyzeButton.Size = new System.Drawing.Size(163, 34);
            this.analyzeButton.TabIndex = 12;
            this.analyzeButton.Text = "Analyze";
            this.analyzeButton.UseVisualStyleBackColor = true;
            this.analyzeButton.Click += new System.EventHandler(this.AnalyzeButton_Click);
            // 
            // displayModeLabel
            // 
            this.displayModeLabel.AutoSize = true;
            this.displayModeLabel.Location = new System.Drawing.Point(5, 2);
            this.displayModeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.displayModeLabel.Name = "displayModeLabel";
            this.displayModeLabel.Size = new System.Drawing.Size(79, 15);
            this.displayModeLabel.TabIndex = 14;
            this.displayModeLabel.Text = "DisplayMode:";
            // 
            // FillPanel
            // 
            this.FillPanel.AutoScroll = true;
            this.FillPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FillPanel.Controls.Add(this.ImagePanel);
            this.FillPanel.Controls.Add(this.progressBar);
            this.FillPanel.Controls.Add(this.ScalePicturebox);
            this.FillPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FillPanel.Location = new System.Drawing.Point(174, 35);
            this.FillPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.FillPanel.Name = "FillPanel";
            this.FillPanel.Size = new System.Drawing.Size(849, 814);
            this.FillPanel.TabIndex = 34;
            // 
            // ImagePanel
            // 
            this.ImagePanel.AutoScroll = true;
            this.ImagePanel.Controls.Add(this.MainPictureBox);
            this.ImagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePanel.Location = new System.Drawing.Point(30, 0);
            this.ImagePanel.Name = "ImagePanel";
            this.ImagePanel.Size = new System.Drawing.Size(819, 804);
            this.ImagePanel.TabIndex = 29;
            // 
            // MainPictureBox
            // 
            this.MainPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MainPictureBox.Location = new System.Drawing.Point(0, 1);
            this.MainPictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MainPictureBox.Name = "MainPictureBox";
            this.MainPictureBox.Size = new System.Drawing.Size(100, 100);
            this.MainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.MainPictureBox.TabIndex = 0;
            this.MainPictureBox.TabStop = false;
            this.MainPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseDown);
            this.MainPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseMove);
            this.MainPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainPictureBox_MouseUp);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(30, 804);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(819, 10);
            this.progressBar.TabIndex = 28;
            // 
            // ScalePicturebox
            // 
            this.ScalePicturebox.Controls.Add(this.MaxValLabel);
            this.ScalePicturebox.Controls.Add(this.MinValLabel);
            this.ScalePicturebox.Dock = System.Windows.Forms.DockStyle.Left;
            this.ScalePicturebox.Location = new System.Drawing.Point(0, 0);
            this.ScalePicturebox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ScalePicturebox.Name = "ScalePicturebox";
            this.ScalePicturebox.Size = new System.Drawing.Size(30, 814);
            this.ScalePicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ScalePicturebox.TabIndex = 11;
            this.ScalePicturebox.TabStop = false;
            // 
            // MaxValLabel
            // 
            this.MaxValLabel.AutoSize = true;
            this.MaxValLabel.BackColor = System.Drawing.Color.Transparent;
            this.MaxValLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MaxValLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaxValLabel.Location = new System.Drawing.Point(0, 0);
            this.MaxValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxValLabel.Name = "MaxValLabel";
            this.MaxValLabel.Size = new System.Drawing.Size(13, 15);
            this.MaxValLabel.TabIndex = 100;
            this.MaxValLabel.Text = "0";
            // 
            // MinValLabel
            // 
            this.MinValLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MinValLabel.AutoSize = true;
            this.MinValLabel.BackColor = System.Drawing.Color.Transparent;
            this.MinValLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MinValLabel.Location = new System.Drawing.Point(0, 799);
            this.MinValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinValLabel.Name = "MinValLabel";
            this.MinValLabel.Size = new System.Drawing.Size(13, 15);
            this.MinValLabel.TabIndex = 101;
            this.MinValLabel.Text = "0";
            // 
            // YPosLabel
            // 
            this.YPosLabel.AutoSize = true;
            this.YPosLabel.Location = new System.Drawing.Point(82, 121);
            this.YPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YPosLabel.Name = "YPosLabel";
            this.YPosLabel.Size = new System.Drawing.Size(26, 15);
            this.YPosLabel.TabIndex = 14;
            this.YPosLabel.Text = "Y: 0";
            // 
            // XPosLabel
            // 
            this.XPosLabel.AutoSize = true;
            this.XPosLabel.Location = new System.Drawing.Point(5, 121);
            this.XPosLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XPosLabel.Name = "XPosLabel";
            this.XPosLabel.Size = new System.Drawing.Size(26, 15);
            this.XPosLabel.TabIndex = 13;
            this.XPosLabel.Text = "X: 0";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Location = new System.Drawing.Point(5, 96);
            this.ValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(47, 15);
            this.ValueLabel.TabIndex = 12;
            this.ValueLabel.Text = "Value: 0";
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.Control;
            this.LeftPanel.Controls.Add(this.OpenImagesPanel);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(174, 849);
            this.LeftPanel.TabIndex = 2;
            // 
            // OpenImagesPanel
            // 
            this.OpenImagesPanel.Controls.Add(this.panel1);
            this.OpenImagesPanel.Controls.Add(this.label2);
            this.OpenImagesPanel.Controls.Add(this.imageListView);
            this.OpenImagesPanel.Controls.Add(this.openImagesButton);
            this.OpenImagesPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.OpenImagesPanel.Location = new System.Drawing.Point(0, 0);
            this.OpenImagesPanel.Name = "OpenImagesPanel";
            this.OpenImagesPanel.Size = new System.Drawing.Size(174, 831);
            this.OpenImagesPanel.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.MinImageValLabel);
            this.panel1.Controls.Add(this.MaxImageValLabel);
            this.panel1.Controls.Add(this.ValueTypeLabel);
            this.panel1.Controls.Add(this.CurrentImageLabel);
            this.panel1.Controls.Add(this.ValueLabel);
            this.panel1.Controls.Add(this.ImageNameLabel);
            this.panel1.Controls.Add(this.XPosLabel);
            this.panel1.Controls.Add(this.sizeNumberLabel);
            this.panel1.Controls.Add(this.YPosLabel);
            this.panel1.Location = new System.Drawing.Point(8, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(158, 216);
            this.panel1.TabIndex = 30;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 189);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 19);
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Show local min/max";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // MinImageValLabel
            // 
            this.MinImageValLabel.AutoSize = true;
            this.MinImageValLabel.Location = new System.Drawing.Point(5, 171);
            this.MinImageValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinImageValLabel.Name = "MinImageValLabel";
            this.MinImageValLabel.Size = new System.Drawing.Size(71, 15);
            this.MinImageValLabel.TabIndex = 32;
            this.MinImageValLabel.Text = "Local min: 0";
            // 
            // MaxImageValLabel
            // 
            this.MaxImageValLabel.AutoSize = true;
            this.MaxImageValLabel.Location = new System.Drawing.Point(5, 146);
            this.MaxImageValLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MaxImageValLabel.Name = "MaxImageValLabel";
            this.MaxImageValLabel.Size = new System.Drawing.Size(73, 15);
            this.MaxImageValLabel.TabIndex = 31;
            this.MaxImageValLabel.Text = "Local max: 0";
            // 
            // ValueTypeLabel
            // 
            this.ValueTypeLabel.AutoSize = true;
            this.ValueTypeLabel.Location = new System.Drawing.Point(5, 71);
            this.ValueTypeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ValueTypeLabel.Name = "ValueTypeLabel";
            this.ValueTypeLabel.Size = new System.Drawing.Size(59, 15);
            this.ValueTypeLabel.TabIndex = 30;
            this.ValueTypeLabel.Text = "ValueType";
            // 
            // CurrentImageLabel
            // 
            this.CurrentImageLabel.AutoSize = true;
            this.CurrentImageLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CurrentImageLabel.Location = new System.Drawing.Point(29, 0);
            this.CurrentImageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentImageLabel.Name = "CurrentImageLabel";
            this.CurrentImageLabel.Size = new System.Drawing.Size(90, 15);
            this.CurrentImageLabel.TabIndex = 29;
            this.CurrentImageLabel.Text = "Current image:";
            // 
            // ImageNameLabel
            // 
            this.ImageNameLabel.AutoSize = true;
            this.ImageNameLabel.Location = new System.Drawing.Point(3, 25);
            this.ImageNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ImageNameLabel.Name = "ImageNameLabel";
            this.ImageNameLabel.Size = new System.Drawing.Size(73, 15);
            this.ImageNameLabel.TabIndex = 26;
            this.ImageNameLabel.Text = "Image name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 28;
            this.label2.Text = "All loaded images:";
            // 
            // imageListView
            // 
            this.imageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexColumnHeader,
            this.NameColumnHeader});
            this.imageListView.FullRowSelect = true;
            this.imageListView.GridLines = true;
            this.imageListView.HideSelection = false;
            this.imageListView.Location = new System.Drawing.Point(0, 27);
            this.imageListView.MultiSelect = false;
            this.imageListView.Name = "imageListView";
            this.imageListView.Size = new System.Drawing.Size(174, 238);
            this.imageListView.TabIndex = 27;
            this.imageListView.UseCompatibleStateImageBehavior = false;
            this.imageListView.View = System.Windows.Forms.View.Details;
            this.imageListView.SelectedIndexChanged += new System.EventHandler(this.imageListView_SelectedIndexChanged);
            // 
            // indexColumnHeader
            // 
            this.indexColumnHeader.Name = "indexColumnHeader";
            this.indexColumnHeader.Text = "Nr.";
            this.indexColumnHeader.Width = 28;
            // 
            // NameColumnHeader
            // 
            this.NameColumnHeader.Name = "NameColumnHeader";
            this.NameColumnHeader.Text = "Image name:";
            this.NameColumnHeader.Width = 250;
            // 
            // GpuRadioBtn
            // 
            this.GpuRadioBtn.AutoSize = true;
            this.GpuRadioBtn.Checked = true;
            this.GpuRadioBtn.Location = new System.Drawing.Point(10, 219);
            this.GpuRadioBtn.Name = "GpuRadioBtn";
            this.GpuRadioBtn.Size = new System.Drawing.Size(82, 19);
            this.GpuRadioBtn.TabIndex = 27;
            this.GpuRadioBtn.TabStop = true;
            this.GpuRadioBtn.Tag = "1";
            this.GpuRadioBtn.Text = "Gpu CUDA";
            this.GpuRadioBtn.UseVisualStyleBackColor = true;
            // 
            // CpuRadioBtn
            // 
            this.CpuRadioBtn.AutoSize = true;
            this.CpuRadioBtn.Location = new System.Drawing.Point(10, 194);
            this.CpuRadioBtn.Name = "CpuRadioBtn";
            this.CpuRadioBtn.Size = new System.Drawing.Size(47, 19);
            this.CpuRadioBtn.TabIndex = 27;
            this.CpuRadioBtn.Tag = "0";
            this.CpuRadioBtn.Text = "Cpu";
            this.CpuRadioBtn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 173);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 15);
            this.label1.TabIndex = 26;
            this.label1.Text = "Choose calculation source:";
            // 
            // DownPanel
            // 
            this.DownPanel.BackColor = System.Drawing.SystemColors.Control;
            this.DownPanel.Controls.Add(this.MessageRichTextBox);
            this.DownPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DownPanel.Location = new System.Drawing.Point(0, 849);
            this.DownPanel.Name = "DownPanel";
            this.DownPanel.Size = new System.Drawing.Size(1206, 22);
            this.DownPanel.TabIndex = 1;
            // 
            // MessageRichTextBox
            // 
            this.MessageRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.MessageRichTextBox.Margin = new System.Windows.Forms.Padding(33, 3, 3, 3);
            this.MessageRichTextBox.Name = "MessageRichTextBox";
            this.MessageRichTextBox.ReadOnly = true;
            this.MessageRichTextBox.Size = new System.Drawing.Size(1206, 22);
            this.MessageRichTextBox.TabIndex = 0;
            this.MessageRichTextBox.Text = "";
            this.MessageRichTextBox.DoubleClick += new System.EventHandler(this.MessageRichTextBox_DoubleClick);
            // 
            // TopPanel
            // 
            this.TopPanel.AutoScroll = true;
            this.TopPanel.Controls.Add(this.zoomTextbox);
            this.TopPanel.Controls.Add(this.ResetZoomButton);
            this.TopPanel.Controls.Add(this.showCropBoxCheckbox);
            this.TopPanel.Controls.Add(this.zoomUpButton);
            this.TopPanel.Controls.Add(this.zoomLabel);
            this.TopPanel.Controls.Add(this.ZoomDownButton);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(174, 0);
            this.TopPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1032, 35);
            this.TopPanel.TabIndex = 35;
            // 
            // zoomTextbox
            // 
            this.zoomTextbox.Enabled = false;
            this.zoomTextbox.Location = new System.Drawing.Point(237, 6);
            this.zoomTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.zoomTextbox.Name = "zoomTextbox";
            this.zoomTextbox.Size = new System.Drawing.Size(41, 23);
            this.zoomTextbox.TabIndex = 34;
            // 
            // ResetZoomButton
            // 
            this.ResetZoomButton.Location = new System.Drawing.Point(141, 3);
            this.ResetZoomButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ResetZoomButton.Name = "ResetZoomButton";
            this.ResetZoomButton.Size = new System.Drawing.Size(88, 27);
            this.ResetZoomButton.TabIndex = 33;
            this.ResetZoomButton.Text = "Reset zoom";
            this.ResetZoomButton.UseVisualStyleBackColor = true;
            this.ResetZoomButton.Click += new System.EventHandler(this.InitializeImageScale);
            // 
            // showCropBoxCheckbox
            // 
            this.showCropBoxCheckbox.AutoSize = true;
            this.showCropBoxCheckbox.Checked = true;
            this.showCropBoxCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showCropBoxCheckbox.Location = new System.Drawing.Point(286, 8);
            this.showCropBoxCheckbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.showCropBoxCheckbox.Name = "showCropBoxCheckbox";
            this.showCropBoxCheckbox.Size = new System.Drawing.Size(105, 19);
            this.showCropBoxCheckbox.TabIndex = 32;
            this.showCropBoxCheckbox.Text = "Show crop box";
            this.showCropBoxCheckbox.UseVisualStyleBackColor = true;
            this.showCropBoxCheckbox.CheckedChanged += new System.EventHandler(this.ShowCropBoxCheckbox_CheckedChanged);
            // 
            // zoomUpButton
            // 
            this.zoomUpButton.Location = new System.Drawing.Point(99, 3);
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
            this.zoomLabel.Location = new System.Drawing.Point(7, 9);
            this.zoomLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.zoomLabel.Name = "zoomLabel";
            this.zoomLabel.Size = new System.Drawing.Size(42, 15);
            this.zoomLabel.TabIndex = 25;
            this.zoomLabel.Text = "Zoom:";
            // 
            // ZoomDownButton
            // 
            this.ZoomDownButton.Location = new System.Drawing.Point(57, 3);
            this.ZoomDownButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ZoomDownButton.Name = "ZoomDownButton";
            this.ZoomDownButton.Size = new System.Drawing.Size(34, 27);
            this.ZoomDownButton.TabIndex = 30;
            this.ZoomDownButton.Text = "-";
            this.ZoomDownButton.UseVisualStyleBackColor = true;
            this.ZoomDownButton.Click += new System.EventHandler(this.ZoomDownButton_Click);
            // 
            // loadImagesFileDialog
            // 
            this.loadImagesFileDialog.Filter = "*.BMP;*.JPG;*.GIF|";
            this.loadImagesFileDialog.Multiselect = true;
            this.loadImagesFileDialog.Title = "Load Images to analyze";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.AnalyzeDataPanel);
            this.RightPanel.Controls.Add(this.DisplayModePanel);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(1023, 35);
            this.RightPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(183, 814);
            this.RightPanel.TabIndex = 36;
            // 
            // AnalyzeDataPanel
            // 
            this.AnalyzeDataPanel.Controls.Add(this.pointsXLabel);
            this.AnalyzeDataPanel.Controls.Add(this.GpuRadioBtn);
            this.AnalyzeDataPanel.Controls.Add(this.pointsXTextbox);
            this.AnalyzeDataPanel.Controls.Add(this.CpuRadioBtn);
            this.AnalyzeDataPanel.Controls.Add(this.windowDeltaTextbox);
            this.AnalyzeDataPanel.Controls.Add(this.label1);
            this.AnalyzeDataPanel.Controls.Add(this.subsetDeltaLabel);
            this.AnalyzeDataPanel.Controls.Add(this.analyzeButton);
            this.AnalyzeDataPanel.Controls.Add(this.subsetDeltaTextbox);
            this.AnalyzeDataPanel.Controls.Add(this.pointsYLabel);
            this.AnalyzeDataPanel.Controls.Add(this.pointsYTextbox);
            this.AnalyzeDataPanel.Controls.Add(this.windowDeltaLabel);
            this.AnalyzeDataPanel.Location = new System.Drawing.Point(0, 0);
            this.AnalyzeDataPanel.Name = "AnalyzeDataPanel";
            this.AnalyzeDataPanel.Size = new System.Drawing.Size(182, 249);
            this.AnalyzeDataPanel.TabIndex = 40;
            // 
            // DisplayModePanel
            // 
            this.DisplayModePanel.Controls.Add(this.displayModeLabel);
            this.DisplayModePanel.Controls.Add(this.RadioButtonsPanel);
            this.DisplayModePanel.Location = new System.Drawing.Point(0, 255);
            this.DisplayModePanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.DisplayModePanel.Name = "DisplayModePanel";
            this.DisplayModePanel.Size = new System.Drawing.Size(182, 307);
            this.DisplayModePanel.TabIndex = 15;
            // 
            // RadioButtonsPanel
            // 
            this.RadioButtonsPanel.AutoSize = true;
            this.RadioButtonsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RadioButtonsPanel.ColumnCount = 1;
            this.RadioButtonsPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.RadioButtonsPanel.Controls.Add(this.stressEqRadioButton, 0, 10);
            this.RadioButtonsPanel.Controls.Add(this.stressYRadioButton, 0, 9);
            this.RadioButtonsPanel.Controls.Add(this.stressXRadioButton, 0, 8);
            this.RadioButtonsPanel.Controls.Add(this.strainYRadioButton, 0, 6);
            this.RadioButtonsPanel.Controls.Add(this.displacementYRadiobutton, 0, 4);
            this.RadioButtonsPanel.Controls.Add(this.imageRadioButton, 0, 0);
            this.RadioButtonsPanel.Controls.Add(this.pointsRadioButton, 0, 1);
            this.RadioButtonsPanel.Controls.Add(this.displacementVRadioButton, 0, 2);
            this.RadioButtonsPanel.Controls.Add(this.displacementXRadioButton, 0, 3);
            this.RadioButtonsPanel.Controls.Add(this.strainXRadioButton, 0, 5);
            this.RadioButtonsPanel.Controls.Add(this.strainShearRadioButton, 0, 7);
            this.RadioButtonsPanel.Location = new System.Drawing.Point(5, 20);
            this.RadioButtonsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.RadioButtonsPanel.Name = "RadioButtonsPanel";
            this.RadioButtonsPanel.RowCount = 11;
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.RadioButtonsPanel.Size = new System.Drawing.Size(146, 275);
            this.RadioButtonsPanel.TabIndex = 37;
            // 
            // stressEqRadioButton
            // 
            this.stressEqRadioButton.AutoSize = true;
            this.stressEqRadioButton.Location = new System.Drawing.Point(4, 253);
            this.stressEqRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stressEqRadioButton.Name = "stressEqRadioButton";
            this.stressEqRadioButton.Size = new System.Drawing.Size(79, 19);
            this.stressEqRadioButton.TabIndex = 27;
            this.stressEqRadioButton.Tag = "10";
            this.stressEqRadioButton.Text = "Stress (eq)";
            this.stressEqRadioButton.UseVisualStyleBackColor = true;
            this.stressEqRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // stressYRadioButton
            // 
            this.stressYRadioButton.AutoSize = true;
            this.stressYRadioButton.Location = new System.Drawing.Point(4, 228);
            this.stressYRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stressYRadioButton.Name = "stressYRadioButton";
            this.stressYRadioButton.Size = new System.Drawing.Size(70, 19);
            this.stressYRadioButton.TabIndex = 26;
            this.stressYRadioButton.Tag = "9";
            this.stressYRadioButton.Text = "Stress(Y)";
            this.stressYRadioButton.UseVisualStyleBackColor = true;
            this.stressYRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
            // 
            // stressXRadioButton
            // 
            this.stressXRadioButton.AutoSize = true;
            this.stressXRadioButton.Location = new System.Drawing.Point(4, 203);
            this.stressXRadioButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.stressXRadioButton.Name = "stressXRadioButton";
            this.stressXRadioButton.Size = new System.Drawing.Size(73, 19);
            this.stressXRadioButton.TabIndex = 25;
            this.stressXRadioButton.Tag = "8";
            this.stressXRadioButton.Text = "Stress (X)";
            this.stressXRadioButton.UseVisualStyleBackColor = true;
            this.stressXRadioButton.Click += new System.EventHandler(this.DrawCurrentImage);
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
            // LoadImagesBackgroundWorker
            // 
            this.LoadImagesBackgroundWorker.WorkerReportsProgress = true;
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
            // ZoomPanel
            // 
            this.ZoomPanel.Location = new System.Drawing.Point(0, 308);
            this.ZoomPanel.Name = "ZoomPanel";
            this.ZoomPanel.Size = new System.Drawing.Size(254, 66);
            this.ZoomPanel.TabIndex = 41;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 871);
            this.Controls.Add(this.FillPanel);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.DownPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Digital Image Correlation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FillPanel.ResumeLayout(false);
            this.ImagePanel.ResumeLayout(false);
            this.ImagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScalePicturebox)).EndInit();
            this.ScalePicturebox.ResumeLayout(false);
            this.ScalePicturebox.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.OpenImagesPanel.ResumeLayout(false);
            this.OpenImagesPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.DownPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.AnalyzeDataPanel.ResumeLayout(false);
            this.AnalyzeDataPanel.PerformLayout();
            this.DisplayModePanel.ResumeLayout(false);
            this.DisplayModePanel.PerformLayout();
            this.RadioButtonsPanel.ResumeLayout(false);
            this.RadioButtonsPanel.PerformLayout();
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
        private System.Windows.Forms.Label displayModeLabel;
        private System.Windows.Forms.Panel FillPanel;
        private System.Windows.Forms.PictureBox MainPictureBox;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.OpenFileDialog loadImagesFileDialog;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.Label ImageNameLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker LoadImagesBackgroundWorker;
        private System.Windows.Forms.Button zoomUpButton;
        private System.Windows.Forms.Button ZoomDownButton;
        private System.Windows.Forms.TableLayoutPanel RadioButtonsPanel;
        private System.Windows.Forms.RadioButton stressXRadioButton;
        private System.Windows.Forms.RadioButton strainYRadioButton;
        private System.Windows.Forms.RadioButton displacementYRadiobutton;
        private System.Windows.Forms.RadioButton imageRadioButton;
        private System.Windows.Forms.RadioButton pointsRadioButton;
        private System.Windows.Forms.RadioButton displacementVRadioButton;
        private System.Windows.Forms.RadioButton displacementXRadioButton;
        private System.Windows.Forms.RadioButton strainXRadioButton;
        private System.Windows.Forms.RadioButton strainShearRadioButton;
        private System.Windows.Forms.Label YPosLabel;
        private System.Windows.Forms.Label XPosLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.PictureBox ScalePicturebox;
        private System.Windows.Forms.Label MaxValLabel;
        private System.Windows.Forms.Panel DisplayModePanel;
        private System.Windows.Forms.ToolTip PictureboxToolTip;
        private System.Windows.Forms.Panel AnalyzeDataPanel;
        private System.Windows.Forms.Panel OpenImagesPanel;
        private System.Windows.Forms.RadioButton GpuRadioBtn;
        private System.Windows.Forms.RadioButton CpuRadioBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel DownPanel;
        private System.Windows.Forms.Panel ZoomPanel;
        private System.Windows.Forms.TextBox zoomTextbox;
        private System.Windows.Forms.Button ResetZoomButton;
        private System.Windows.Forms.CheckBox showCropBoxCheckbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView imageListView;
        private System.Windows.Forms.ColumnHeader indexColumnHeader;
        private System.Windows.Forms.ColumnHeader NameColumnHeader;
        private System.Windows.Forms.Panel ImagePanel;
        private System.Windows.Forms.RichTextBox MessageRichTextBox;
        private System.Windows.Forms.RadioButton stressEqRadioButton;
        private System.Windows.Forms.RadioButton stressYRadioButton;
        private System.Windows.Forms.Label MinValLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label MinImageValLabel;
        private System.Windows.Forms.Label MaxImageValLabel;
        private System.Windows.Forms.Label ValueTypeLabel;
        private System.Windows.Forms.Label CurrentImageLabel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

