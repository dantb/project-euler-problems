using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class NumberSpiralDiagonals : IProblem
    {
        public int ProblemId
        {
            get { return 28; }
        }

        public double GetSolution()
        {
            /* Picture looks like this
             * 
              21 22 23 24 25
              20 7  8  9  10
              19 6  1  2  11
              18 5  4  3  12
              17 16 15 14 13

            Can see that the upper right diagonal are formed of every other square
            Then each of the other 3 corners are that square minus 1, 2 and 3 multiples of
            one less than the square root 
            ie. 25 - (1 * (root(25) - 1)), 25 - (2 * (root(25) - 1)), 25 - (3 * (root(25) - 1))

            */
            long sum = 1;
            HashSet<long> squares = new HashSet<long>();

            //remember to skip a square each time
            int i = 3;
            while (i <= 1001)
            {
                squares.Add(i * i);
                i += 2;
            }

            foreach (var square in squares)
            {
                sum += square;
                long increment = (long) (Math.Sqrt(square) - 1);
                sum += square - increment;
                sum += square - (increment * 2);
                sum += square - (increment * 3);
            }

            return sum;
        }
    }
}
