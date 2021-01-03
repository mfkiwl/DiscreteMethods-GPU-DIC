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
        private readonly Stopwatch swStrain = new Stopwatch();
        private readonly Stopwatch swStress = new Stopwatch();
        private readonly Stopwatch swDisplacement = new Stopwatch();
        private readonly Stopwatch swWhole = new Stopwatch();
        private readonly Stopwatch swIteration = new Stopwatch();
        private readonly Stopwatch swFindPoints = new Stopwatch();

        public ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            _request = request;
            _calculation = request.FindPoints;
            backgroundWorker = bw;
        }

        public void Analyze(DoWorkEventArgs e)
        {
            swWhole.Reset();
            _logger.Info("Analyze started");
            swWhole.Start();
            swFindPoints.Reset();
            AnalyzeResult results = new AnalyzeResult()
            {
                StartingVertexes = _request.StartingVertexes.ToArray(),
                Request = _request
            };
            var orderedDictionary = _request.Arrays.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            _logger.Info("Using {0} processor", _calculation.GetType().Name);
            ImageResult analyzeResult;
            foreach (KeyValuePair<int, byte[]> entry in orderedDictionary)
            {
                swIteration.Reset();
                swIteration.Start();
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
                    swFindPoints.Reset();
                    swFindPoints.Start();
                    var previous = results.ImageResults.Last().Value;
                    var vertexes = _calculation.FindPoint(_request.WindowDelta,
                                    _request.SubsetDelta,
                                    orderedDictionary[entry.Key - 1],
                                    entry.Value,
                                    previous.Vertexes,
                                    _request.BitmapWidth,
                                    _request.BitmapHeight,
                                    _request.PointsinX,
                                    _request.PointsinY);

                    swFindPoints.Stop();
                    analyzeResult = new ImageResult
                    {
                        Index = entry.Key,
                        Vertexes = vertexes
                    };
                    swDisplacement.Reset();
                    swStrain.Reset();
                    swStress.Reset();
                    swDisplacement.Start();
                    _calculation.CalculateDisplacement(analyzeResult, _request.StartingVertexes);
                    swDisplacement.Stop();
                    swStrain.Start();
                    _calculation.CalculateStrain(analyzeResult, _request.PointsinX, _request.PointsinY, _request.StartingVertexes);
                    swStrain.Stop();
                    swStress.Start();
                    _calculation.CalculateStress(analyzeResult);
                    swStress.Stop();
                    _logger.Trace("Finding points: {0}ms Displacement: {1}ms, Strain: {2}ms, Stress {3}ms", swFindPoints.ElapsedMilliseconds, swDisplacement.ElapsedMilliseconds, swStrain.ElapsedMilliseconds, swStress.ElapsedMilliseconds);

                }
                if (!results.ImageResults.TryAdd(entry.Key, analyzeResult))
                {
                    throw new Exception("Unable to add result to ConcurrentDictionary");
                }
                backgroundWorker.ReportProgress(entry.Key, analyzeResult);
                swIteration.Stop();
                _logger.Debug("Processing {0}/{1} time: {2}ms", entry.Key + 1, orderedDictionary.Count, swIteration.ElapsedMilliseconds);
            }

            swWhole.Stop();
            _logger.Info("Analyze complited. Time: {0} ms, number of processed images: {1}, Processor: {2}", swWhole.ElapsedMilliseconds, results.ImageResults.Count, _calculation.GetType().Name);
            e.Result = results;
        }
    }
}
