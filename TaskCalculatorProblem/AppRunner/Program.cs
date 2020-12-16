using System;
using TaskCalculatorProblem;

namespace AppRunner
{
    class Program
    {
        private const string DateFormat = "dddd, MMMM dd, yyyy hh:mm:ss tt";

        static void Main(string[] args)
        {
            var taskCalculator = new TaskEndDateCalculator();

            var startTime = new DateTime(2018, 1, 3, 6, 0, 0);
            var taskTime = 55;

            //var startTime = new DateTime(2018, 7, 3, 9, 0, 0);
            //var taskTime = 720;

            //var startTime = new DateTime(2018, 8, 21, 5, 0, 0);
            //var taskTime = 4800;

            var endTime = taskCalculator.GetEndDate(startTime, taskTime);

            Console.WriteLine("Start = " + startTime.ToString(DateFormat));
            Console.WriteLine("Minutes = " + taskTime);
            Console.WriteLine("Answer = " + endTime.ToString(DateFormat));
        }
    }
}
