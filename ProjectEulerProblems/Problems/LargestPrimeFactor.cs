using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class LargestPrimeFactor : IProblem
    {
        public int ProblemId
        {
            get { return 3; }
        }

        public double GetSolution()
        {
            const long TheNumber = 600851475143;
            HashSet<long> primeFactors = GetPrimeFactors(TheNumber);
            return primeFactors.Max();
        }

        private HashSet<long> GetPrimeFactors(long number)
        {
            HashSet<long> primeFactors = new HashSet<long>();

            long factor = number;
            for (long i = 2; i < (long) Math.Ceiling(Math.Sqrt(number)); i++)
            {
                while (factor % i == 0)
                {
                    primeFactors.Add(i);
                    factor /= i;
                }
            }

            if (factor != 1)
            {
                //remaining factor is greater than sqrt(n) and must be prime
                primeFactors.Add(factor);
            }
            return primeFactors;
        }
    }
}
