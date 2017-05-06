using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class SummationOfPrimes : IProblem
    {
        public int ProblemId { get { return 10; } }

        public double GetSolution()
        {
            int n = 2000000;
            long sum = 0;

            //sum of primes below n
            for (int i = 2; i < n; i++)
            {
                if (IsPrime(i))
                {
                    sum += i;
                }
            }

            return sum;
        }

        private bool IsPrime(int i)
        {
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
