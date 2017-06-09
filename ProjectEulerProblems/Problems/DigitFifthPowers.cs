using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class DigitFifthPowers : IProblem
    {
        public int ProblemId { get { return 30; } }

        public double GetSolution()
        {
            Dictionary<char, long> fifthPowers = new Dictionary<char, long>();
            for (int i = 0; i < 10; i++)
            {
                fifthPowers.Add(i.ToString()[0], (long) Math.Pow(i, 5));
            }

            HashSet<long> fifthDigitNumbers = new HashSet<long>();
            for (int i = 2; i < 1000000; i++)
            {
                string asString = i.ToString();
                long sum = 0;
                foreach (char ch in asString)
                {
                    sum += fifthPowers[ch];
                }
                if (sum == i)
                {
                    fifthDigitNumbers.Add(i);
                }
            }

            long fifthDigitNumbersSum = fifthDigitNumbers.Sum();

            return fifthDigitNumbersSum;
        }
    }
}
