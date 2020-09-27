using DigitalImageCorrelation.Core.Requests;
using System;
using System.ComponentModel;

namespace DigitalImageCorrelation.Core
{
    public class Worker
    {
        public delegate void ProgressUpdate(object sender, ProgressChangedEventArgs e);
        public event ProgressUpdate OnProgressUpdate;

        public delegate void TaskDone(RunWorkerCompletedEventArgs e);
        public event TaskDone OnTaskDone;
        private readonly BackgroundWorker BackgroundWorker;
        public Worker()
        {
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += DoWork;
            BackgroundWorker.ProgressChanged += ProgressChanged;
            BackgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;
        }

        public void RunWorker(AnalyzeRequest request)
        {
            BackgroundWorker.RunWorkerAsync(request);
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var request = e.Argument as AnalyzeRequest;
                var bw = sender as BackgroundWorker;
                ImageProcessor processor = new ImageProcessor(bw, request);
                processor.Analyze(e);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressUpdate(sender, e);
        }

        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnTaskDone(e);
        }
    }
}
