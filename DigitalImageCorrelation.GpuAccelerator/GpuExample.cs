using Cloo.Extensions;

namespace DigitalImageCorrelation.GpuAccelerator
{
    public class GpuExample
    {
        public int[] FindPrimes(int[] Primes)
        {
            Primes.ClooForEach(IsPrime, null, null);
            return Primes;
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

    }
}
