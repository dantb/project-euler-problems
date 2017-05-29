using System;
using System.Collections.Generic;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class DistinctPowers : IProblem
    {
        public int ProblemId { get { return 29; } }

        public double GetSolution()
        {
            HashSet<BigInteger> powers = new HashSet<BigInteger>();

            for (int i = 2; i <= 100; i++)
            {
                for (int j = 2; j <= 100; j++)
                {
                    BigInteger power = BigInteger.Pow(i, j);
                    powers.Add(power);
                }
            }

            return powers.Count;
        }
    }
}
