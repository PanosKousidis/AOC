using System.Collections.Generic;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2017Day02: DayBase
    {

        public override string Part1(string input)
        {
            return CalcCheckSumMinMax(input.StringTo2ArrayOfArrays("\t")).ToString();
        }
        public override string Part2(string input)
        {
            return CalcCheckSumMod(input.StringTo2ArrayOfArrays("\t")).ToString();
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
