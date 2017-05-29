using System.Numerics;

namespace ProjectEulerProblems
{
    public class FactorialDigitSum : IProblem
    {
        public int ProblemId { get { return 20; } }

        public double GetSolution()
        {
            double sum = 0;
            BigInteger factorial = 1;

            for (int i = 2; i <= 100; i++)
            {
                factorial *= i;
            }

            foreach (char num in factorial.ToString())
            {
                sum += int.Parse(num.ToString());
            }

            return sum;
        }
    }
}
