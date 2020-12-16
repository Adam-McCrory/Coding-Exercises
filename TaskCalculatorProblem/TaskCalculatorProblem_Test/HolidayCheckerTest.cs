using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaskCalculatorProblem;

namespace TaskCalculatorProblem_Test
{
    [TestClass]
    public class HolidayCheckerTest
    {
        [TestMethod]
        public void IsHolidayWillBeFalseWhenNotAHoliday()
        {
            var startYear = 2000;
            var howManyYears = 1;

            var date = new DateTime(startYear, 1, 2);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsFalse(sut.IsHoliday(date));
        }

        [TestMethod]
        public void IsHolidayWillBeFalseWhenZeroYearsAreSpecified()
        {
            var startYear = 2000;
            var howManyYears = 0;

            var date = new DateTime(startYear, 1, 1);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsFalse(sut.IsHoliday(date));
        }

        [TestMethod]
        public void IsHolidayCanHandleSingleYear()
        {
            var startYear = 2000;
            var howManyYears = 1;

            var newYears2000 = new DateTime(startYear, 1, 1);
            var newYears2001 = new DateTime(startYear + 1, 1, 1);
            var newYears1999 = new DateTime(startYear - 1, 1, 1);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(newYears2000));

            Assert.IsFalse(sut.IsHoliday(newYears2001));
            Assert.IsFalse(sut.IsHoliday(newYears1999));
        }

        [TestMethod]
        public void IsHolidayCanHandleMultipleYears()
        {
            var startYear = 2000;
            var howManyYears = 3;

            var newYears2000 = new DateTime(startYear, 1, 1);
            var newYears2001 = new DateTime(startYear + 1, 1, 1);
            var newYears2002 = new DateTime(startYear + 2, 1, 1);
            var newYears2003 = new DateTime(startYear + 3, 1, 1);
            var newYears1999 = new DateTime(startYear - 1, 1, 1);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(newYears2000));
            Assert.IsTrue(sut.IsHoliday(newYears2001));
            Assert.IsTrue(sut.IsHoliday(newYears2002));

            Assert.IsFalse(sut.IsHoliday(newYears2003));
            Assert.IsFalse(sut.IsHoliday(newYears1999));
        }

        [TestMethod]
        public void IsHolidayCanHandleNewYears()
        {
            var startYear = 2010;
            var howManyYears = 1;

            var newYears2000 = new DateTime(startYear, 1, 1);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(newYears2000));
        }

        [TestMethod]
        public void IsHolidayCanHandleFourthOfJuly()
        {
            var startYear = 2014;
            var howManyYears = 1;

            var fourthOfJuly = new DateTime(startYear, 7, 4);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(fourthOfJuly));
        }

        [TestMethod]
        public void IsHolidayCanHandleChristmas()
        {
            var startYear = 1980;
            var howManyYears = 1;

            var christmas = new DateTime(startYear, 12, 25);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(christmas));
        }

        [TestMethod]
        public void IsHolidayCanHandleMemorialDay()
        {
            var startYear = 2030;
            var howManyYears = 1;

            var memorialDay = new DateTime(startYear, 5, 27);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(memorialDay));
        }

        [TestMethod]
        public void IsHolidayCanHandleLaborDay()
        {
            var startYear = 2025;
            var howManyYears = 1;

            var laborDay = new DateTime(startYear, 9, 1);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(laborDay));
        }

        [TestMethod]
        public void IsHolidayCanHandleThanksgiving()
        {
            var startYear = 2020;
            var howManyYears = 1;

            var thanksgiving = new DateTime(startYear, 11, 26);

            var sut = new HolidayChecker(startYear, howManyYears);

            Assert.IsTrue(sut.IsHoliday(thanksgiving));
        }
    }
}
