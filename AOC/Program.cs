using System;
using DayLibrary;

namespace AoC
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            var yearNo = -1;
            while (yearNo != 0 && yearNo !=2016 && yearNo !=2017)
            {
                Console.Write("Enter AoC year (2016, 2017 or 0 to exit): ");
                if (int.TryParse(Console.ReadLine(), out yearNo))
                {
                    if (yearNo == 0)
                        return;
                }
                else
                {
                    yearNo = -1;
                }
            }
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Advent of Code Year " + yearNo);
            Console.WriteLine("------------------------------");
            var dayNo = -1;
            while (dayNo != 0)
            {
                Console.Write("Enter day to run (0 to exit): ");
                if (!int.TryParse(Console.ReadLine(), out dayNo) || dayNo < 0)
                {
                    Console.WriteLine("Invalid selection");
                    continue;
                }
                if (dayNo == 0)
                    break;
                try
                {
                    var handle = Activator.CreateInstance("DayLibrary", $"DayLibrary.AoC{yearNo}Day{dayNo:00}");
                    var day = (DayBase) handle.Unwrap();
                    var input = WebHelper.GetInput(yearNo, dayNo);
                    Console.WriteLine();
                    Console.WriteLine("Part 1");
                    var t = DateTime.Now;
                    Console.WriteLine(day.Part1(input) + " (Time Elapsed : " + (DateTime.Now-t).ToString(@"mm\:ss\.fff") + ")");
                    Console.WriteLine();
                    Console.WriteLine("Part 2");
                    t = DateTime.Now;
                    Console.WriteLine(day.Part2(input) + " (Time Elapsed : " + (DateTime.Now - t).ToString(@"mm\:ss\.fff") + ")");
                    Console.WriteLine();
                }
                catch (TypeLoadException)
                {
                    Console.WriteLine("Day not found");
                }
            }

        }
    }
}
