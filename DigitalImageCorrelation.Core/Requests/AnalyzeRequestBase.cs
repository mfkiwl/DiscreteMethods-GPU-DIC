namespace DigitalImageCorrelation.Core.Requests
{
    public class AnalyzeRequestBase
    {
        public int PointsinX { get; set; }
        public int PointsinY { get; set; }
        public int SubsetDelta { get; set; }
        public int WindowDelta { get; set; }
        public int BitmapWidth { get; set; }
        public int BitmapHeight { get; set; }
        public int Size { get; set; }
        public SquareLocation Square { get; set; }
    }
}
