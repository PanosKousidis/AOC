using Common.Extensions;
using System;
using System.Collections.Generic;

namespace DayLibrary
{
    public class AoC2017Day04 : DayBase
    {
        public override string Part1(string input, object args)
        {
            var sum = 0;
            foreach (var line in input.Lines())
            {
                var h = new HashSet<string>();
                var isValid = true;
                foreach (var word in line.Split(' '))
                {
                    if (h.Contains(word))
                    {
                        isValid = false;
                        break;
                    }
                    h.Add(word);
                }
                sum += isValid ? 1 : 0;
            }
            return sum.ToString();
        }

        public override string Part2(string input, object args)
        {
            var sum = 0;
            foreach (var line in input.Lines())
            {
                var h = new HashSet<string>();
                var isValid = true;
                foreach (var word in line.Split(' '))
                {
                    var cArr = word.ToCharArray();
                    Array.Sort(cArr);
                    var word2 = new string(cArr);
                    if (h.Contains(word2))
                    {
                        isValid = false;
                        break;
                    }
                    h.Add(word2);
                }
                sum += isValid ? 1 : 0;
            }
            return sum.ToString();
        }
    }

   
}
