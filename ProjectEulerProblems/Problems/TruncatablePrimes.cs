using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class TruncatablePrimes : IProblem
    {
        public int ProblemId { get { return 37; } }

        public double GetSolution()
        {
            TruncatablePrimeCalculator truncPrimeCalc = new TruncatablePrimeCalculator();
            HashSet<int> truncatablePrimes = new HashSet<int>();
            int counter = 23; //first is 23 by observation

            while (truncatablePrimes.Count < 11)
            {
                if (truncPrimeCalc.IsTruncatablePrime(counter))
                {
                    truncatablePrimes.Add(counter);
                }
            }

            return truncatablePrimes.Sum();
        }

        private bool IsPrime(int n)
        {
            //If there's a prime > root(n) then there's certainly one < root(n)
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            if (n == 1)
            {
                return false;
            }
            return true;
        }

        class TruncatablePrimeCalculator
        {
            public bool IsTruncatablePrime(int counter)
            {
                throw new NotImplementedException();
            }
        }
    }
}
