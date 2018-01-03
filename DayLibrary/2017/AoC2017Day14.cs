using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace DayLibrary
{
    public class AoC2017Day14 : DayBase
    {

        public override string Part1(string input, object args)
        {
            var count = 0;

            for (var i = 0; i < 128; i++)
            {
                var key = input + "-" + i;
                var h = AoC2017Day10.GetKnotHash(key);
                string binarystring = string.Join(string.Empty, h.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
                count += binarystring.Count(c => c == '1');
            }
            return count.ToString();

        }
        public override string Part2(string input, object args)
        {

            var map = new StringBuilder();
            for (var i = 0; i < 128; i++)
            {
                var key = input + "-" + i;
                var h = AoC2017Day10.GetKnotHash(key);
                map.AppendLine(string.Join(string.Empty, h.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0'))));
            }

            var arr = Common.Extensions.ArrayHelper.StringTo2ArrayOfArrays(map.ToString(), "");
            var dic = new Dictionary<Point, int>();
            var region = 1;
            for (var y = 0; y < 128; y++)
            {
                for (var x = 0; x < 128; x++)
                {
                    var p = new Point(x, y);
                    if (arr[y][x] == "0" || dic.ContainsKey(p)) continue;
                    AddSelfAndNeighbours(ref dic, arr, p, region);
                    region++;
                }

            }
            return (region - 1).ToString();
        }

        private void AddSelfAndNeighbours(ref Dictionary<Point, int> dic, string[][] arr, Point p, int region)
        {
            if (dic.ContainsKey(p)) return;

            dic.Add(p, region);

            if (p.Y > 0 && arr[p.Y - 1][p.X] == "1")
                AddSelfAndNeighbours(ref dic, arr, new Point(p.X, p.Y - 1), region);
            if (p.X > 0 && arr[p.Y][p.X - 1] == "1")
                AddSelfAndNeighbours(ref dic, arr, new Point(p.X - 1, p.Y), region);
            if (p.X < 127 && arr[p.Y][p.X + 1] == "1")
                AddSelfAndNeighbours(ref dic, arr, new Point(p.X + 1, p.Y), region);
            if (p.Y < 127 && arr[p.Y + 1][p.X] == "1")
                AddSelfAndNeighbours(ref dic, arr, new Point(p.X, p.Y + 1), region);
        }
    }
}