using System.Collections.Generic;

namespace ProjectEulerProblems
{
    public class CountingSundays : IProblem
    {
        public int ProblemId { get { return 19; } }

        public double GetSolution()
        {
            long days = 0;

            Year year1900 = new Year(Day.Monday, 1900);
            year1900.NumberOfSundaysOnFirstOfMonth();

            //Get first day of 1901
            Day firstDay = year1900.FirstDayOfNextYear;
            for (int year = 1901; year < 2001; year++)
            {
                Year theYear = new Year(firstDay, year);
                days += theYear.NumberOfSundaysOnFirstOfMonth();
                //update first day to be the first day of the next year
                firstDay = theYear.FirstDayOfNextYear;
            }

            return days;
        }

        public class Year
        {
            private Day _firstDay;
            private bool _leapYear;
            private int _daysInYear;
            private readonly List<int> DaysInMonths = new List<int>()
            {
                31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
            };

            public Year(Day firstDay, int theYear)
            {
                _firstDay = firstDay;
                if (theYear % 4 == 0)
                {
                    if (theYear % 100 == 0)
                    {
                        _leapYear = theYear % 400 == 0 ? true : false;
                    }
                    else
                    {
                        _leapYear = true;
                    }
                }
                if (_leapYear)
                {
                    DaysInMonths[1] = 29;
                    _daysInYear = 366;
                }
                else
                {
                    _daysInYear = 365;
                }
            }

            public Day FirstDayOfNextYear;

            public int NumberOfSundaysOnFirstOfMonth()
            {
                int count = 0;
                int dayCount = 1;
                Day firstSunday = _firstDay;
                if (_firstDay != Day.Sunday)
                {
                    int daysTilSunday = 7 - ((int) _firstDay);
                    dayCount += daysTilSunday;
                }
                else
                {
                    //remember to count january
                    count++;
                }

                int monthCount = DaysInMonths[0];
                int currentMonth = 0;
                while (dayCount < _daysInYear - 6)
                {
                    dayCount += 7;
                    if (dayCount > monthCount)
                    {
                        if (dayCount == monthCount + 1)
                        {
                            count++;
                        }
                        currentMonth++;
                        monthCount += DaysInMonths[currentMonth];
                    }
                }

                int diffFromEnd = _daysInYear - dayCount;

                FirstDayOfNextYear = (Day)(diffFromEnd + 1);

                return count;
            }
        }

        public enum Day
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 3,
            Thursday = 4,
            Friday = 5,
            Saturday = 6,
            Sunday = 7,
        }
    }
}
