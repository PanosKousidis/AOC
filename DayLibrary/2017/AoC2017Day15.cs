

using System;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day15 : DayBase
    {
        private const long FactorA = 16807;
        private const long FactorB = 48271;
        private const long Dividor = 2147483647;

        public override string Part1(string input)
        {
            return Part1(input, 40000000);
        }

        public override string Part2(string input)
        {
            return Part2(input, 5000000);
        }

        public override string Part1(string input, object args)
        {
            var reps = (int)args;
            var a = long.Parse(Regex.Match(input.Split(new[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries)[0], "(\\d+)").Groups[1].Value);
            var b = long.Parse(Regex.Match(input.Split(new[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries)[1], "(\\d+)").Groups[1].Value);
            var count = 0;
            for (var i = 0; i<reps; i++)
            {
                a = (a * FactorA) % Dividor;
                b = (b * FactorB) % Dividor;
                var binA = Convert.ToString(a, 2).PadRight(16, '0');
                var binB = Convert.ToString(b, 2).PadRight(16, '0');
                if ( binA.Substring(binA.Length-16) == binB.Substring(binB.Length-16))
                    count++;
            }

            return count.ToString();

        }
       
        public override string Part2(string input, object args)
        {
            var reps = (int)args;
            var a = long.Parse(Regex.Match(input.Split(new[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries)[0], "(\\d+)").Groups[1].Value);
            var b = long.Parse(Regex.Match(input.Split(new[] { "\r\n" }, System.StringSplitOptions.RemoveEmptyEntries)[1], "(\\d+)").Groups[1].Value);
            var count = 0;
            for (var i = 0; i < reps; i++)
            {
                do
                {
                    a = (a * FactorA) % Dividor;
                } while (a % 4 != 0);
                do
                {
                    b = (b * FactorB) % Dividor;
                } while (b % 8 != 0);
                var binA = Convert.ToString(a, 2).PadRight(16, '0');
                var binB = Convert.ToString(b, 2).PadRight(16, '0');
                if (binA.Substring(binA.Length - 16) == binB.Substring(binB.Length - 16))
                    count++;
            }

            return count.ToString();

        }
    }
}