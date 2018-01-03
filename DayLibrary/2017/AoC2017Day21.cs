using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayLibrary
{
    public class AoC2017Day21 : DayBase
    {
        const string Start = @".#.
..#
###";
        public override string Part1(string input)
        {
            return Part1(input, 5);
        }
        public override string Part2(string input)
        {
            return Part2(input, 18);
        }

        public override string Part1(string input, object args)
        {
            var rules = new List<FractalRule>();
            input.Lines().Select(FractalRule.Parse).ToList().ForEach(x => rules.AddRange(x));

            var f = Start.Lines().ToList();

            for (var r = 0; r < (int)args; r++)
            {
                f = BreakFractals(f, rules);
            }

            return f.Sum(x => x.Count(y => y == '#')).ToString();
        }

        public override string Part2(string input, object args)
        {
            return Part1(input, args);
        }

        public List<string> BreakFractals(List<string> lines, List<FractalRule> rules)
        {
            var newret = new List<string>();
            int div = 0;
            if (lines.Count % 2 == 0)
                div = 2;
            else
                div = 3;

            //Get in fractals horizontally
            for (var line = 0; line < lines.Count; line += div)
            {
                var newretline = newret.Count;
                //Add rows in the return
                for (var i = 0; i <= div; i++)
                    newret.Add("");


                //Get in fractal 
                for (var col = 0; col < lines.Count; col += div)
                {
                    //Get string of current fractal
                    var currentFractal = new List<string>();
                    for (var currentline = 0; currentline < div; currentline++)
                    {
                        var fRow = lines[line + currentline].Substring(col, div);
                        currentFractal.Add(fRow);
                    }

                    //match it in rules
                    var newfractal = rules.Where(x => x.Determinant == string.Join("/", currentFractal)).FirstOrDefault().Result.Split(new[] { "/" }, StringSplitOptions.RemoveEmptyEntries);


                    //add the result in the result variable
                    for (var i = 0; i < newfractal.Length; i++)
                    {
                        newret[newretline + i] += newfractal[i];
                    }
                }
            }
            return newret;
        }
    }
    public class FractalRule
    {
        public string Determinant { get; private set; }
        public string Result { get; private set; }
        public static IEnumerable<FractalRule> Parse(string input)
        {
            var parts = input.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries);
            return GetAllRotations(parts[0]).Select(x => new FractalRule() { Determinant = x, Result = parts[1] });
        }
        private static string[] GetAllRotations(string input)
        {
            string[] s = null;
            if (input.Count(x => x == '/') == 2)
            {
                s = new string[8];
                for (var i = 0; i < 8; i += 2)
                {
                    s[i] = input;
                    s[i + 1] = Flip(input);
                    input = RotateClockwise(input);
                }
            }
            else
            {
                s = new string[4];
                for (var i = 0; i < 4; i++)
                {
                    s[i] = input;
                    input = RotateClockwise(input);
                }
            }
            return s;
        }

        private static string RotateClockwise(string input)
        {
            if (input.Count(x => x == '/') == 2)
            {
                return input[8].ToString() + input[4].ToString() + input[0].ToString() + "/" +
                        input[9].ToString() + input[5].ToString() + input[1].ToString() + "/" +
                        input[10].ToString() + input[6].ToString() + input[2].ToString();
            }
            else
            {
                return input[3].ToString() + input[0].ToString() + input[2].ToString() +
                    input[4].ToString() + input[1].ToString();
            }
        }
        private static string Flip(string input)
        {
            if (input.Count(x => x == '/') == 2)
            {
                return input[2].ToString() + input[1].ToString() + input[0].ToString() + "/" +
                        input[6].ToString() + input[5].ToString() + input[4].ToString() + "/" +
                        input[10].ToString() + input[9].ToString() + input[8].ToString();
            }
            else
            {
                return input[1].ToString() + input[0].ToString() + "/" +
                    input[4].ToString() + input[3].ToString();
            }
        }
    }
}