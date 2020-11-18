using Cloo.Extensions;
using System;
using System.Linq;

namespace DigitalImageCorrelation.Calculation
{
    public class GpuExample
    {
        public int[] FindPrimesGPU(int[] Primes)
        {
            Primes.ClooForEach(IsPrime, null, null);
            return Primes;
        }


        public int[] FindPrimesCPUParallel(int[] Primes)
        {
            var result = Primes.AsParallel().AsOrdered().Select(x => GetIfPrime(x)).ToArray();
            return result;
        }

        public int[] FindPrimesCPUSingleCore(int[] Primes)
        {
            var result = Primes.Select(x => GetIfPrime(x)).ToArray();
            return result;
        }

        static int GetIfPrime(int tmp)
        {
            int upperl = (int)Math.Sqrt((float)tmp);
            for (int i = 2; i <= upperl; i++)
            {
                if (tmp % i == 0)
                {
                    return 0;
                }
            }
            return tmp;
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
