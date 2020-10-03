using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Structures;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace DigitalImageCorrelation.Core
{
    public class ImageProcessor
    {
        private readonly BackgroundWorker backgroundWorker;
        private readonly AnalyzeRequest _request;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        internal ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            _request = request;
            backgroundWorker = bw;
        }

        public void Analyze(DoWorkEventArgs e)
        {
            _logger.Info("Analyze started");
            AnalyzeResult results = new AnalyzeResult()
            {
                StartingPoints = _request.StartingVertexes.ToArray()
            };
            var orderedDictionary = _request.Arrays.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            ImageResult analyzeResult;
            foreach (KeyValuePair<int, byte[]> entry in orderedDictionary)
            {
                if (entry.Key == 0)
                {
                    analyzeResult = new ImageResult
                    {
                        Index = entry.Key,
                        Vertexes = results.StartingPoints,
                        StartingVertexes = results.StartingPoints
                    };
                }
                else
                {
                    var previous = results.ImageResults.Last().Value;
                    var vertexes = previous.Vertexes.AsParallel().AsOrdered().Select(vertex => FindVertex(_request.WindowDelta, _request.SubsetDelta, orderedDictionary[entry.Key - 1], entry.Value, vertex)).ToArray();

                    analyzeResult = new ImageResult
                    {
                        Index = entry.Key,
                        Vertexes = vertexes,
                        StartingVertexes = _request.StartingVertexes.ToArray()
                    };
                }
                if (!results.ImageResults.TryAdd(entry.Key, analyzeResult))
                {
                    throw new Exception("Unable to add result to CocurentDictionary");
                }
                backgroundWorker.ReportProgress(entry.Key, analyzeResult);
                _logger.Info("Processing {0}/{1}", entry.Key + 1, orderedDictionary.Count);
            }
            _logger.Info("Calculate displacement");
            results.CalculateDisplacement();
            _logger.Info("Calculate strain");
            results.CalculateStrain(_request.PointsinX, _request.PointsinY);
            _logger.Info("Analyze complited, returning results");
            e.Result = results;
        }

        private Vertex FindVertex(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex vertex)
        {
            int dx = 0;
            int dy = 0;
            int diff = int.MaxValue;
            for (var v = -searchDelta; v <= searchDelta; v++)
            {
                for (var u = -searchDelta; u <= searchDelta; u++)
                {
                    var sum = FindSubsetDiff(subsetDelta, baseImage, nextImage, vertex, u, v);
                    if (sum < diff)
                    {
                        diff = sum;
                        dx = u;
                        dy = v;
                    }
                }
            }
            return new Vertex(vertex.X + dx, vertex.Y + dy);
        }

        private int FindSubsetDiff(int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex vertex, int u, int v)
        {
            var sum = 0;
            for (var y = -subsetDelta; y <= subsetDelta; y++)
            {
                for (var x = -subsetDelta; x <= subsetDelta; x++)
                {
                    try
                    {
                        int v0 = baseImage[(vertex.X + x) * _request.BitmpHeight + vertex.Y + y];
                        int v1 = nextImage[(vertex.X + x + u) * _request.BitmpHeight + vertex.Y + y + v];
                        sum += (v0 - v1) * (v0 - v1);
                    }
                    catch (Exception ex)
                    {
                        _logger.Warn(ex);
                        return sum;
                    }
                }
            }
            return sum;
        }
    }
}
