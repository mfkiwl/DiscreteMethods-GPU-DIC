using System;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void openImagesButton_Click(object sender, EventArgs e)
        {

            if (loadImagesFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String file in loadImagesFileDialog.FileNames)
                {

                }
            }
        }
    }
}
