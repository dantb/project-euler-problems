using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEulerProblems
{
    public static class ProblemManager
    {
        public static List<IProblem> Problems = new List<IProblem>
        {
            new MultiplesOfThreeAndFive(),
            new EvenFibonacciNumbers(),
            new LargestPrimeFactor()
        };       
    }
}