using DigitalImageCorrelation.Core.Requests;
using System;
using System.Collections.Generic;
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
            List<AnalyzeResult> results = new List<AnalyzeResult>();
            var orderedDictionary = _request.Arrays.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            AnalyzeResult analyzeResult;
            foreach (KeyValuePair<int, byte[,]> entry in orderedDictionary)
            {
                if (entry.Key == 0)
                {
                    analyzeResult = new AnalyzeResult
                    {
                        Index = entry.Key,
                        Points = _request.StartingPoints,
                        StartingPoints = _request.StartingPoints.ToList()

                    };
                }
                else
                {
                    var previous = results.Last();
                    analyzeResult = new AnalyzeResult
                    {
                        Index = entry.Key,
                        Points = previous.Points.AsParallel().AsOrdered().Select(point => FindPoint(_request.WindowDelta, _request.SubsetDelta, orderedDictionary[entry.Key - 1], entry.Value, point)).ToArray(),
                        StartingPoints = _request.StartingPoints.ToList()
                    };
                }
                results.Add(analyzeResult);
                backgroundWorker.ReportProgress(entry.Key, analyzeResult);
            }
            e.Result = results;
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
            var v0 = 0;
            var v1 = 0;
            for (var y = -subsetDelta; y <= subsetDelta; y++)
            {
                for (var x = -subsetDelta; x <= subsetDelta; x++)
                {
                    try
                    {
                        v0 = baseImage[point.Y + y, point.X + x];
                        v1 = nextImage[point.Y + y + v, point.X + x + u];
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
