typedef struct
{
    int X;
    int Y;
} ResultPoint;

extern "C"
{
    __global__ void FindPointCalculationGpu(const unsigned char* baseImage,const unsigned char* nextImage, ResultPoint* __restrict points,const int searchDelta,const int subsetDelta,const int BitmapHeight,const int PointsinX)
    {
        int dx = 0;
        int dy = 0;
        int diff = 2147483647;
        int pos = blockIdx.x * blockDim.x + threadIdx.x;
        for (int v = -searchDelta; v <= searchDelta; v++)
        {
            for (int u = -searchDelta; u <= searchDelta; u++)
            {
                int sum = 0;
                for (int y = -subsetDelta; y <= subsetDelta; y++)
                {
                    for (int x = -subsetDelta; x <= subsetDelta; x++)
                    {
                        int v0 = baseImage[((points + pos)->X + x) * BitmapHeight + (points + pos)->Y + y];
                        int v1 = (int)nextImage[((points + pos)->X + x + u) * BitmapHeight + (points + pos)->Y + y + v];
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
        (points + pos)->X += dx;
        (points + pos)->Y += dy;
    }
}