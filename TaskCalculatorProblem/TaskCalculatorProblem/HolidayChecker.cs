using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskCalculatorProblem
{
    public class HolidayChecker
    {
        private readonly List<DateTime> Holidays = new List<DateTime>();
        private readonly int[] DaysTillMonday = { 1, 0, 6, 5, 4, 3, 2 };    // Sunday to Saturday week array of days till Monday
        private readonly int[] DaysTillThursday = { 4, 3, 2, 1, 0, 6, 5 };  // Sunday to Saturday week array of days till Thursday

        /// <summary>
        /// Generates holidays for the given years so that it can determine if a given day is a holiday.
        /// </summary>
        /// <param name="startYear">The starting year to begin generating holidays.</param>
        /// <param name="howManyYears">How many years of holidays to generate.</param>
        public HolidayChecker(int startYear, int howManyYears)
        {
            for (int years = 0; years < howManyYears; years++)
            {
                var year = startYear + years;

                Holidays.Add(GetNewYears(year));
                Holidays.Add(GetFourthOfJuly(year));
                Holidays.Add(GetChristmas(year));
                Holidays.Add(GetMemorialDay(year));
                Holidays.Add(GetLaborDay(year));
                Holidays.Add(GetThanksgiving(year));
            }
        }

        private DateTime GetNewYears(int year) => new DateTime(year, 1, 1);

        private DateTime GetFourthOfJuly(int year) => new DateTime(year, 7, 4);

        private DateTime GetChristmas(int year) => new DateTime(year, 12, 25);

        // last Monday of May
        private DateTime GetMemorialDay(int year)
        {
            var lastWeekOfMay = new DateTime(year, 5, 25);
            return lastWeekOfMay.AddDays(DaysTillMonday[(int)lastWeekOfMay.DayOfWeek]);
        }

        // first Monday in September
        private DateTime GetLaborDay(int year)
        {
            var startOfSeptember = new DateTime(year, 9, 1);
            return startOfSeptember.AddDays(DaysTillMonday[(int)startOfSeptember.DayOfWeek]);
        }

        //fourth Thursday of November
        private DateTime GetThanksgiving(int year)
        {
            var fourthWeekOfNovember = new DateTime(year, 11, 22);
            return fourthWeekOfNovember.AddDays(DaysTillThursday[(int)fourthWeekOfNovember.DayOfWeek]);
        }

        public bool IsHoliday(DateTime date) => Holidays.Where(holiday => holiday.Year == date.Year).Any(holiday => holiday.DayOfYear == date.DayOfYear);
    }
}
