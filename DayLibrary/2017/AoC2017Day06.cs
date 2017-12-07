using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2017Day06 : DayBase
    {
        public override string Part1(string input)
        {
            var banks = input.Split(new[] { "\t" }, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).ToArray();
            return GetResult(banks).Item2.ToString();
        }

        public override string Part2(string input)
        {
            return Part2Result(input).ToString();
        }

        protected static int Part2Result(string input)
        {
            var banks = input.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).ToArray();
            var iCount = 0;
            for (var rep = 0; rep < 2; rep++)
            {
                (banks, iCount) = GetResult(banks);
            }
            return iCount;
        }

        private static Tuple<int[], int> GetResult(int[] input)
        {
            var iCount = 0;
            var hashSet = new HashSet<int[]> { input.ToArray() };

            while (true)
            {
                iCount++;
                var iArr = input.GetIndexWithMaxValue(); //Start with max
                var values = input[iArr]; //store the number in the array
                input[iArr] = 0; //zero out the number in the array

                //distribute the values in other banks
                for (var i = 1; i <= values; i++)
                {
                    input[(iArr + i) % input.Length]++;
                }

                //check if final arrangement has been seen before, and if so exit loop
                if(hashSet.Any(ints => ints.SequenceEqual(input))) break;

                //add to Seen values
                hashSet.Add(input.ToArray());
            }
            return new Tuple<int[], int>(input, iCount);
        }
    }
}
