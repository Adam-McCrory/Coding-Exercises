using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskCalculatorProblem;

namespace TaskCalculatorProblem_Test
{
    [TestClass]
    public class TaskEndDateCalculatorTest
    {
        [TestMethod]
        public void GetEndDateCanHandleZeroMinuteTask()
        {
            var minutes = 0;
            var start = new DateTime(2020, 1, 1);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(start.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleAYearLongTask()
        {
            var minutes = 525600; //minutes in a non-leap year
            var start = new DateTime(2021, 1, 4, 8, 20, 0);
            var end = new DateTime(2025, 4, 11, 8, 20, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleWeekends()
        {
            var minutes = 5;
            var start = new DateTime(2020, 12, 11, 16, 59, 0);
            var end = new DateTime(2020, 12, 14, 8, 4, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleHolidays()
        {
            var minutes = 10;
            var start = new DateTime(2019, 12, 31, 16, 58, 0);
            var end = new DateTime(2020, 1, 2, 8, 8, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleLunchBreaks()
        {
            var minutes = 32;
            var start = new DateTime(2020, 12, 1, 11, 55, 0);
            var end = new DateTime(2020, 12, 1, 13, 27, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleOffWorkHours()
        {
            var minutes = 61;
            var start = new DateTime(2020, 12, 1, 16, 30, 0);
            var end = new DateTime(2020, 12, 2, 8, 31, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedOnSaturday()
        {
            var minutes = 12;
            var start = new DateTime(2020, 12, 12, 11, 20, 0);
            var end = new DateTime(2020, 12, 14, 8, 12, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedOnSunday()
        {
            var minutes = 22;
            var start = new DateTime(2020, 12, 13, 18, 31, 0);
            var end = new DateTime(2020, 12, 14, 8, 22, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedOnAHoliday()
        {
            var minutes = 45;
            var start = new DateTime(2020, 11, 26, 6, 3, 0);    //Thanksgiving
            var end = new DateTime(2020, 11, 27, 8, 45, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedDuringLunch()
        {
            var minutes = 18;
            var start = new DateTime(2020, 12, 3, 12, 10, 0);
            var end = new DateTime(2020, 12, 3, 13, 18, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedAfterWork()
        {
            var minutes = 27;
            var start = new DateTime(2020, 12, 3, 18, 12, 0);
            var end = new DateTime(2020, 12, 4, 8, 27, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }

        [TestMethod]
        public void GetEndDateCanHandleTaskStartedBeforeWork()
        {
            var minutes = 52;
            var start = new DateTime(2020, 12, 3, 6, 44, 0);
            var end = new DateTime(2020, 12, 3, 8, 52, 0);

            var sut = new TaskEndDateCalculator();

            var endDate = sut.GetEndDate(start, minutes);

            Assert.IsTrue(end.Equals(endDate));
        }
    }
}
