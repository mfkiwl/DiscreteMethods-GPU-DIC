using DigitalImageCorrelation.Core.Requests;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace DigitalImageCorrelation.Core
{
    public class ImageProcessor
    {
        private readonly BackgroundWorker backgroundWorker;
        private List<ImageContainer> containers;
        internal ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            containers = request.Containers;
            backgroundWorker = bw;
        }

        public void Analyze()
        {
            foreach (var (item, index) in containers.WithIndex())
            {
                Thread.Sleep(1500);
                backgroundWorker.ReportProgress(index);
            }
        }
    }
}
