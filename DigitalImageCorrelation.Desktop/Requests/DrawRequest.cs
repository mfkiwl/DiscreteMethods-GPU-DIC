using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Drawing;

namespace DigitalImageCorrelation.Desktop.Requests
{
    public class DrawRequest
    {
        public AnalyzeResult AnalyzeResults { get; set; }
        public ImageContainer Image { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
        public double PictureWidth { get; set; }
        public double PictureHeight { get; set; }
        public bool ShowCropBox { get; set; }
        public DrawingType Type { get; set; }
        public double Max { get; set; }
        public double Min { get; set; }
        public SquareLocation Square { get; set; }
    }
}
