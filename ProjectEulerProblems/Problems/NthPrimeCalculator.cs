using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class NthPrimeCalculator : IProblem
    {
        public int ProblemId { get { return 7; } }

        public double GetSolution()
        {
            int n = 10001;
            int counter = 0;
            List<long> primes = new List<long>();

            for (int i = 2; counter < n; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                    counter++;
                }
            }

            long answer = primes[primes.Count - 1];
            return answer;
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
            return true;
        }
    }
}
