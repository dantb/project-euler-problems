using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEulerProblems
{
    public class EasyProblemManager
    {
        public List<IProblem> EasyProblems = new List<IProblem>
        {
            new MultiplesOfThreeAndFive()
        };

        public class MultiplesOfThreeAndFive : IProblem
        {
            public string Description
            {
                get
                {
                    return "Find the sum of all the multiples of 3 or 5 below 1000.";
                }
            }

            public int ProblemId
            {
                get
                {
                    return 1;
                }
            }

            public string Title
            {
                get
                {
                    return "Multiples of 3 and 5";
                }
            }

            public double GetSolution()
            {
                double answer = 0;
                HashSet<int> multiples = new HashSet<int>();
                int x = 3, y = 5;

                for (int i = 1; i <= (1000 - (1000 % x))/x; i++)
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
}