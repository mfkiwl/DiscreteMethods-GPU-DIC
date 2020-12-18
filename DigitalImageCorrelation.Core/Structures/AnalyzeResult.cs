using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Concurrent;
using System.Linq;

namespace DigitalImageCorrelation.Core.Structures
{
    public class AnalyzeResult
    {
        public ConcurrentDictionary<int, ImageResult> ImageResults = new ConcurrentDictionary<int, ImageResult>();
        public Vertex[] StartingVertexes;
        public double MaxDx => ImageResults.Max(x => x.Value.Vertexes.Max(x => x.dX));
        public double MinDx => ImageResults.Min(x => x.Value.Vertexes.Min(x => x.dX));
        public double MaxDy => ImageResults.Max(x => x.Value.Vertexes.Max(x => x.dY));
        public double MinDy => ImageResults.Min(x => x.Value.Vertexes.Min(x => x.dY));
        public double MaxStrainXX => ImageResults.Max(x => x.Value.Vertexes.Max(x => x.strain.XX));
        public double MinStrainXX => ImageResults.Min(x => x.Value.Vertexes.Min(x => x.strain.XX));
        public double MaxStrainYY => ImageResults.Max(x => x.Value.Vertexes.Max(x => x.strain.YY));
        public double MinStrainYY => ImageResults.Min(x => x.Value.Vertexes.Min(x => x.strain.YY));
        public double MaxStrainXY => ImageResults.Max(x => x.Value.Vertexes.Max(x => x.strain.XY));
        public double MinStrainXY => ImageResults.Min(x => x.Value.Vertexes.Min(x => x.strain.XY));
    }
}
