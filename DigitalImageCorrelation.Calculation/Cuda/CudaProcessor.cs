using ManagedCuda;
using ManagedCuda.NVRTC;
using System;
using System.IO;

namespace DigitalImageCorrelation.Calculation.Cuda
{
    unsafe sealed class CudaProcessor : IDisposable
    {
        private const string path = "./Cuda/MyKernels.c";
        private const string methodName = "FindPointCalculationGpu";
        CudaContext ctx;
        CudaKernel kernel;

        CudaDeviceVariable<byte> baseImageBuffer;
        CudaDeviceVariable<byte> nextImageBuffer;
        CudaDeviceVariable<ResultPoint> pointsBuffer;

        public CudaProcessor()
        {
            ctx = new CudaContext(0, true);
            ctx.GetDeviceInfo();
        }

        internal void LoadKernel()
        {
            ctx = new CudaContext(0, true);
            nvrtcResult result;
            using var rtc = new CudaRuntimeCompiler(File.ReadAllText(path), Path.GetFileName(path));
            rtc.Compile(Array.Empty<string>());
            result = nvrtcResult.Success;
            if (result == nvrtcResult.Success)
            {
                byte[] ptx = rtc.GetPTX();
                kernel = ctx.LoadKernelFatBin(ptx, methodName);
            }
        }

        public void FindPoints(byte[] baseImage, byte[] nextImage, ResultPoint[] points, int searchDelta, int subsetDelta, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {
            baseImageBuffer = new CudaDeviceVariable<byte>(BitmapWidth * BitmapHeight);
            baseImageBuffer.CopyToDevice(baseImage);

            nextImageBuffer = new CudaDeviceVariable<byte>(BitmapWidth * BitmapHeight);
            nextImageBuffer.CopyToDevice(nextImage);

            pointsBuffer = new CudaDeviceVariable<ResultPoint>(PointsinX * PointsinY);
            pointsBuffer.CopyToDevice(points);

            kernel.BlockDimensions = new ManagedCuda.VectorTypes.dim3(PointsinX, 1, 1);
            kernel.GridDimensions = new ManagedCuda.VectorTypes.dim3(PointsinY, 1, 1);
            kernel.Run(new object[] {
                baseImageBuffer.DevicePointer,nextImageBuffer.DevicePointer, pointsBuffer.DevicePointer,searchDelta,subsetDelta,BitmapHeight,PointsinX
            });
        }

        internal void CopyToHost(ref ResultPoint[] results)
        {
            pointsBuffer.CopyToHost(results);
        }

        internal void Synchronize()
        {
            ctx.Synchronize();
        }

        public void Dispose()
        {
            DriverAPINativeMethods.MemoryManagement.cuMemFree_v2(baseImageBuffer.DevicePointer);
            DriverAPINativeMethods.MemoryManagement.cuMemFree_v2(nextImageBuffer.DevicePointer);
            DriverAPINativeMethods.MemoryManagement.cuMemFree_v2(pointsBuffer.DevicePointer);
            baseImageBuffer.Dispose();
            nextImageBuffer.Dispose();
            pointsBuffer.Dispose();
        }
    }
}
