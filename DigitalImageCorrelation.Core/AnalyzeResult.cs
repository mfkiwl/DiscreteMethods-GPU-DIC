using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;

namespace DigitalImageCorrelation.Core
{
    public class AnalyzeResult
    {
        public IEnumerable<Vertex> Vertexes;
        public IEnumerable<Vertex> StartingPoints;
        public int Index;
    }
}
