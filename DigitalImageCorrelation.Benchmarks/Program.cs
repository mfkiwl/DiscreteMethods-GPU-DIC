using BenchmarkDotNet.Running;
using DiscreteMethods.BenchmarkTests;

namespace DigitalImageCorrelation.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<Benchmarker>();
        }
    }
}
