using System;
using System.Windows.Forms;

namespace DigitalImageCorrelation.Desktop
{
    public class BasePresenter
    {

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
