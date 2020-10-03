using DigitalImageCorrelation.Desktop.Structures;

namespace DigitalImageCorrelation.Core
{
    public interface IFindPoints
    {
        Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] vertexes, int BitmapWidth, int BitmapHeight);
    }
}
