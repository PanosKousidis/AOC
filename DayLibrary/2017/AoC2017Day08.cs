using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2017Day08 : DayBase
    {
        private readonly Dictionary<string, int> _registers = new Dictionary<string, int>();
        private int _max;

        public override string Part1(string input)
        {
            Run(input);
            return _registers.Values.Max().ToString();
        }

        public override string Part2(string input)
        {
            Run(input);
            return _max.ToString();
        }

        private void Run(string input)
        {
            const string regex = "(\\w*)\\s(\\w*)\\s([-]*\\d*)\\sif\\s(\\w*)\\s([<>=!]*)\\s([-]*\\d*)";
            foreach (var line in input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                var r = new Regex(regex);
                var m = r.Match(line);
                Execute(m.Groups[1].Value, m.Groups[2].Value, Convert.ToInt32(m.Groups[3].Value), m.Groups[4].Value,
                    m.Groups[5].Value, Convert.ToInt32(m.Groups[6].Value));
            }
        }

        private void Execute(string register, string command, int commandvalue, string register2, string op,
            int conditionvalue)
        {
            if (!_registers.ContainsKey(register))
            {
                _registers.Add(register, 0);
            }
            if (!_registers.ContainsKey(register2))
            {
                _registers.Add(register2, 0);
            }
            var eval = _registers[register2].Compare(op, conditionvalue);
            if (!eval) return;
            _registers[register] += command == "inc" ? commandvalue : -commandvalue;
            if (_registers[register] > _max) _max = _registers[register];
        }
    }
}