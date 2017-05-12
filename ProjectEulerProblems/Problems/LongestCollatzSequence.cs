using System;
using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class LongestCollatzSequence : IProblem
    {
        public int ProblemId { get { return 14; } }

        public double GetSolution()
        {
            int maxStart = 0;
            int maxCount = 0;
            int startingNumber = 1;
            Dictionary<int, int> startingNumbersWithSequenceLengths = new Dictionary<int, int>();
            for (int i = startingNumber; i < 1000000; i++)
            {
                GetSequenceLengthForStartingNumber(i, startingNumbersWithSequenceLengths, ref maxStart, ref maxCount);
            }

            return maxStart;
        }

        private void GetSequenceLengthForStartingNumber(int startingNumber, Dictionary<int, int> startingNumbersWithSequenceLengths, ref int maxStart, ref int maxCount)
        {
            int counter = 1;
            long nextNumber = startingNumber;
            while (nextNumber != 1)
            {
                nextNumber = GetNextNumber(nextNumber);
                if (nextNumber < Int32.MaxValue && startingNumbersWithSequenceLengths.ContainsKey((int)nextNumber))
                {
                    counter += startingNumbersWithSequenceLengths[(int)nextNumber];
                    break;
                }
                if (nextNumber == 1)
                {
                    break;
                }
                counter++;
            }

            if (counter > maxCount)
            {
                maxStart = startingNumber;
                maxCount = counter;
            }
            startingNumbersWithSequenceLengths.Add(startingNumber, counter);
        }

        private long GetNextNumber(long number)
        {
            if ((number & 1) == 0)
            {
                return number / 2;
            }
            else
            {
                return (3 * number) + 1;
            }
        }
    }
}
