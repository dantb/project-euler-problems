using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class MultiplesOfThreeAndFive : IProblem
    {
        public int ProblemId 
        {
            get { return 1; }
        }

        public double GetSolution()
        {
            double answer = 0;
            HashSet<int> multiples = new HashSet<int>();
            int x = 3, y = 5;

            for (int i = 1; i <= (1000 - (1000 % x)) / x; i++)
            {
                multiples.Add(i * x);
            }

            for (int i = 1; i <= (1000 - (1000 % y)) / y; i++)
            {
                multiples.Add(i * y);
            }

            if (multiples.Contains(1000))
            {
                //strictly less than 1000
                multiples.Remove(1000);
            }

            answer = multiples.Sum();
            return answer;
        }
    }
}
