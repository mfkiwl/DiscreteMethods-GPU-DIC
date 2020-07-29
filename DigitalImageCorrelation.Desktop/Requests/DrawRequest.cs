namespace DigitalImageCorrelation.Desktop.Requests
{
    public class DrawRequest
    {
        public ImageContainer image { get; set; }
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowsDelta { get; set; }
        public double PictureWidth { get; set; }
        public double PictureHeight { get; set; }
        public bool ShowCropBox { get; set; }
        public int zoom { get; set; }
    }
}
