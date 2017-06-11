using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    class DigitFactorials : IProblem
    {
        public int ProblemId { get { return 34; } }

        public double GetSolution()
        {
            Dictionary<char, int> factorials = new Dictionary<char, int>()
            {
                { '0', 1 },
                { '1', 1 },
                { '2', 2 },
                { '3', 6 },
                { '4', 24 },
                { '5', 120 },
                { '6', 720 },
                { '7', 5040 },
                { '8', 40320 },
                { '9', 362880 }
            };

            HashSet<int> sumsOfDigitFactorials = new HashSet<int>();

            int max = 2177280;
            for (int i = 3; i <= max; i++)
            {
                if (i == SumOfFactorialsOfDigits(i, factorials))
                {
                    sumsOfDigitFactorials.Add(i);
                }
            }

            return sumsOfDigitFactorials.Sum();
        }

        private int SumOfFactorialsOfDigits(int i, Dictionary<char, int> factorials)
        {
            int sum = 0;
            foreach (char ch in i.ToString())
            {
                sum += factorials[ch];
            }
            return sum;
        }
    }
}
