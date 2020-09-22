using DigitalImageCorrelation.Core;
using System.Collections.Generic;

namespace DigitalImageCorrelation.Desktop.Requests
{
    public class DrawRequest
    {
        public Dictionary<int, AnalyzeResult> AnalyzeResults { get; set; }
        public ImageContainer Image { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
        public double PictureWidth { get; set; }
        public double PictureHeight { get; set; }
        public bool ShowCropBox { get; set; }
        public double Zoom { get; set; }
        public DrawingType Type { get; set; }
    }
}
