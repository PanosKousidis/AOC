using System;
using System.Text;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AoC2016Day03 : DayBase
    {
        private readonly string _input = Resources.AoC2016_Day03_Input;
        protected override string InputPart1 => _input;
        protected override string InputPart2 => _input;
       // private bool _bDone;
        protected override void Part1(string input)
        {
            var p = Part1Result(input);
            Console.WriteLine(p);
        }

        protected static int Part1Result(string input)
        {
            var iPossible = 0;
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var dim = line.Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                var t = new Triangle(int.Parse(dim[0]), int.Parse(dim[1]), int.Parse(dim[2]));
                if (t.IsPossible()) iPossible++;
            }
            return iPossible;
        }

        protected override void Part2(string input)
        {
            var p = Part2Result(input);
            Console.WriteLine(p);
        }
        protected static int Part2Result(string input)
        {
            var iPossible = 0;
            var linesRead = 0;
            var trianglesInput = new StringBuilder();
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                linesRead++;
                trianglesInput.AppendLine(line);
                if (linesRead != 3) continue;
                var dim = trianglesInput.ToString().Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < 3; i++)
                {
                    var t = new Triangle(int.Parse(dim[i]), int.Parse(dim[i+3]), int.Parse(dim[i+6]));
                    if (t.IsPossible()) iPossible++;
                }
                linesRead = 0;
                trianglesInput.Clear();
            }
            return iPossible;
        }

    }
}
