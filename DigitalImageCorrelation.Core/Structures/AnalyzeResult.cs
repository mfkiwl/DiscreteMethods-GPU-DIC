using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Concurrent;
using System.Linq;

namespace DigitalImageCorrelation.Core.Structures
{
    public class AnalyzeResult
    {
        public ConcurrentDictionary<int, ImageResult> ImageResults = new ConcurrentDictionary<int, ImageResult>();
        public Vertex[] StartingPoints;
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
    }
}
