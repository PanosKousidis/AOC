using System;
using AoC;
using DayLibrary;

namespace DayLibraryTests
{
    public class Program
    {
        private const int Year = 2017;
        private const int Day = 7;


        [STAThread]
        public static void Main()
        {
            var input = WebHelper.GetInput(Year, Day);
            var handle = Activator.CreateInstance("DayLibrary", $"DayLibrary.AoC{Year}Day{Day:00}");
            var cDay = (DayBase)handle.Unwrap();

            var part1Solution = cDay.Part1(input);
            Console.WriteLine($"Part 1 Solution : {part1Solution}");
            AskPartSubmission(1, part1Solution);
            var part2Solution = cDay.Part2(input);
            Console.WriteLine($"Part 2 Solution : {part2Solution}");
            AskPartSubmission(2, part2Solution);
            Console.ReadLine();
        }

        private static void AskPartSubmission(int part, string solution)
        {
            string k = null;
            while (k != "y" && k != "n")
            {
                Console.Write($"Submit Part {part} Solution? [Y/N] : ");
                k = Console.ReadKey().KeyChar.ToString().ToLower();
                Console.WriteLine();
            }
            if (k != "y") return;

            Console.WriteLine("Submitting answer...");
            WebHelper.SubmitAnswer(Year, Day, solution, part);
        }
    }
}