using System;
using AoC;
using DayLibrary;

namespace DayLibraryTests
{
    public class Program
    {
        public static void Main()
        {
            const int year = 2017;
            const int day = 7;

            var input = WebHelper.GetInput(year, day);

            var handle = Activator.CreateInstance("DayLibrary", $"DayLibrary.AoC{year}Day{day:00}");
            var cDay = (DayBase)handle.Unwrap();
            Console.WriteLine(cDay.Part1(input));
            Console.WriteLine(cDay.Part2(input));
            Console.ReadLine();
        }

    }
}