using System;
using System.Linq;
using Common.Enum;
using Common.Extensions;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2016_Day02 : DayBase
    {
        private readonly string _input = Resources.AOC2016_Day02_Input;
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
            var keypad = ("1 2 3\r\n" +
                          "4 5 6\r\n" +
                          "7 8 9").StringTo2ArrayOfArrays(" ").InvertArray();
            var p = new MovingPersonIn2D
            {
                LocationX = 1,
                LocationY = 1,
                InvalidDestinationString = "#",
                Map = keypad
            };
            var retVal = "";
            foreach (var line in input.Split(new [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var order in line)
                {
                    p.Move(ParseCardinal(order.ToString()));
                }
                retVal += p.MapValue;
            }
            return retVal;
        }

        private static ECardinals ParseCardinal(string s)
        {
            switch (s)
            {
                case "U": return ECardinals.Up;
                case "D": return ECardinals.Down;
                case "L": return ECardinals.Left;
                case "R": return ECardinals.Right;
                default: throw new NotSupportedException();
            }
        }
        protected override void Part2(string input)
        {
            var p = Part2Result(input);
            Console.WriteLine(p);
        }
        protected static string Part2Result(string input)
        {
            var keypad = ("# # 1 # #\r\n" +
                         "# 2 3 4 #\r\n" +
                         "5 6 7 8 9\r\n" +
                         "# A B C #\r\n" +
                         "# # D # #").StringTo2ArrayOfArrays(" ").InvertArray();
            var p = new MovingPersonIn2D
            {
                LocationX = 0,
                LocationY = 2,
                InvalidDestinationString = "#",
                Map = keypad
            };

            var retVal = "";
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (var order in line)
                {
                    p.Move(ParseCardinal(order.ToString()));
                }
                retVal += p.MapValue;
            }
            return retVal;

        }

        private static ETurnOrders ParseTurnOrders(string s)
        {
            var i = s.Count(c => c == 'R') - s.Count(c => c == 'L');
            if (i >= 0) i = i % 4;
            else i = 4 + i % -4;
            switch (i)
            {
                case 0:
                    return ETurnOrders.NoTurn;
                case 1:
                    return ETurnOrders.Right;
                case 2:
                    return ETurnOrders.Back;
                case 3:
                    return ETurnOrders.Left;
                default:
                    throw new Exception("Unable to find turn");
            }
        }
        private static int ParseSteps(string s)
        {
            s = s.Replace("R", "").Replace("L", "");
            return int.Parse(s);
        }
    }
}
