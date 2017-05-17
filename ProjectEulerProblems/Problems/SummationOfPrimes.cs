using System;
using System.Collections;

namespace ProjectEulerProblems
{
    public class SummationOfPrimes : IProblem
    {
        public int ProblemId { get { return 10; } }

        public double GetSolution()
        {
            int n = 2000000;
            long sum = 0;

            BitArray bits = new BitArray(n);

            //switch bit for non-primes
            for (int i = 2; i < Math.Sqrt(n); i++)
            {
                for (int j = 2; j * i < 2000000; j++)
                {
                    bits[(j * i) - 1] = true;
                }
            }

            for (int i  = 0; i < bits.Length; i++)
            {
                if (!bits[i])
                {
                    sum += i;;
                }
            }

            return sum;
        }
    }
}
