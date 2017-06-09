using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public static class ProblemManager
    {
        public static List<IProblem> Problems = new List<IProblem>
        {
            new MultiplesOfThreeAndFive(),
            new EvenFibonacciNumbers(),
            new LargestPrimeFactor(),
            new LargestPalindromeProduct(),
            new SmallestMultiple(),
            new SumSquareDifference(),
            new NthPrimeCalculator(),
            new LargestProductInSeries(),
            new SpecialPythagoreanTriplet(),
            new SummationOfPrimes(),
            new LargestProductInGrid(),
            //new HighlyDivisibleTriangularNumber()
            new LongestCollatzSequence(),
            new PowerDigitSum(),
            new NumberLetterCounts(),
            new CountingSundays(),
            new FactorialDigitSum(),
            new DistinctPowers(),
            new NumberSpiralDiagonals(),
            new DigitFifthPowers()
        };
    }
}