using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
                        Vertexes = _request.StartingVertexes,
                        StartingPoints = _request.StartingVertexes.ToList()

                    };
                }
                else
                {
                    var previous = results.Last();
                    analyzeResult = new AnalyzeResult
                    {
                        Index = entry.Key,
                        Vertexes = previous.Vertexes.AsParallel().AsOrdered().Select(vertex => FindVertex(_request.WindowDelta, _request.SubsetDelta, orderedDictionary[entry.Key - 1], entry.Value, vertex)).ToArray(),
                        StartingPoints = _request.StartingVertexes.ToList()
                    };
                }
                results.Add(analyzeResult);
                backgroundWorker.ReportProgress(entry.Key, analyzeResult);
            }
            e.Result = results;
        }

        private Vertex FindVertex(int searchDelta, int subsetDelta, byte[,] baseImage, byte[,] nextImage, Vertex vertex)
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

        private int FindSubsetDiff(int subsetDelta, byte[,] baseImage, byte[,] nextImage, Vertex vertex, int u, int v)
        {
            var sum = 0;
            for (var y = -subsetDelta; y <= subsetDelta; y++)
            {
                for (var x = -subsetDelta; x <= subsetDelta; x++)
                {
                    try
                    {
                        int v0 = baseImage[vertex.Y + y, vertex.X + x];
                        int v1 = nextImage[vertex.Y + y + v, vertex.X + x + u];
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
