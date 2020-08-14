﻿using DigitalImageCorrelation.Core.Requests;
using System.ComponentModel;

namespace DigitalImageCorrelation.Core
{
    public class WorkerProcessor
    {
        public delegate void ProgressUpdate(int value);
        public event ProgressUpdate OnProgressUpdate;

        public delegate void TaskDone();
        public event TaskDone OnTaskDone;
        private readonly BackgroundWorker BackgroundWorker;
        public WorkerProcessor()
        {
            BackgroundWorker = new BackgroundWorker();
            BackgroundWorker.DoWork += DoWork;
            BackgroundWorker.ProgressChanged += ProgressChanged;
            BackgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            BackgroundWorker.WorkerReportsProgress = true;
            BackgroundWorker.WorkerSupportsCancellation = true;
        }

        public void RunWorker(AnalyseRequest request)
        {
            BackgroundWorker.RunWorkerAsync(request);
        }

        public void DoWork(object sender, DoWorkEventArgs e)
        {
            var request = e.Argument as AnalyseRequest;
            var bw = sender as BackgroundWorker;
            ImageProcessor processor = new ImageProcessor(bw, request);
            processor.Analyze();
        }
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            OnProgressUpdate(e.ProgressPercentage);
        }

        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            OnTaskDone();
        }
    }
}
