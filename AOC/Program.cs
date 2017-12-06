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
        private const string Year = "2016";
        //private const string Year = "2017";

        private static void Main()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("   Advent of Code Year " + Year);
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
                    var handle = Activator.CreateInstance("DayLibrary", $"DayLibrary.AoC{Year}Day{dayNo:00}");
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
