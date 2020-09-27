using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DigitalImageCorrelation.Core.Structures
{
    public class AnalyzeResult
    {
        public Dictionary<int, ImageResult> ImageResults = new Dictionary<int, ImageResult>();
        public Vertex[] StartingPoints;
        public double MaxDx => ImageResults.Max(x => x.Value.MaxDx);
        public double MinDx => ImageResults.Min(x => x.Value.MinDx);
        public double MaxDy => ImageResults.Max(x => x.Value.MaxDy);
        public double MinDy => ImageResults.Min(x => x.Value.MinDy);

        public Dictionary<int, ImageResult> CalculateDisplacement()
        {

            Parallel.ForEach(ImageResults.Cast<KeyValuePair<int, ImageResult>>(),
            entry =>
            {
                entry.Value.CalculateDisplacement(StartingPoints);
            });
            return ImageResults;
        }

        public Dictionary<int, ImageResult> CalculateLocalColors()
        {
            double maxDx = MaxDx;
            double minDx = MinDx;
            double maxDy = MaxDy;
            double minDy = MinDy;
            Parallel.ForEach(ImageResults.Cast<KeyValuePair<int, ImageResult>>(),
            entry =>
            {
                entry.Value.CalculateColors(MaxDx, MinDx, MaxDy, MinDy);
            });
            return ImageResults;
        }
    }
}
