using DigitalImageCorrelation.GpuAccelerator;
using NUnit.Framework;
using System.Linq;

namespace DigitalImageCorrelation.Tests
{
    public class TestGPUAccelerator
    {
        GpuExample gpu;
        [SetUp]
        public void Setup()
        {
            gpu = new GpuExample();
        }

        [Test]
        public void PrimeExample()
        {
            int[] Primes = Enumerable.Range(2, 1000000).ToArray();
            var result = gpu.FindPrimes(Primes);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}