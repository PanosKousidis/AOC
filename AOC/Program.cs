using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Reflection;
using System.Runtime.CompilerServices;
using DayLibrary;

namespace AoC
{
    internal static class Program
    {
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

                    Console.WriteLine();
                    Console.WriteLine("Part 1");
                    day.RunPart1();
                    Console.WriteLine();
                    Console.WriteLine("Part 2");
                    day.RunPart2();
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
