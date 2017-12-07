using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace DayLibrary
{
    public class AoC2017Day07 : DayBase
    {
        public override string Part1(string input)
        {
            var programs = ParsePrograms(input);

            foreach (var program in programs)
            {
                foreach (var p in program.Value.SubPrograms)
                {
                    var childP = programs[p];
                    program.Value.Children.Add(childP);
                    childP.Parent = program.Value;
                }
            }
            return programs.Values.First(program => program.Parent==null).Name;
        }

        public override string Part2(string input)
        {
            var programs = ParsePrograms(input);

            foreach (var program in programs)
            {
                foreach (var p in program.Value.SubPrograms)
                {
                    var childP = programs[p];
                    program.Value.Children.Add(childP);
                    childP.Parent = program.Value;
                }
            }
            return programs.Values.FirstOrDefault(p2 => p2.IsLastProblematic).CorrectWeight.ToString();
        }

        private static Dictionary<string, Program> ParsePrograms(string input)
        {
            var lines = input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            return lines.Select(ParseProgramLine).ToDictionary(p => p.Name);
        }

        private static Program ParseProgramLine(string inputLine)
        {
            const string regex = "(\\w*)\\s\\((\\d*)\\)(?:\\s->)*([\\s,\\w]*)";

            var m = new Regex(regex).Match(inputLine);
            var p = new Program
            {
                Name = m.Groups[1].Value,
                Weight = int.Parse(m.Groups[2].Value),
                SubPrograms = m.Groups[3].Value.Replace(" ","").Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).ToList()
            };
            return p;
        }
    }

   public class Program
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<string> SubPrograms { get; set; } = new List<string>();
        public Program Parent { get; set; }
        public List<Program> Children { get; set; } = new List<Program>();
        private int TowerWeight => Children.Sum(program => program.TowerWeight) + Weight;
        private int CorrectChildrenTowerWeight => Children.Count > 1 ? Children.OrderBy(p => p.TowerWeight).ToArray()[1].TowerWeight : TowerWeight;
        public bool IsProblematic => Parent.CorrectChildrenTowerWeight != TowerWeight;
        public bool IsLastProblematic => Children.All(p => !p.IsProblematic) && IsProblematic;
        public int CorrectWeight => IsLastProblematic? Weight - (TowerWeight - Parent.CorrectChildrenTowerWeight) : Weight;
        public override string ToString()
        {
            return Name + "(" + TowerWeight + ")";
        }
    }
}