using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day06 : DayBase
    {
        
        public override string Part1(string input, object args)
        {
            var dict = GetDict(input);
            var phrase = new StringBuilder();
            for (var i = 0; i < dict.Count; i++)
            {
                phrase.Append(dict[i].OrderByDescending(x => x.Value).FirstOrDefault().Key); //Step 1
            }
            return phrase.ToString();
        }

        public override string Part2(string input, object args)
        {
            var dict = GetDict(input);
            var phrase = new StringBuilder();
            for (var i = 0; i < dict.Count; i++)
            {
                phrase.Append(dict[i].OrderBy(x => x.Value).FirstOrDefault().Key);
            }
            return phrase.ToString();
        }
       
        public static Dictionary<int, Dictionary<char, int>> GetDict(string input)
        {
            var dict = new Dictionary<int, Dictionary<char, int>>();
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                for (var i = 0; i <= line.Length - 1; i++)
                {
                    if (!dict.ContainsKey(i)) dict.Add(i, new Dictionary<char, int>());
                    if (!dict[i].ContainsKey(line[i])) dict[i].Add(line[i], 0);
                    dict[i][line[i]]++;
                }
            }
            return dict;
        }
    }
}
