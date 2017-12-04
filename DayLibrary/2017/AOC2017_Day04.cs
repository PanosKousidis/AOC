using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using Common.Enum;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AOC2017_Day04 : DayBase
    {
        private readonly string _commonInput = Resources.AOC2017_Day04_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;
        protected override void Part1(string input)
        {
            Console.WriteLine(Part1Result(input));
        }

        protected static int Part1Result(string input)
        {
            var sum = 0;
            foreach (var line in input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
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
            return sum;
        }


        protected override void Part2(string input)
        {
            Console.WriteLine(Part2Result(input));
        }

        protected static int Part2Result(string input)
        {
            var sum = 0;
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
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
            return sum;
        }
     
    }

   
}
