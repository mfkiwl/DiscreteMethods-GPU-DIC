using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;

namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequest : AnalyzeRequestBase
    {
        public ICalculation FindPoints { get; set; }
        public Dictionary<int, byte[]> Arrays { get; set; }
        public Vertex[] StartingVertexes { get; set; }
    }
}
