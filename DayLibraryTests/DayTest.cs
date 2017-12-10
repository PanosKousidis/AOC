using System;
using System.Text.RegularExpressions;
using AoC;
using DayLibrary;

namespace DayLibraryTests
{
    public abstract class DayTest
    {
        private const string Reg = "AoC(\\d*)Day(\\d*)";
        private int Year => int.Parse(Regex.Match(GetType().Name, Reg).Groups[1].Value);
        private int Day => int.Parse(Regex.Match(GetType().Name, Reg).Groups[2].Value);
        private DayBase ThisDay => (DayBase)Activator.CreateInstance("DayLibrary", $"DayLibrary.AoC{Year}Day{Day:00}").Unwrap();

        protected string TestPart1(string input, object args = null)
        {
            if (input == null)
            {
                input = WebHelper.GetInput(Year, Day);
            }
            return args == null ? ThisDay.Part1(input) : ThisDay.Part1(input, args);
        }

        protected string TestPart2(string input, object args = null)
        {
            if (input == null)
            {
                input = WebHelper.GetInput(Year, Day);
            }
            return args == null ? ThisDay.Part2(input) : ThisDay.Part2(input, args);
        }
    }
}