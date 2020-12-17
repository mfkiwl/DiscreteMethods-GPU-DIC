using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;


namespace DigitalImageCorrelation.Core
{
    public class ImageProcessor
    {
        private readonly BackgroundWorker backgroundWorker;
        private readonly AnalyzeRequest _request;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ICalculation _calculation;
        private readonly Stopwatch sw = new Stopwatch();

        public ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            _request = request;
            _calculation = request.FindPoints;
            backgroundWorker = bw;
        }

        public void Analyze(DoWorkEventArgs e)
        {
            sw.Reset();
            _logger.Info("Analyze started");
            sw.Start();
            AnalyzeResult results = new AnalyzeResult()
            {
                StartingVertexes = _request.StartingVertexes.ToArray()
            };
            var orderedDictionary = _request.Arrays.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            _logger.Info("Using {0} processor", _calculation.GetType().Name);
            ImageResult analyzeResult;
            foreach (KeyValuePair<int, byte[]> entry in orderedDictionary)
            {
                if (entry.Key == 0)
                {
                    analyzeResult = new ImageResult
                    {
                        Index = entry.Key,
                        Vertexes = results.StartingVertexes
                    };
                }
                else
                {
                    var previous = results.ImageResults.Last().Value;
                    var vertexes = _calculation.FindPoint(_request.WindowDelta,
                                    _request.SubsetDelta,
                                    orderedDictionary[entry.Key - 1],
                                    entry.Value,
                                    previous.Vertexes,
                                    _request.BitmpWidth,
                                    _request.BitmpHeight,
                                    _request.PointsinX,
                                    _request.PointsinY);

                    analyzeResult = new ImageResult
                    {
                        Index = entry.Key,
                        Vertexes = vertexes
                    };
                    _calculation.CalculateDisplacement(analyzeResult, _request.StartingVertexes);
                    _calculation.CalculateStrain(analyzeResult, _request.PointsinX, _request.PointsinY, _request.StartingVertexes);
                    _calculation.CalculateStress(analyzeResult);
                }
                if (!results.ImageResults.TryAdd(entry.Key, analyzeResult))
                {
                    throw new Exception("Unable to add result to ConcurrentDictionary");
                }
                backgroundWorker.ReportProgress(entry.Key, analyzeResult);
                _logger.Debug("Processing {0}/{1}", entry.Key + 1, orderedDictionary.Count);
            }

            sw.Stop();
            _logger.Info("Analyze complited. Time: {0} ms, number of processed images: {1}, Processor: {2}", sw.ElapsedMilliseconds, results.ImageResults.Count, _calculation.GetType().Name);
            e.Result = results;
        }
    }
}
