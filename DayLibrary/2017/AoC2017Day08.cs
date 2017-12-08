using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace DayLibrary
{
    public class AoC2017Day08 : DayBase
    {
        public override string Part1(string input)
        {
            const string regex = "(\\w*)\\s(\\w*)\\s([-]*\\d*)\\sif\\s(\\w*)\\s([<>=!]*)\\s([-]*\\d*)";
            foreach (var line in input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                var r = new Regex(regex);
                var m = r.Match(input);

            }

            
            return null;
        }

        public void Execute(string register, string command, int commandvalue, string register2, string op,
            int conditionvalue)
        {
            
        }

        public override string Part2(string input)
        {
            return null;
        }
    }
}