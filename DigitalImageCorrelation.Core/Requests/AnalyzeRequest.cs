using System.Collections.Generic;
using System.Drawing;

namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequest
    {
        public Dictionary<int, byte[,]> Arrays { get; set; }

        public IEnumerable<Point> StartingPoints { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
    }
}
