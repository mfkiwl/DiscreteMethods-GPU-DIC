using Cloo;
using System;

namespace DigitalImageCorrelation.GpuAccelerator
{
    public class MoreAdvancedExample
    {

        public void Mycalculation()
        {

            ComputeContextPropertyList cpl = new ComputeContextPropertyList(ComputePlatform.Platforms[0]);
            ComputeContext context = new ComputeContext(ComputeDeviceTypes.Gpu, cpl, null, IntPtr.Zero);
            ComputeProgram program = new ComputeProgram(context, new string[] { CalculateMyKernel });
            program.Build(null, null, null, IntPtr.Zero);
            ComputeCommandQueue commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
            ComputeEventList events = new ComputeEventList();
            ComputeKernel kernel = program.CreateKernel("CalculateMyKernel");
            //byte[,] arr = new byte[,] {
            //    {0,0},{0,1 },{0,2 },{0,3 },{0,4 },{0,5 },{0,6 },
            //    {1,0},{1,1 },{1,2 },{1,3 },{1,4 },{1,5 },{1,6 },
            //    {2,0},{2,1 },{2,2 },{2,3 },{2,4 },{2,5 },{2,6 },
            //    {3,0},{3,1 },{3,2 },{3,3 },{3,4 },{3,5 },{3,6 },
            //    {4,0},{4,1 },{4,2 },{4,3 },{4,4 },{4,5 },{4,6 },
            //    {5,0},{5,1 },{5,2 },{5,3 },{5,4 },{5,5 },{5,6 }
            //};
            byte[] arr = new byte[] { 0, 2, 3, 4, 5, 7, 1, 212, 89 };
            ComputeBuffer<byte> arrBuffer = new ComputeBuffer<byte>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, arr);
            kernel.SetMemoryArgument(0, arrBuffer);
            commands.Execute(kernel, null, new long[] { 10 }, null, events);
            commands.Finish();
        }



        static string CalculateMyKernel
        {
            get
            {
                return @"
            kernel void CalculateMyKernel(global int* arr) 
            {
                int id = get_global_id(0);
                arr[id] = arr[id]/2;              
            }";
            }
        }




        public double[][] CalculateGPU(int partitionSize, double[][] sets, int period)
        {
            ComputeContextPropertyList cpl = new ComputeContextPropertyList(ComputePlatform.Platforms[0]);
            ComputeContext context = new ComputeContext(ComputeDeviceTypes.Gpu, cpl, null, IntPtr.Zero);
            ComputeProgram program = new ComputeProgram(context, new string[] { CalculateKernel });
            program.Build(null, null, null, IntPtr.Zero);
            ComputeCommandQueue commands = new ComputeCommandQueue(context, context.Devices[0], ComputeCommandQueueFlags.None);
            ComputeEventList events = new ComputeEventList();
            ComputeKernel kernel = program.CreateKernel("Calc");
            double[][] results = new double[sets.Length][];
            double periodFactor = 2d / (1d + period);
            int offset = 0;
            int first = offset;
            int last = Math.Min(offset + partitionSize, sets.Length);
            int length = last - first;
            ComputeBuffer<int> offsetBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, offset);
            ComputeBuffer<int> lengthsBuffer = new ComputeBuffer<int>(context, ComputeMemoryFlags.ReadWrite | ComputeMemoryFlags.UseHostPointer, length);
            kernel.SetMemoryArgument(0, offsetBuffer);
            kernel.SetMemoryArgument(1, lengthsBuffer);
            //kernel.SetMemoryArgument(2, doublesBuffer);
            kernel.SetValueArgument(3, periodFactor);
            //executeStopWatch.Start();
            //commands.Execute(kernel, null, new long[] { merged.Lengths.Length }, null, events);
            return results;
        }

        static string CalculateKernel
        {
            get
            {
                return @"
            kernel void Calc(global int* offsets, global int* lengths, global double* doubles, double periodFactor) 
            {
                int id = get_global_id(0);
                int start = offsets[id];
                int length = lengths[id];
                int end = start + length;
                double sum = doubles[start];

                for(int i = start; i < end; i++)
                {
                    sum = sum + periodFactor * ( doubles[i] - sum );
                    doubles[i] = sum;
                }
            }";
            }
        }
    }
}
