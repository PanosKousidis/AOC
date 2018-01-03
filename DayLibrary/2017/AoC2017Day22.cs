using Common.Extensions;
using Common.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace DayLibrary
{
    public class AoC2017Day22 : DayBase
    {

        public override string Part1(string input)
        {
            return Part1(input, 10000);
        }
        private Dictionary<Point, object> ParseMap(string input)
        {
            var ret = new Dictionary<Point, object>();

            for (var y = input.Lines().Length / 2; y >= -input.Lines().Length / 2; y--)
            {
                for (var x = -input.Lines()[0].Length / 2; x <= input.Lines()[0].Length / 2; x++)
                {
                    ret.Add(new Point(x, y), input.Lines()[(input.Lines().Length / 2) - y][x + input.Lines()[0].Length / 2]);
                }
            }
            return ret;
        }
        public override string Part2(string input)
        {
            return Part2(input, 10000000);
        }

        public override string Part1(string input, object args)
        {
            var m = new MovingIn2D()
            {
                Face = Common.Enum.ECardinals.Up,
                Map = ParseMap(input),
                DefaultMapValue = "."
            };

            var infectCount = 0;
            for (var i = 0; i < (int)args; i++)
            {
                if (m.MapValue == ".") {
                    m.Turn(Common.Enum.ETurnOrders.Left);
                    m.MapValue = "#";
                    infectCount++;
                    m.MoveForward(1, false, true);
                }
                else if (m.MapValue == "#")
                {
                    m.Turn(Common.Enum.ETurnOrders.Right);
                    m.MapValue = ".";
                    m.MoveForward(1, false, true);
                }
            }
            return infectCount.ToString();
        }

        public override string Part2(string input, object args)
        {
            var m = new MovingIn2D()
            {
                Face = Common.Enum.ECardinals.Up,
                Map = ParseMap(input),
                DefaultMapValue = "."
            };

            var infectCount = 0;
            for (var i = 0; i < (int)args; i++)
            {
                if (m.MapValue == ".")
                {
                    m.Turn(Common.Enum.ETurnOrders.Left);
                    m.MapValue = "W";
                    m.MoveForward(1, false, true);
                }
                else if (m.MapValue == "#")
                {
                    m.Turn(Common.Enum.ETurnOrders.Right);
                    m.MapValue = "F";
                    m.MoveForward(1, false, true);
                }
                else if (m.MapValue == "F")
                {
                    m.Turn(Common.Enum.ETurnOrders.Back);
                    m.MapValue = ".";
                    m.MoveForward(1, false, true);
                }
                else if (m.MapValue == "W")
                {
                    m.Turn(Common.Enum.ETurnOrders.NoTurn);
                    infectCount++;
                    m.MapValue = "#";
                    m.MoveForward(1, false, true);
                }
            }
            return infectCount.ToString();
        }
    }
}