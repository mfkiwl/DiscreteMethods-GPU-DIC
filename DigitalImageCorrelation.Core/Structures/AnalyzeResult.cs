using DigitalImageCorrelation.Desktop.Structures;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public ConcurrentDictionary<int, ImageResult> CalculateDisplacement()
        {

            Parallel.ForEach(ImageResults.Cast<KeyValuePair<int, ImageResult>>(),
            entry =>
            {
                entry.Value.CalculateDisplacement(StartingPoints);
            });
            return ImageResults;
        }

        public ConcurrentDictionary<int, ImageResult> CalculateStrain(int pointsinX, int pointsinY)
        {

            Parallel.ForEach(ImageResults.Cast<KeyValuePair<int, ImageResult>>(),
            entry =>
            {
                entry.Value.CalculateStrain(pointsinX, pointsinY);
            });
            return ImageResults;
        }
    }
}
