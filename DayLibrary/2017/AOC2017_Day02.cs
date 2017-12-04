using System;
using System.Collections.Generic;
using Common.Extensions;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AoC2017Day02: DayBase
    {
        private readonly string _commonInput = Resources.AoC2017_Day02_Input;
        protected override string InputPart1 => _commonInput;
        protected override string InputPart2 => _commonInput;

        protected override void Part1(string input)
        {
            var arr = input.StringTo2ArrayOfArrays("\t");
            Console.WriteLine(CalcCheckSumMinMax(arr));
        }
        protected override void Part2(string input)
        {
            var arr = input.StringTo2ArrayOfArrays("\t");
            Console.WriteLine(CalcCheckSumMod(arr));
        }

        protected static int CalcCheckSumMinMax(IEnumerable<IEnumerable<string>> arr)
        {
            var sum = 0;
            foreach (var t in arr)
            {
                var max = 0;
                var min = int.MaxValue;
                foreach (var t1 in t)
                {
                    var no = int.Parse(t1);
                    if (no > max) max = no;
                    if (no < min) min = no;
                }
                sum += max - min;
            }
            return sum;
        }
        protected static int CalcCheckSumMod(IEnumerable<string[]> arr)
        {
            var sum = 0;

            foreach (var t in arr)
            {
                var max = 0;
                var min = 0;
                for (var j1 = 0; j1 < t.Length; j1++)
                {
                    for (var j2 = 0; j2 < t.Length; j2++)
                    {
                        if (j1 == j2) continue;
                        var no1 = int.Parse(t[j1]);
                        var no2 = int.Parse(t[j2]);
                        var mod = no1 % no2;
                        if (mod != 0 || no2 == 0) continue;
                        max = no1;
                        min = no2;
                        break;
                    }
                }
                sum += max / min;
            }
            return sum;
        }

    }

   
}
