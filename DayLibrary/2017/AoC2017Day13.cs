using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day13 : DayBase
    {
        public override string Part1(string input, object args)
        {
            var scanners = GetScanners(input);
            var max = scanners.Max(scanner => scanner.Depth);
            var score = 0;

            for (var i = 0; i <= max; i++)
            {
                var scanner2 = scanners.FirstOrDefault(s => s.Depth == i);
                if (scanner2 != null && scanner2.Index == 0)
                {
                    score += scanner2.Depth * scanner2.Range;
                }
                foreach (var scanner in scanners)
                {
                    scanner.Move();
                }
            }
            return score.ToString();
        }

        public override string Part2(string input, object args)
        {
            var time = 0;
            var scanners = GetScanners(input);
            var max = scanners.Max(scanner => scanner.Depth);
            var movers = new Dictionary<int, int>();

            for (; ; time++)
            {
                movers.Add(time, 0);
                var moversCopy = movers.ToList();
                foreach (var m in moversCopy)
                {
                    var scanner2 = scanners.FirstOrDefault(s => s.Depth == m.Value);
                    if (scanner2 != null && scanner2.Index == 0)
                    {
                        movers.Remove(m.Key);
                        continue;
                    }
                    movers[m.Key]++;
                    if (movers.ContainsKey(m.Key) && m.Value == max)
                        return (m.Key).ToString();
                }
                MoveScanners(scanners, 1);
            }
        }

        private static Scanner[] GetScanners(string input)
        {
            return input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(line => Regex.Match(line, "(\\d*):\\s(\\d*)"))
                .Select(match => new Scanner {  Range = int.Parse(match.Groups[2].Value),
                                                Depth = int.Parse(match.Groups[1].Value)
                                             })
                .ToArray();
        }
        
        private static void MoveScanners(Scanner[] scanners,int repeat)
        {
            for (var i = 0; i < repeat; i++)
            {
                foreach (var s in scanners) s.Move();
            }
        }
    }

    public class Scanner
    {
        public int Depth { get; set; } = -1;
        public int Index { get; private set; }
        public int Range { get; set; } = -1;
        private bool GoingDown { get; set; } = true;

        public void Move()
        {
            if (Range==-1) return;

            if (GoingDown)
            {
                Index++;
                if (Index == Range - 1) GoingDown = false;
            }
            else
            {
                Index--;
                if (Index == 0) GoingDown = true;
            }
        }
    }
}