using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;

namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequest
    {
        public Dictionary<int, byte[,]> Arrays { get; set; }

        public IEnumerable<Vertex> StartingVertexes { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
    }
}
