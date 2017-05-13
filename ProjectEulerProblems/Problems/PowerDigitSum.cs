
using System;
using System.Numerics;

namespace ProjectEulerProblems
{
    public class PowerDigitSum : IProblem
    {
        public int ProblemId { get { return 16; } }

        public double GetSolution()
        {
            BigInteger big = BigInteger.Pow(2, 1000);
            long sum = 0;

            while (big > 0)
            {
                int smallestIntegerDigit = (int) (big % 10);
                sum += smallestIntegerDigit;
                big /= 10;
            }

            return sum;
        }
    }
}
