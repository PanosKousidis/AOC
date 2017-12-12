using System;
using System.Drawing;

namespace DayLibrary
{
    public class AoC2017Day11 : DayBase
    {
        private static int _furthest;

        public override string Part1(string input)
        {
            var location = GetCurrentLocation(input);
            return GetDistance(location).ToString();
        }

        public override string Part2(string input)
        {
            GetCurrentLocation(input);
            return _furthest.ToString();
        }

        private static Point GetCurrentLocation(string input)
        {
            var x = 0;
            var y = 0;
            _furthest = 0;
            var directions = input.Split(',');

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "s":
                        y -= 2;
                        break;
                    case "se":
                        y--;
                        x++;
                        break;
                    case "sw":
                        y--;
                        x--;
                        break;
                    case "n":
                        y += 2;
                        break;
                    case "ne":
                        y++;
                        x++;
                        break;
                    case "nw":
                        y++;
                        x--;
                        break;
                    default: throw new NotSupportedException();
                }
                var d = GetDistance(new Point(x, y));
                if (d > _furthest) _furthest = d;
            }
            return new Point(x,y);
        }

        private static int GetDistance(Point p)
        {
            return Math.Abs(Math.Abs(p.X) + (Math.Abs(p.Y) - Math.Abs(p.X) > 0 ? Math.Abs(p.Y) - Math.Abs(p.X) / 2 : 0));
        }

       
    }
}