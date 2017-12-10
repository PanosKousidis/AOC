using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayLibrary
{
    public class AoC2017Day10 : DayBase
    {

        public override string Part1(string input)
        {
            return Part1(input, 256);
        }
        public override string Part2(string input)
        {
            return Part2(input, 256);
        }

        public override string Part1(string input, object args)
        {
            var arr = Enumerable.Range(0, int.Parse(args.ToString())).ToArray();
            var commands = input.Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            arr = GetSparseHash(arr, commands, 1);
            return (arr[0]*arr[1]).ToString();
        }
       
        public override string Part2(string input, object args)
        {
            var arr = Enumerable.Range(0, int.Parse(args.ToString())).ToArray();
            var commands = GetAsciiArray(input);
            commands = commands.Concat(new [] {17, 31, 73, 47, 23}).ToArray();
            arr = GetSparseHash(arr, commands, 64);
            arr = GetDenseHash(arr);
            return GetHexValue(arr);
        }


        private static int[] GetAsciiArray(string input)
        {
            var arr = new int[input.Length];
            for (var i = 0; i < input.Length; i++)
            {
                arr[i] = input[i];
            }
            return arr;
        }

        private static int[] GetSparseHash(int[] arr, IReadOnlyList<int> commands, int rounds)
        {
            var currentIndex = 0;
            var skip = 0;
            for (var round = 0; round < rounds; round++)
            {

                for (var iteration = 0; iteration < commands.Count; iteration++, skip++)
                {
                    var currentLength = commands[iteration];
                    for (var i = 0; i < currentLength / 2; i++)
                    {
                        var temp = arr[(currentIndex + i) % arr.Length];
                        arr[(currentIndex + i) % arr.Length] = arr[(currentIndex + currentLength - 1 - i) % arr.Length];
                        arr[(currentIndex + currentLength - 1 - i) % arr.Length] = temp;
                    }
                    currentIndex += currentLength + skip;
                }
            }
            return arr;
        }

        private static int[] GetDenseHash(IReadOnlyList<int> arr)
        {
            var ret = new List<int>();
            for (var i = 0; i < arr.Count; i+=16)
            {
                var x = arr[i] ^ arr[i + 1] ^ arr[i + 2] ^ arr[i + 3] ^ arr[i + 4] ^ arr[i + 5] ^ arr[i + 6] ^
                        arr[i + 7] ^ arr[i + 8] ^ arr[i + 9] ^ arr[i + 10] ^ arr[i + 11] ^ arr[i + 12] ^ arr[i + 13] ^
                        arr[i + 14] ^ arr[i + 15];
                ret.Add(x);
            }
            return ret.ToArray();
        }

        private static string GetHexValue(IReadOnlyList<int> arr)
        {
            var ret = new StringBuilder();
            for (var i = 0; i < arr.Count; i++)
            {
                ret.Append(arr[i].ToString("X").PadLeft(2,'0'));
            }
            return ret.ToString().ToLower();
        }

       
    }
}