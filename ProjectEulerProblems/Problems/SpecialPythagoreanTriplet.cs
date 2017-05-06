using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public class SpecialPythagoreanTriplet : IProblem
    {
        public int ProblemId { get { return 9; } }

        public double GetSolution()
        {
            double product = 0;
            //try to do in one pass
            for (int i = 1; i < 999; i++)
            {
                int remainder = 1000 - i;
                int firstSquare = i * i;
                for (int j = 1; j < remainder; j++)
                {
                    int secondSquare = j * j;
                    int remainder2 = remainder - j;
                    if (remainder < 0)
                    {
                        break;
                    }
                    else
                    {
                        int thirdSquare = remainder2 * remainder2;
                        if (IsPythagoreanTriplet(firstSquare, secondSquare, thirdSquare))
                        {
                            product = i * j * remainder2;
                            return product;
                        }
                    }
                }
            }

            return 0;
        }

        private bool IsPythagoreanTriplet(int firstSquare, int secondSquare, int thirdSquare)
        {
            List<int> values = new List<int> { firstSquare, secondSquare, thirdSquare };
            int max = values.Max();
            if (firstSquare == max)
            {
                return firstSquare == secondSquare + thirdSquare;
            }
            else if (secondSquare == max)
            {
                return secondSquare == firstSquare + thirdSquare;
            }
            else
            {
                //third square max
                return thirdSquare == secondSquare + firstSquare;
            }
        }
    }
}
