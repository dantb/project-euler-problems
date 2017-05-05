using System;

namespace ProjectEulerProblems
{
    public class SumSquareDifference : IProblem
    {
        public int ProblemId { get { return 6; } }

        public double GetSolution()
        {
            double answer = 0;
            for (int i = 1; i <= 100; i++)
            {
                for (int j = i + 1; j <= 100; j++)
                {
                    answer += 2 * i * j;
                }
            }

            return answer;
        }
    }
}
