using System.Collections.Generic;

namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequest
    {
        public Dictionary<int, ImageContainer> imageContainers { get; set; }

        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
    }
}
