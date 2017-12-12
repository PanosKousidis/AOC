using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day12 : DayBase
    {
        
        public override string Part1(string input)
        {
            var dic = ParseInput(input);
            var connections = new HashSet<int>();
            GetConnections(0,dic,ref connections);
            return connections.Count.ToString();
        }

        public override string Part2(string input)
        {
            var dic = ParseInput(input);
            var groups = 0;
            while (dic.Count > 0)
            {
                var c = new HashSet<int>();
                GetConnections(dic.First().Key, dic, ref c);
                foreach (var a in c)
                {
                    dic.Remove(a);
                }
                groups++;
            }
            return groups.ToString();
        }

        private static Dictionary<int,List<int>> ParseInput(string input)
        {
            var dic = new Dictionary<int,List<int>>();
            foreach (var line in input.Split(new [] {"\r\n"},StringSplitOptions.RemoveEmptyEntries))
            {
                var m = Regex.Match(line, "(\\d+)\\s<->\\s([\\d\\s,]*)");
                var id = int.Parse(m.Groups[1].Value);
                var connections = m.Groups[2].Value.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                dic.Add(id,connections);
            }
            return dic;
        }

        private static void GetConnections(int id, IReadOnlyDictionary<int, List<int>> dic, ref HashSet<int> connections)
        {
            connections.Add(id);
            foreach (var c in dic[id])
            {
                if (connections.Add(c))
                {
                    GetConnections(c, dic, ref connections);
                }
            }
        }
    }
}