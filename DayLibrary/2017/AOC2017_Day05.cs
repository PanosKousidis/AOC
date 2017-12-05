using System;
using System.Linq;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AoC2017Day05 : DayBase
    {
        private readonly string _commonInput = Resources.AoC2017_Day05_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;
        protected override void Part1(string input)
        {
            Console.WriteLine(Part1Result(input));
        }

        protected static int Part1Result(string input)
        {
            var dic = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var currentIndex = 0;
            var currentSteps = 0;
            try
            {
                while (true)
                {
                    var tmp = currentIndex;
                    currentIndex += dic[currentIndex];
                    dic[tmp] += 1;
                    currentSteps += 1;
                }
            }
            catch (IndexOutOfRangeException)
            {
                //result found
            }
            return currentSteps;

        }

        protected override void Part2(string input)
        {
            Console.WriteLine(Part2Result(input));
        }

        protected static int Part2Result(string input)
        {
            var dic = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var currentIndex = 0;
            var currentSteps = 0;
            try
            {
                while (true)
                {
                    var tmp = currentIndex;
                    currentIndex += dic[currentIndex];
                    dic[tmp] += dic[tmp] >= 3 ? -1 : 1;
                    currentSteps += 1;
                }
            }
            catch (IndexOutOfRangeException)
            {
                //result found
            }
            return currentSteps;
        }
     
    }

   
}
