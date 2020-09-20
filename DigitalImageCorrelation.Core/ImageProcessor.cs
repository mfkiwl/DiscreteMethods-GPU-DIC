using DigitalImageCorrelation.Core.Requests;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace DigitalImageCorrelation.Core
{
    public class ImageProcessor
    {
        private readonly BackgroundWorker backgroundWorker;
        private AnalyzeRequest _request;
        internal ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            _request = request;
            backgroundWorker = bw;
        }

        public void Analyze(DoWorkEventArgs e)
        {
            var containers = _request.imageContainers.Values.OrderBy(x => x.Index).ToArray();
            var previousContainer = containers.First();
            previousContainer.analyzeResult = new AnalyzeResult();
            previousContainer.analyzeResult.Points = previousContainer.pos.CalculateStartingPoints(_request.PointsinX, _request.PointsinY);
            foreach (var (item, index) in containers.WithIndex())
            {
                if (index == 0)
                {
                    continue;
                }
                item.analyzeResult = new AnalyzeResult
                {
                    Points = previousContainer.analyzeResult.Points.AsParallel().Select(point => FindPoint(_request.WindowDelta, _request.SubsetDelta, previousContainer.GrayScaleImage, item.GrayScaleImage, point)).ToArray()
                };
                previousContainer = item;
                backgroundWorker.ReportProgress(index + 1);
            }
            e.Result = containers.ToDictionary(x => new { x.Index, x.analyzeResult });
        }
        private Point FindPoint(int searchDelta, int subsetDelta, byte[,] baseImage, byte[,] nextImage, Point point)
        {
            int dx = 0;
            int dy = 0;
            int diff = int.MaxValue;
            for (var v = -searchDelta; v <= searchDelta; v++)
            {
                for (var u = -searchDelta; u <= searchDelta; u++)
                {
                    var sum = FindSubsetDiff(subsetDelta, baseImage, nextImage, point, u, v);
                    if (sum < diff)
                    {
                        diff = sum;
                        dx = u;
                        dy = v;
                    }
                }
            }
            return new Point(point.X + dx, point.Y + dy);
        }

        private int FindSubsetDiff(int subsetDelta, byte[,] baseImage, byte[,] nextImage, Point point, int u, int v)
        {
            var sum = 0;
            for (var y = -subsetDelta; y <= subsetDelta; y++)
            {
                for (var x = -subsetDelta; x <= subsetDelta; x++)
                {
                    try
                    {
                        var v0 = baseImage[point.X + x, point.Y + y];
                        var v1 = nextImage[point.X + x + u, point.Y + y + v];
                        sum += (v0 - v1) * (v0 - v1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return sum;
                    }
                }
            }
            return sum;
        }

    }
}
