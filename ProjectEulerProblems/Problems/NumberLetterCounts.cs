using System.Collections.Generic;
using static ProjectEulerProblems.NumberLetterCounts.WordMaps;

namespace ProjectEulerProblems
{
    public class NumberLetterCounts : IProblem
    {
        public int ProblemId { get { return 17; } }

        public double GetSolution()
        {
            long sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                NumberAsWords number = new NumberAsWords(i);
                sum += number.ToString().Length;
            }

            return sum;
        }

        public class NumberAsWords
        {
            private string _wordRepresentation = string.Empty;

            public NumberAsWords(int theNumber)
            {
                string asString = theNumber.ToString();
                if (asString.Length == 1)
                {
                    _wordRepresentation = NumbersWithWords[asString];
                }
                else if (asString.Length == 2)
                {
                    _wordRepresentation = theNumber < 20 || theNumber % 10 == 0 ?
                        NumbersWithWords[asString] :
                        TenAndSinglePart(asString);
                }
                else if (asString.Length == 3)
                {
                    string lowerParts = string.Empty;
                    int tenPartNumber = theNumber % 100;
                    //If divisible by 100 exactly leave as empty
                    if (tenPartNumber != 0)
                    {
                        lowerParts = tenPartNumber < 20 || tenPartNumber % 10 == 0 ?
                            NumbersWithWords[tenPartNumber.ToString()] :
                            TenAndSinglePart(asString.Substring(1));
                    }
                    _wordRepresentation = string.Concat(
                        NumbersWithWords[asString[0].ToString()],
                        Hundred,
                        lowerParts == string.Empty ? string.Empty : And,
                        lowerParts);
                }
                else
                {
                    _wordRepresentation = OneThousand;
                }
            }

            public override string ToString()
            {
                return _wordRepresentation;
            }

            private string TenAndSinglePart(string number)
            {
                string singlePart = number[1].ToString();
                string tenPart = number[0] + "0";
                return string.Concat(
                    NumbersWithWords[tenPart],
                    NumbersWithWords[singlePart]);
            }
        }

        public static class WordMaps
        {
            public static Dictionary<string, string> NumbersWithWords = new Dictionary<string, string>()
            {
                { "1", "one" },
                { "2", "two" },
                { "3", "three" },
                { "4", "four" },
                { "5", "five" },
                { "6", "six" },
                { "7", "seven" },
                { "8", "eight" },
                { "9", "nine" },
                { "10", "ten" },
                { "11", "eleven" },
                { "12", "twelve" },
                { "13", "thirteen" },
                { "14", "fourteen" },
                { "15", "fifteen" },
                { "16", "sixteen" },
                { "17", "seventeen" },
                { "18", "eighteen" },
                { "19", "nineteen" },
                { "20", "twenty" },
                { "30", "thirty" },
                { "40", "forty" },
                { "50", "fifty" },
                { "60", "sixty" },
                { "70", "seventy" },
                { "80", "eighty" },
                { "90", "ninety" },
            };

            public const string Hundred = "hundred";
            public const string And = "and";
            public const string OneThousand = "onethousand";
        }
    }
}
