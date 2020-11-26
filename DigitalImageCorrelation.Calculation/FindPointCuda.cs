using DigitalImageCorrelation.Calculation.Cuda;
using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Structures;
using ManagedCuda;
using System.Linq;

namespace DigitalImageCorrelation.Calculation
{
    public class FindPointCuda : IFindPoints
    {
        public FindPointCuda()
        {
            int deviceCount = CudaContext.GetDeviceCount();
            if (deviceCount == 0)
                throw new CudaException("There is no device available for cuda");
        }

        public Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] previousVertexes, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {

            var points = previousVertexes.Select(vertex => new ResultPoint() { X = vertex.X, Y = vertex.Y }).ToArray();
            var result = FindPoints(baseImage, nextImage, points, searchDelta, subsetDelta, BitmapWidth, BitmapHeight, PointsinX, PointsinY);
            return result.Select(point => new Vertex(point.X, point.Y)).ToArray();
        }

        ResultPoint[] FindPoints(byte[] baseImage, byte[] nextImage, ResultPoint[] points, int searchDelta, int subsetDelta, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {
            using var cudaProcessor = new CudaProcessor();
            cudaProcessor.LoadKernel();
            return cudaProcessor.FindPoints(baseImage, nextImage, points, searchDelta, subsetDelta, BitmapWidth, BitmapHeight, PointsinX, PointsinY);
        }
    }
}
