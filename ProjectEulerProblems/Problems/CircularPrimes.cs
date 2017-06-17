using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class CircularPrimes : IProblem
    {
        public int ProblemId
        {
            get { return 35; }
        }

        public double GetSolution()
        {
            int n = 1000000;
            int sum = 13; //below 100
            HashSet<char> evenDigits = new HashSet<char>() { '0', '2', '4', '6', '8' };

            for (int i = 100; i < n; i++)
            {
                string asString = i.ToString();
                HashSet<char> digits = new HashSet<char>(asString);
                //any even digits cannot fit criteria
                if (!digits.Overlaps(evenDigits))
                {
                    if (IsPrime(i))
                    {
                        if (IsCircularPrime(asString))
                        {
                            sum++;
                        }
                    }
                }
            }

            return sum;
        }

        private bool IsCircularPrime(string asString)
        {
            //keep shifting string
            for (int i = 0; i < asString.Length - 1; i++)
            {
                char lastChar = asString[asString.Length - 1];
                asString =
                    string.Concat(lastChar.ToString(), asString.Substring(0, asString.Length - 1));
                if (!IsPrime(int.Parse(asString)))
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
            return true;
        }
    }
}
