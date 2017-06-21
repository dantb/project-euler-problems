﻿using System;
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
                counter++;
            }

            return truncatablePrimes.Sum();
        }

        class TruncatablePrimeCalculator
        {
            private Dictionary<string, bool> numberPrimeCache = new Dictionary<string, bool>();

            public bool IsTruncatablePrime(int candidate)
            {
                if (!IsPrime(candidate))
                {
                    return false;
                }

                string asString = candidate.ToString();

                //left to right
                for (int i = 1; i < asString.Length; i++)
                {
                    string truncated = asString.Substring(i);
                    if (!IsPrime(int.Parse(truncated)))
                    {
                        return false;
                    }
                }

                //right to left
                for (int i = asString.Length - 1; i > 0; i--)
                {
                    string truncated = asString.Substring(0, i);
                    if (!IsPrime(int.Parse(truncated)))
                    {
                        return false;
                    }
                }

                return true;
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
        }
    }
}
