using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography;
using Common.Enum;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2017_Day04 : DayBase
    {
        private readonly string _commonInput = Resources.AOC2017_Day04_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;
        protected override void Part1(string input)
        {
            Console.WriteLine(Part1Result(int.Parse(input)));
        }

        protected static int Part1Result(int input)
        {
            return 0;
        }


        protected override void Part2(string input)
        {
            Console.WriteLine(Part2Result(int.Parse(input)));
        }


        protected int Part2Result(int input)
        {
            return 0;
        }
     
    }

   
}
