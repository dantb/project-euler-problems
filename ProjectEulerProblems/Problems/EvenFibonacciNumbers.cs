using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class EvenFibonacciNumbers : IProblem
    {
        public int ProblemId
        {
            get { return 2; }
        }

        public double GetSolution()
        {
            double answer = 0;
            //intialise with 2
            HashSet<int> fibNumbers = new HashSet<int>();
            int fib1 = 1;
            int fib2 = 2;
            while (fib2 < 4000000)
            {
                if (fib2 % 2 == 0)
                {
                    fibNumbers.Add(fib2);
                }
                int temp = fib1;
                fib1 = fib2;
                //this is what will be checked against the upper bound, new highest fib
                fib2 = fib2 + temp;
            }

            return fibNumbers.Sum();
        }
    }
}
