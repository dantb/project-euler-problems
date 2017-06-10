using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    class PandigitalProducts : IProblem
    {
        private readonly HashSet<char> AllNumbersSet = new HashSet<char>("123456789");

        public int ProblemId { get { return 32; } }

        public double GetSolution()
        {
            HashSet<int> pandigitalProducts = new HashSet<int>();
            //1 digit and 4 digit products
            for (int i = 1; i < 10; i++)
            {
                for (int j = 1000; j < 9999; j++)
                {
                    int product = i * j;
                    if (product < 10000 && IsPandigital(i, j, product))
                    {
                        pandigitalProducts.Add(product);
                    }
                }
            }

            //2 digit and 3 digit
            for (int i = 10; i < 99; i++)
            {
                for (int j = 100; j < 999; j++)
                {
                    int product = i * j;
                    if (product < 10000 && IsPandigital(i, j, product))
                    {
                        pandigitalProducts.Add(product);
                    }
                }
            }

            return pandigitalProducts.Sum();
        }

        private bool IsPandigital(int first, int second, int product)
        {
            string glued = string.Concat(first, second, product);
            HashSet<char> letters = new HashSet<char>(glued);
            if (letters.SetEquals(AllNumbersSet))
            {
                return true;
            }
            return false;
        }
    }
}
