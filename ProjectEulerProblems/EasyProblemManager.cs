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
                return 0;
            }
        }
    }
}