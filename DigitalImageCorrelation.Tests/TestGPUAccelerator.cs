using DigitalImageCorrelation.GpuAccelerator;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Linq;

namespace DigitalImageCorrelation.Tests
{
    public class TestGPUAccelerator
    {
        GpuExample gpu;
        Stopwatch sw;

        [SetUp]
        public void Setup()
        {
            gpu = new GpuExample();
            sw = new Stopwatch();
        }

        [Test]
        [TestCase(100)]
        [TestCase(10000000)]
        [TestCase(20000000)]
        [TestCase(50000000)]
        public void PrimeGPUTest(int number)
        {
            int[] Primes = Enumerable.Range(2, number).ToArray();
            sw.Start();
            var result = gpu.FindPrimesGPU(Primes);
            sw.Stop();
            Console.WriteLine($"PrimeGPUTest: {number} - {sw.ElapsedMilliseconds} ms");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        [TestCase(100)]
        [TestCase(10000000)]
        [TestCase(20000000)]
        [TestCase(50000000)]
        public void PrimeCPUSingleCoreTest(int number)
        {
            int[] Primes = Enumerable.Range(2, number).ToArray();
            sw.Start();
            var result = gpu.FindPrimesCPUSingleCore(Primes);
            sw.Stop();
            Console.WriteLine($"PrimeCPUSingleCoreTest: {number} - {sw.ElapsedMilliseconds} ms");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [Test]
        [TestCase(100)]
        [TestCase(10000000)]
        [TestCase(20000000)]
        [TestCase(50000000)]
        public void PrimeCPUParallelTest(int number)
        {
            int[] Primes = Enumerable.Range(2, number).ToArray();
            sw.Start();
            var result = gpu.FindPrimesCPUParallel(Primes);
            sw.Stop();
            Console.WriteLine($"PrimeCPUParallelTest: {number} - {sw.ElapsedMilliseconds} ms");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}