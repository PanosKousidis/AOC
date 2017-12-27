using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DayLibrary
{
    public class AoC2017Day21 : DayBase
    {
        const string Start = @".#.
..#
###";
        public override string Part1(string input, object args)
        {
            var rules = new List<FractalRule>();
            input.Lines().Select(FractalRule.Parse).ToList().ForEach(x => rules.AddRange(x));
            
            var f = new Fractal() { Value = Start };
            for (var i = 0; i < (int)args; i++)
            {
                f.Divide(rules);
            }
            return f.Value.Count(x => x == '#').ToString();
        }

        public override string Part2(string input, object args)
        {
            return null;
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
                    input = Rotate(input);
                }
            }
            else
            {
                s = new string[4];
                for (var i = 0; i < 4; i ++)
                {
                    s[i] = input;
                    input = Rotate(input);
                }
            }
            return s;
        }

        private static string Rotate(string input)
        {
            //var parts = input.Split('/');
            //var newparts = new string[parts.Length, parts.Length];
            //for (var j = 0; j < parts.Length; j++)
            //{
            //    for (var i = 0; i < parts[j].Length; i++)
            //    {
            //        newparts[parts.Length - 1 - j, i] += parts[j][i];
            //    }
            //}
            return null;
        }
        private static string Flip(string input)
        {
            return null;
        }
    }
    public class Fractal
    {
        public string Value { get; set; }
        public List<Fractal> Divide(IEnumerable<FractalRule> r)
        {
            return null;
        }
    }
}