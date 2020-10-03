using DigitalImageCorrelation.Core.Requests;
using DigitalImageCorrelation.Core.Structures;
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
        IFindPoints _findPoints;

        internal ImageProcessor(BackgroundWorker bw, AnalyzeRequest request)
        {
            _request = request;
            _findPoints = request.FindPoints;
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
                    var vertexes = _findPoints.FindPoint(_request.WindowDelta, _request.SubsetDelta, orderedDictionary[entry.Key - 1], entry.Value, previous.Vertexes, _request.BitmpWidth, _request.BitmpHeight); ;

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
    }
}
