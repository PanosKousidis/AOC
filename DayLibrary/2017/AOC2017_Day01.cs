using System;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2017_Day01:DayBase
    {
        private readonly string _commonInput = Resources.AOC2017_Day01_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;

        protected override void Part1(string input)
        {
            Console.WriteLine(CyclicSequence(input, 1));
        }

        protected override void Part2(string input)
        {
            Console.WriteLine(CyclicSequence(input, input.Length / 2));
        }
        protected static int CyclicSequence(string input, int feed)
        {
            var sum = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var firstchar = input[i];
                var j = (i + feed) % input.Length;
                var secondchar = input[j];
                if (firstchar == secondchar)
                {
                    sum += int.Parse(firstchar.ToString());
                }
            }
            return sum;
        }
    }

    
}
