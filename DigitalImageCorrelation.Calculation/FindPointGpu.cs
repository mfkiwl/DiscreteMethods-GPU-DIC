using Cloo;
using DigitalImageCorrelation.Core;
using DigitalImageCorrelation.Desktop.Structures;
using System;
using System.Linq;

namespace DigitalImageCorrelation.GpuAccelerator
{
    public class FindPointGpu : IFindPoints
    {
        readonly ComputeContextPropertyList cpl;
        readonly ComputeContext context;
        readonly ComputeProgram program;
        readonly ComputeKernel kernel;
        public FindPointGpu()
        {
            cpl = new ComputeContextPropertyList(ComputePlatform.Platforms[0]);
            context = new ComputeContext(ComputeDeviceTypes.Gpu, cpl, null, IntPtr.Zero);
            program = new ComputeProgram(context, new string[] { FindPointCalculationGpu });
            program.Build(null, null, null, IntPtr.Zero);
            kernel = program.CreateKernel("FindPointCalculationGpu");
        }

        public Vertex[] FindPoint(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, Vertex[] previousVertexes, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {
            int[] X = previousVertexes.Select(x => x.X).ToArray();
            int[] Y = previousVertexes.Select(x => x.Y).ToArray();
            FindPoints(baseImage, nextImage, X, Y, searchDelta, subsetDelta, BitmapWidth, BitmapHeight, PointsinX, PointsinY);
            Vertex[] vertexes = new Vertex[X.Length];
            for (int i = 0; i < previousVertexes.Length; i++)
            {
                vertexes[i] = new Vertex(X[i], Y[i]);
            }
            return vertexes;
        }

        public void FindPoints(byte[] baseImage, byte[] nextImage, int[] X, int[] Y, int searchDelta, int subsetDelta, int BitmapWidth, int BitmapHeight, int PointsinX, int PointsinY)
        {
            using var commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
            using ComputeBuffer<byte> baseImageBuffer = new ComputeBuffer<byte>(context, ComputeMemoryFlags.WriteOnly | ComputeMemoryFlags.CopyHostPointer, baseImage);
            using ComputeBuffer<byte> nextImageBuffer = new ComputeBuffer<byte>(context, ComputeMemoryFlags.WriteOnly | ComputeMemoryFlags.CopyHostPointer, nextImage);
            using ComputeBuffer<int> XBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, X);
            using ComputeBuffer<int> YBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, Y);
            kernel.SetMemoryArgument(0, baseImageBuffer);
            kernel.SetMemoryArgument(1, nextImageBuffer);
            kernel.SetMemoryArgument(2, XBuffer);
            kernel.SetMemoryArgument(3, YBuffer);
            kernel.SetValueArgument(4, searchDelta);
            kernel.SetValueArgument(5, subsetDelta);
            kernel.SetValueArgument(6, BitmapHeight);
            kernel.SetValueArgument(7, PointsinX);
            commands.Execute(kernel, null, new long[] { PointsinX, PointsinY }, null, null);
            commands.Finish();
        }

        static string FindPointCalculationGpu
        {
            get
            {
                return @"
            kernel void FindPointCalculationGpu(global uchar* baseImage, global uchar* nextImage, global int* X, global int* Y, int searchDelta, int subsetDelta, int BitmapHeight, int PointsinX) 
            {
                int dx = 0;
                int dy = 0;
                int diff = 2147483647;
                int pos = get_global_id(0) * PointsinX + get_global_id(1);
                for (int v = -searchDelta; v <= searchDelta; v++)
                {
                    for (int u = -searchDelta; u <= searchDelta; u++)
                    {
                        int sum = 0;
                        for (int y = -subsetDelta; y <= subsetDelta; y++)
                        {
                            for (int x = -subsetDelta; x <= subsetDelta; x++)
                            {
                                int v0 = (int)baseImage[(X[pos] + x) * BitmapHeight + Y[pos] + y];
                                int v1 = (int)nextImage[(X[pos] + x + u) * BitmapHeight + Y[pos] + y + v];
                                sum += (v0 - v1) * (v0 - v1);
                            }
                        }
                        if (sum < diff)
                        {
                            diff = sum;
                            dx = u;
                            dy = v;
                        }
                    }
                }
                X[pos] += dx;
                Y[pos] += dy;
            }";
            }
        }
    }
}
