using System;
using System.Linq;
using Common.Enum;
using Common.Extensions;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2016_Day03 : DayBase
    {
        private readonly string _input = Resources.AOC2016_Day03_Input;
        protected override string InputPart1 => _input;
        protected override string InputPart2 => _input;
       // private bool _bDone;
        protected override void Part1(string input)
        {
            var p = Part1Result(input);
            Console.WriteLine(p);
        }

        protected static string Part1Result(string input)
        {
           
        }

        protected override void Part2(string input)
        {
            var p = Part2Result(input);
            Console.WriteLine(p);
        }
        protected static string Part2Result(string input)
        {

        }

    }
}
