using System;

namespace ProjectEulerProblems
{
    public class SumSquareDifference : IProblem
    {
        public int ProblemId { get { return 6; } }

        public double GetSolution()
        {
            double answer = 0;
            for (int i = 1; i <= 50; i++)
            {
                for (int j = 100; j >= 50; j--)
                {
                    answer += 2 * i * j;
                }
            }

            //get rid of extra 50 term we added
            answer -= (2 * 50 * 50);

            return answer;
        }
    }
}
