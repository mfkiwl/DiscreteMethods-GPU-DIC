using DigitalImageCorrelation.Core.Structures;
using DigitalImageCorrelation.Desktop.Structures;

namespace DigitalImageCorrelation.Core
{
    public interface ICalculation
    {
        Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] vertexes, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY);
        void CalculateStrain(ImageResult image, int pointsinX, int pointsinY);
        void CalculateStress(ImageResult image);
        void CalculateDisplacement(ImageResult image);


    }
}
