using System;

namespace TaskCalculatorProblem
{
    public class TaskEndDateCalculator
    {
        private readonly TimeSpan lunchTimeStart = new TimeSpan(12, 0, 0);
        private readonly TimeSpan lunchTimeEnd = new TimeSpan(13, 0, 0);

        private readonly TimeSpan workDayEnds = new TimeSpan(17, 0, 0);
        private readonly TimeSpan workDayBegins = new TimeSpan(8, 0, 0);

        private readonly double MinutesInADay = 1440;
        private readonly int YearsOfHolidays = 6;

        private HolidayChecker holidayChecker;

        public DateTime GetEndDate(DateTime start, double minutes)
        {
            holidayChecker = new HolidayChecker(start.Year, YearsOfHolidays);
            var endDate = InitializeEndDate(start);

            while (minutes > 0)
            {
                AdjustForNonWorkDays(ref endDate);
                AdjustForWorkDay(ref endDate);

                minutes = WorkOnTask(minutes, ref endDate);
            }

            return endDate;
        }

        /// <summary>
        /// Initializes a new EndDate that rounds the minute up if seconds are present.
        /// </summary>
        /// <param name="dateTime">A start date.</param>
        /// <returns></returns>
        private DateTime InitializeEndDate(DateTime dateTime) => new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Second > 0 ? dateTime.Minute + 1 : dateTime.Minute, 0);

        /// <summary>
        /// Advances day to the next work day.
        /// </summary>
        /// <param name="day">A given day.</param>
        private void AdjustForNonWorkDays(ref DateTime day)
        {
            while (IsSaturday(day.DayOfWeek) || IsSunday(day.DayOfWeek) || IsHoliday(day))
            {
                day = AdvanceToNextDay(day);
            }
        }

        /// <summary>
        /// Advances time in work day to next session of work.
        /// </summary>
        /// <param name="workDay">A given work day.</param>
        private void AdjustForWorkDay(ref DateTime workDay)
        {
            if (IsDuringLunch(workDay.TimeOfDay))
            {
                workDay = workDay.Add(lunchTimeEnd.Subtract(workDay.TimeOfDay));
            }
            else
            {
                if (IsAfterWorkDay(workDay.TimeOfDay))
                {
                    workDay = new DateTime(workDay.Year, workDay.Month, workDay.Day, 0, 0, 0).AddDays(1);

                    AdjustForNonWorkDays(ref workDay);
                }

                if (IsBeforeWorkDay(workDay.TimeOfDay))
                {
                    workDay = workDay.Add(workDayBegins.Subtract(workDay.TimeOfDay));
                }
            }
        }

        private bool IsDuringLunch(TimeSpan timeOfDay) => timeOfDay >= lunchTimeStart && timeOfDay <= lunchTimeEnd;
        private bool IsDuringMorning(TimeSpan timeOfDay) => timeOfDay >= workDayBegins && timeOfDay <= lunchTimeStart;
        private bool IsAfterWorkDay(TimeSpan timeOfDay) => timeOfDay >= workDayEnds;
        private bool IsBeforeWorkDay(TimeSpan timeOfDay) => timeOfDay <= workDayBegins;
        private bool IsSaturday(DayOfWeek day) => DayOfWeek.Saturday.Equals(day);
        private bool IsSunday(DayOfWeek day) => DayOfWeek.Sunday.Equals(day);
        private bool IsHoliday(DateTime day) => holidayChecker.IsHoliday(day);
        private DateTime AdvanceToNextDay(DateTime day) => day.AddMinutes(MinutesInADay - day.TimeOfDay.TotalMinutes);

        /// <summary>
        /// Calculates the available time to work on a task and applies it to the work day.
        /// </summary>
        /// <param name="taskMinutes">Minutes left in the task.</param>
        /// <param name="workDay">A given work day.</param>
        /// <returns>Remaining minutes in task.</returns>
        private double WorkOnTask(double taskMinutes, ref DateTime workDay)
        {
            var availableTime = GetAvailableTimeToWork(workDay);

            var minutesOfWork = taskMinutes - availableTime > 0 ? availableTime : taskMinutes;
            workDay = workDay.AddMinutes(minutesOfWork);

            return taskMinutes - minutesOfWork;
        }

        /// <param name="workDay">A given work day.</param>
        /// <returns>A amount of time in minutes available to work. </returns>
        private double GetAvailableTimeToWork(DateTime workDay)
        {
            var stopWorking = IsDuringMorning(workDay.TimeOfDay) ? lunchTimeStart : workDayEnds;
            return stopWorking.Subtract(workDay.TimeOfDay).TotalMinutes;
        }
    }
}
