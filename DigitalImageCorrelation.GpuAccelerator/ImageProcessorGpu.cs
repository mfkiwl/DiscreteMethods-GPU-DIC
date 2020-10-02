namespace DigitalImageCorrelation.GpuAccelerator
{
    public class ImageProcessorGpu
    {
        public void FindVertex()
        {

        }

        static string IsPrime
        {
            get
            {
                return @"
                kernel void GetIfPrime(global int* message)
                {
                    int index = get_global_id(0);
                    int tmp = message[index];
                    int upperl=(int)sqrt((float)tmp);
                    for(int i=2;i<=upperl;i++)
                    {
                        if(tmp%i==0)
                        {
                            message[index]=0;
                            return;
                        }
                    }
                }";
            }
        }


        private void FindVertex(int searchDelta, int subsetDelta, byte[,] baseImage, byte[,] nextImage, int X, int Y)
        {
            int dx = 0;
            int dy = 0;
            int diff = int.MaxValue;
            for (var v = -searchDelta; v <= searchDelta; v++)
            {
                for (var u = -searchDelta; u <= searchDelta; u++)
                {
                    var sum = 0;
                    for (var y = -subsetDelta; y <= subsetDelta; y++)
                    {
                        for (var x = -subsetDelta; x <= subsetDelta; x++)
                        {
                            int v0 = baseImage[Y + y, X + x];
                            int v1 = nextImage[Y + y + v, X + x + u];
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
        }
    }
}
