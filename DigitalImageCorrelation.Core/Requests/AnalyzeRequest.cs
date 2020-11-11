using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;

namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequest
    {
        public IFindPoints FindPoints { get; set; }
        public Dictionary<int, byte[]> Arrays { get; set; }
        public Vertex[] StartingVertexes { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
        public int BitmpWidth { get; set; }
        public int BitmpHeight { get; set; }
    }
}
