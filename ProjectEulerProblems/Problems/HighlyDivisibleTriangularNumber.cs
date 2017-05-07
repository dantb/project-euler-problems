using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class HighlyDivisibleTriangularNumber : IProblem
    {
        public int ProblemId { get { return 12; } }

        private Dictionary<long, int> _numberWithDivisorCount = new Dictionary<long, int>();

        public double GetSolution()
        {
            List<long> triangularNumbersWeCareAbout = new List<long>();

            long rollingSum = 0;
            int i = 1;
            while (i < 500)
            {
                //any number with over 500 divisors has to be greater than 500th triangular number, so start here
                rollingSum += i;
                i++;
            }

            while (true)
            {
                rollingSum += i;
                //we care, look at divisors
                int numberOfDivisors = GetDivisorCount(rollingSum);
                if (numberOfDivisors > 500)
                {
                    break;
                }
                i++;
            }

            return rollingSum;
        }

        private int GetDivisorCount(long value)
        {
            HashSet<int> primeExponents = new HashSet<int>();
            long original = value;

            if (_numberWithDivisorCount.ContainsKey(original))
            {
                return _numberWithDivisorCount[original];
            }

            int i = 2;
            while (value != 1)
            {
                if (value % i == 0)
                {
                    int appearances = 0;
                    //calculate number of appearances of this particular prime
                    while (value % i == 0)
                    {
                        value /= i;
                        appearances++;
                        //now we have new value, check whether we remembered this
                        if (_numberWithDivisorCount.ContainsKey(value))
                        {
                            //output whatever we have already along with the divisors so far
                            primeExponents.Add(appearances);
                            int count = 1;
                            foreach (int exp in primeExponents)
                            {
                                count *= (exp + 1);
                            }
                            count *= _numberWithDivisorCount[value];
                            return count;
                        }
                    }
                    primeExponents.Add(appearances);
                }
                i++;
            }

            int divisorCount = 1;
            foreach (int exp in primeExponents)
            {
                divisorCount *= (exp + 1);
            }

            if (!_numberWithDivisorCount.ContainsKey(original))
            {
                _numberWithDivisorCount.Add(original, divisorCount);
            }

            return divisorCount;
        }
    }
}
