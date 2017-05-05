using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class SmallestMultiple : IProblem
    {
        public int ProblemId { get { return 5; } }

        public double GetSolution()
        {
            //calculate in general case for n, here n = 20
            int n = 20;
            long smallestMultiple = SmallestMultipleOfConsecutiveNumbersUpTo(n);
            return smallestMultiple;
        }

        private long SmallestMultipleOfConsecutiveNumbersUpTo(int n)
        {
            Dictionary<int, int> divisorsWithCounts = new Dictionary<int, int>();

            for (int i = n; i > 1; i--)
            {
                Dictionary<int, int> divisors = GetDivisorsWithCounts(i);
                foreach (var div in divisors)
                {
                    if (!divisorsWithCounts.ContainsKey(div.Key))
                    {
                        divisorsWithCounts.Add(div.Key, div.Value);
                    }
                    else
                    {
                        int diff = divisorsWithCounts[div.Key] - divisors[div.Key];
                        if (diff < 0)
                        {
                            divisorsWithCounts[div.Key] += (diff * -1);
                        }
                    }
                }
            }

            long answer = 1;
            foreach (var div in divisorsWithCounts)
            {
                answer *= (long)Math.Pow(div.Key, div.Value);
            }
            return answer;
        }

        private Dictionary<int, int> GetDivisorsWithCounts(int n)
        {
            Dictionary<int, int> divisors = new Dictionary<int, int>();

            int leftOver = n;
            int divisor = 2;
            while (leftOver != 1)
            {
                while(leftOver % divisor == 0)
                {
                    leftOver /= divisor;
                    if (!divisors.ContainsKey(divisor))
                    {
                        divisors.Add(divisor, 1);
                    }
                    else
                    {
                        divisors[divisor]++;
                    }
                }
                divisor++;
            }
            return divisors;
        }
    }
}
