using DigitalImageCorrelation.GpuAccelerator;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace DigitalImageCorrelation.Tests
{
    public class FindPointGpuTest
    {
        FindPointGpu gpu;
        Stopwatch sw;

        [SetUp]
        public void Setup()
        {
            gpu = new FindPointGpu();
            sw = new Stopwatch();
        }

        [Test]
        public void PrimeGPUTest()
        {
            byte[] baseImage = new byte[] { 0, 2, 3, 4, 5, 7, 1, 200, 89, 150 };
            byte[] nextImage = new byte[] { 1, 3, 4, 4, 23, 2, 12, 220, 9, 15 }; ;
            int[] X = new int[baseImage.Length];
            int[] Y = new int[baseImage.Length];
            int searchDelta = 5;
            int subsetDelta = 6;
            int width = 3;
            int PointsinX = 3;
            int PointsinY = 3;
            int height = 3;
            sw.Start();
            gpu.FindPoints(baseImage, nextImage, X, Y, searchDelta, subsetDelta, width, height, PointsinX, PointsinY);
            sw.Stop();
            Console.WriteLine($"PrimeGPUTest: {0} - {sw.ElapsedMilliseconds} ms");
        }
    }
}