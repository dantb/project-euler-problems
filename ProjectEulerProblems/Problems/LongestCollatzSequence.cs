using System.Collections;
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
            BitArray bits = new BitArray(10000001);
            Dictionary<long, int> startingNumbersWithSequenceLengths = new Dictionary<long, int>();
            for (int i = startingNumber; i < 1000000; i++)
            {
                if (!bits[i])
                {
                    int length = GetSequenceLengthForStartingNumber(i, startingNumbersWithSequenceLengths, maxCount, bits);
                    if (length > maxCount)
                    {
                        maxStart = i;
                        maxCount = length;
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (!bits[i])
                {
                    count++;
                }
            }

            return maxStart;
        }

        private int GetSequenceLengthForStartingNumber(int startingNumber, Dictionary<long, int> startingNumbersWithSequenceLengths, int maxCount, BitArray bits)
        {
            int counter = 1;
            long nextNumber = startingNumber;
            while (nextNumber != 1)
            {
                bool evenNumber;
                nextNumber = GetNextNumber(nextNumber, out evenNumber);
                if (nextNumber < 1000000)
                {
                    if (evenNumber)
                    {
                        //we got to next number by dividing by 2, try to look through the other route
                        int tempCount = 0;

                    }
                    bits[(int) nextNumber] = true;
                }

                if (startingNumbersWithSequenceLengths.ContainsKey(nextNumber))
                {
                    counter += startingNumbersWithSequenceLengths[(int) nextNumber];
                    break;
                }
                
                if (nextNumber == 1)
                {
                    break;
                }
                counter++;
            }

            startingNumbersWithSequenceLengths.Add(startingNumber, counter);
            return counter;
        }

        private long GetNextNumber(long number, out bool evenNumber)
        {
            if ((number & 1) == 0)
            {
                evenNumber = true;
                return number / 2;
            }
            else
            {
                evenNumber = false;
                return (3 * number) + 1;
            }
        }
    }
}
