using DigitalImageCorrelation.GpuAccelerator;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace DigitalImageCorrelation.Tests
{
    public class TestMoreAdvancedExample
    {
        MoreAdvancedExample gpu;
        Stopwatch sw;

        [SetUp]
        public void Setup()
        {
            gpu = new MoreAdvancedExample();
            sw = new Stopwatch();
        }

        [Test]
        public void PrimeGPUTest()
        {
            //int[] Primes = Enumerable.Range(2, number).ToArray();
            sw.Start();
            gpu.Mycalculation();
            sw.Stop();
            Console.WriteLine($"PrimeGPUTest: {0} - {sw.ElapsedMilliseconds} ms");
        }
    }
}