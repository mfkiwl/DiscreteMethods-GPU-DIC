using BenchmarkDotNet.Attributes;
using DigitalImageCorrelation.Calculation;
using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Requests;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;

namespace DiscreteMethods.BenchmarkTests
{
    [SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, launchCount: 1, warmupCount: 0, targetCount: 3)]
    [KeepBenchmarkFiles]
    [HtmlExporter]
    public class Benchmarker
    {
        ConcurrentDictionary<int, ImageContainer> ImageContainers = new ConcurrentDictionary<int, ImageContainer>();
        string[] paths = new string[] { "./Images/image0.png", "./Images/image1.png" };
        BackgroundWorker backgroundWorker = new BackgroundWorker();

        [GlobalSetup]
        public void Setup()
        {
            foreach (var (path, index) in paths.WithIndex())
            {
                Bitmap bitmap = new Bitmap(path);
                ImageContainers[index] = new ImageContainer(bitmap, Path.GetFileName(path), index);
            }
            backgroundWorker.WorkerReportsProgress = true;

        }

        [Benchmark]
        //[Arguments(10, 10, 10, 10, CalculationType.Cpu)]
        //[Arguments(50, 50, 10, 10, CalculationType.Cpu)]
        //[Arguments(100, 100, 10, 10, CalculationType.Cpu)]
        //[Arguments(10, 10, 50, 50, CalculationType.Cpu)]
        [Arguments(10, 10, 100, 100, CalculationType.Cpu)]
        [Arguments(10, 10, 200, 200, CalculationType.Cpu)]
        [Arguments(10, 10, 400, 400, CalculationType.Cpu)]
        [Arguments(10, 10, 600, 600, CalculationType.Cpu)]

        //[Arguments(10, 10, 10, 10, CalculationType.Gpu)]
        //[Arguments(50, 50, 10, 10, CalculationType.Gpu)]
        //[Arguments(100, 100, 10, 10, CalculationType.Gpu)]
        //[Arguments(10, 10, 50, 50, CalculationType.Gpu)]
        [Arguments(10, 10, 100, 100, CalculationType.Gpu)]
        [Arguments(10, 10, 200, 200, CalculationType.Gpu)]
        [Arguments(10, 10, 400, 400, CalculationType.Gpu)]
        [Arguments(10, 10, 600, 600, CalculationType.Gpu)]
        public void AnalyzeImages(int SubsetDelta, int WindowDelta, int PointsinX, int PointsinY, CalculationType calculationType)
        {
            var firstImage = ImageContainers.First().Value;
            AnalyzeRequest request = new AnalyzeRequest()
            {
                FindPoints = ResolveFindPoints(calculationType),
                Arrays = ImageContainers.ToDictionary(x => x.Key, x => x.Value.GrayScaleImage),
                SubsetDelta = SubsetDelta,
                WindowDelta = WindowDelta,
                PointsinX = PointsinX,
                PointsinY = PointsinY,
                StartingVertexes = firstImage.square.CalculateStartingVertexes(PointsinX, PointsinY),
                BitmpHeight = firstImage.BitmapHeight,
                BitmpWidth = firstImage.BitmapWidth
            };
            var imageprocessor = new ImageProcessor(backgroundWorker, request);
            imageprocessor.Analyze(new DoWorkEventArgs(null));
        }
        private IFindPoints ResolveFindPoints(CalculationType type)
        {
            return type switch
            {
                (CalculationType.Cpu) => new FindPointCpu(),
                (CalculationType.Gpu) => new FindPointCuda(),
                _ => new FindPointCpu(),
            };
        }

    }
}
