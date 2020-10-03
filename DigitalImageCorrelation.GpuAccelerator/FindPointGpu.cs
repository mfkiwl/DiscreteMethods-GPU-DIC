using Cloo;
using System;

namespace DigitalImageCorrelation.GpuAccelerator
{
    public class FindPointGpu
    {
        readonly ComputeContext context;
        readonly ComputeEventList events;
        readonly ComputeKernel kernel;
        readonly ComputeCommandQueue commands;
        readonly ComputeProgram program;
        public FindPointGpu()
        {
            ComputeContextPropertyList cpl = new ComputeContextPropertyList(ComputePlatform.Platforms[0]);
            context = new ComputeContext(ComputeDeviceTypes.Gpu, cpl, null, IntPtr.Zero);
            program = new ComputeProgram(context, new string[] { FindPoint });
            program.Build(null, null, null, IntPtr.Zero);
            commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
            events = new ComputeEventList();
            kernel = program.CreateKernel("FindPoint");
        }

        public void FindPoints(byte[] baseImage, byte[] nextImage, int[] X, int[] Y, int searchDelta, int subsetDelta, int width)
        {
            ComputeBuffer<byte> baseImageBuffer = new ComputeBuffer<byte>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, baseImage);
            ComputeBuffer<byte> nextImageBuffer = new ComputeBuffer<byte>(context, ComputeMemoryFlags.ReadOnly | ComputeMemoryFlags.UseHostPointer, nextImage);
            ComputeBuffer<int> XBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, X);
            ComputeBuffer<int> YBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, Y);
            kernel.SetMemoryArgument(0, baseImageBuffer);
            kernel.SetMemoryArgument(1, nextImageBuffer);
            kernel.SetMemoryArgument(2, XBuffer);
            kernel.SetMemoryArgument(3, YBuffer);
            kernel.SetValueArgument(4, searchDelta);
            kernel.SetValueArgument(5, subsetDelta);
            kernel.SetValueArgument(6, width);
            commands.Execute(kernel, null, new long[] { X.Length }, null, events);
            commands.Finish();
        }

        static string FindPoint
        {
            get
            {
                return @"
            kernel void FindPoint(global char* baseImage, global char* nextImage, global int* X, global int* Y, int searchDelta,int subsetDelta, int width) 
            {
                int id = get_global_id(0);
                int dx = 0;
                int dy = 0;
                int diff = 2147483647;
                for (int v = -searchDelta; v <= searchDelta; v++)
                {
                    for (int u = -searchDelta; u <= searchDelta; u++)
                    {
                        int sum = 0;
                        for (int y = -subsetDelta; y <= subsetDelta; y++)
                        {
                            for (int x = -subsetDelta; x <= subsetDelta; x++)
                            {
                                int v0 = baseImage[(Y[id] + y) * width + X[id] + x];
                                int v1 = nextImage[(Y[id] + y + v) * width + X[id] + x + u];
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
                X[id] += dx;
                Y[id] += dy;
            }";
            }
        }


        private void FindVertex(int searchDelta, int subsetDelta, byte[] baseImage, byte[] nextImage, int[] X, int[] Y, int width)
        {
            int id = 0;
            int dx = 0;
            int dy = 0;
            int diff = int.MaxValue;
            for (int v = -searchDelta; v <= searchDelta; v++)
            {
                for (int u = -searchDelta; u <= searchDelta; u++)
                {
                    int sum = 0;
                    for (int y = -subsetDelta; y <= subsetDelta; y++)
                    {
                        for (int x = -subsetDelta; x <= subsetDelta; x++)
                        {
                            int v0 = baseImage[(Y[id] + y) * width + X[id] + x];
                            int v1 = nextImage[(Y[id] + y + v) * width + X[id] + x + u];
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
            X[id] += dx;
            Y[id] += dy;
        }
    }
}
