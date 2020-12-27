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
        public double MaxStrainXX => ImageResults.Max(x => x.Value.MaxStrainXX);
        public double MinStrainXX => ImageResults.Min(x => x.Value.MinStrainXX);
        public double MaxStrainYY => ImageResults.Max(x => x.Value.MaxStrainYY);
        public double MinStrainYY => ImageResults.Min(x => x.Value.MinStrainYY);
        public double MaxStrainXY => ImageResults.Max(x => x.Value.MaxStrainXY);
        public double MinStrainXY => ImageResults.Min(x => x.Value.MinStrainXY);

        public double MaxStressXX => ImageResults.Max(x => x.Value.MaxStressXX);
        public double MinStressXX => ImageResults.Min(x => x.Value.MinStressXX);
        public double MaxStressYY => ImageResults.Max(x => x.Value.MaxStressYY);
        public double MinStressYY => ImageResults.Min(x => x.Value.MinStressYY);
        public double MaxStressEq => ImageResults.Max(x => x.Value.MaxStressEq);
        public double MinStressEq => ImageResults.Min(x => x.Value.MinStressEq);
    }
}
