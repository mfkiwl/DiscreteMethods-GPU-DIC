using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Concurrent;
using System.Linq;

namespace DigitalImageCorrelation.Core.Structures
{
    public class AnalyzeResult
    {
        public ConcurrentDictionary<int, ImageResult> ImageResults = new ConcurrentDictionary<int, ImageResult>();
        public Vertex[] StartingVertexes;
        public double MaxDx => ImageResults.Max(x => x.Value.MaxDx);
        public double MinDx => ImageResults.Min(x => x.Value.MinDx);
        public double MaxDy => ImageResults.Max(x => x.Value.MaxDy);
        public double MinDy => ImageResults.Min(x => x.Value.MinDy);
        public double MaxStrainXX => ImageResults.Max(x => x.Value.MaxStrainX);
        public double MinStrainXX => ImageResults.Min(x => x.Value.MinStrainX);
        public double MaxStrainYY => ImageResults.Max(x => x.Value.MaxStrainY);
        public double MinStrainYY => ImageResults.Min(x => x.Value.MinStrainY);
        public double MaxStrainXY => ImageResults.Max(x => x.Value.MaxStrainXY);
        public double MinStrainXY => ImageResults.Min(x => x.Value.MinStrainXY);

        public double MaxStressXX => ImageResults.Max(x => x.Value.MaxStressX);
        public double MinStressXX => ImageResults.Min(x => x.Value.MinStressX);
        public double MaxStressYY => ImageResults.Max(x => x.Value.MaxStressY);
        public double MinStressYY => ImageResults.Min(x => x.Value.MinStressY);
        public double MaxStressEq => ImageResults.Max(x => x.Value.MaxStressEq);
        public double MinStressEq => ImageResults.Min(x => x.Value.MinStressEq);
    }
}
