using System;
using System.Linq;
using System.Text;
using Common.Extensions;
using Common.Helpers;

namespace DayLibrary
{
    public class AoC2016Day03 : DayBase
    {
        public override string Part1(string input)
        {
            var iPossible = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => line.Split(new[] {" ", "\r\n"}, StringSplitOptions.RemoveEmptyEntries))
                .Select(dim => new Triangle(int.Parse(dim[0]), int.Parse(dim[1]), int.Parse(dim[2])))
                .Count(t => t.IsPossible());
            return iPossible.ToString();
        }

        public override string Part2(string input)
        {
            var iPossible = 0;
            var linesRead = 0;
            var trianglesInput = new StringBuilder();
            foreach (var line in input.Lines())
            {
                linesRead++;
                trianglesInput.AppendLine(line);
                if (linesRead != 3) continue;
                var dim = trianglesInput.ToString().Split(new[] { " ", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < 3; i++)
                {
                    var t = new Triangle(int.Parse(dim[i]), int.Parse(dim[i + 3]), int.Parse(dim[i + 6]));
                    if (t.IsPossible()) iPossible++;
                }
                linesRead = 0;
                trianglesInput.Clear();
            }
            return iPossible.ToString();
        }
    }
}
