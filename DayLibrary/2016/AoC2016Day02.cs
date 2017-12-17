using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Common.Enum;
using Common.Extensions;
using Common.Helpers;

namespace DayLibrary
{
    public class AoC2016Day02 : DayBase
    {
        
        public override string Part1(string input)
        {
            var keypad = ("1 2 3\r\n" +
              "4 5 6\r\n" +
              "7 8 9").StringTo2ArrayOfArrays(" ").InvertArray().ToDictionaryOfPointObject();
            return Part1(input, keypad);
        }

        public override string Part1(string input, object args)
        {
            var p = new MovingIn2D
            {
                LocationX = 1,
                LocationY = 1,
                InvalidDestinationString = "#",
                Map = (Dictionary<Point,object>)args
            };
            var retVal = new StringBuilder();

            foreach (var line in input.Lines())
            {
                foreach (var order in line)
                {
                    p.Move(ParseCardinal(order.ToString()), 1, false, false);
                }
                retVal.Append(p.MapValue);
            }
            return retVal.ToString();
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

        public override string Part2(string input, object args)
        {
            var p = new MovingIn2D
            {
                LocationX = 0,
                LocationY = 2,
                InvalidDestinationString = "#",
                Map = (Dictionary<Point, object>)args
            };

            var retVal = new StringBuilder();
            foreach (var line in input.Lines())
            {
                foreach (var order in line)
                {
                    p.Move(ParseCardinal(order.ToString()), 1, false, false);
                }
                retVal.Append(p.MapValue);
            }
            return retVal.ToString();
        }

        public override string Part2(string input)
        {
            var keypad = ("# # 1 # #\r\n" +
                         "# 2 3 4 #\r\n" +
                         "5 6 7 8 9\r\n" +
                         "# A B C #\r\n" +
                         "# # D # #").StringTo2ArrayOfArrays(" ").InvertArray().ToDictionaryOfPointObject();
            return Part2(input, keypad);
        }
    }
}
