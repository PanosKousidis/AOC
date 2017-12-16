using Common.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day16 : DayBase
    {

        public override string Part1(string input)
        {
            return Part1(input, null);
        }
        public override string Part2(string input)
        {
            return Part2(input, null);
        }

        public override string Part1(string input, object args)
        {
            var arr = Enumerable.Range('a', int.Parse(args.ToString())).Select(c => (char)c).ToArray();
            return Run(ref arr, input.Split(','));
        }
        private static string Run(ref char[] arr, string[] input)
        {
            foreach (string command in input)
            {

                switch (command[0])
                {
                    case 's':
                        Spin(ref arr, int.Parse(Regex.Match(command, "s(\\d+)").Groups[1].Value));
                        break;
                    case 'x':
                        Exchange(ref arr, int.Parse(Regex.Match(command, "x(\\d+)/(\\d+)").Groups[1].Value), int.Parse(Regex.Match(command, "x(\\d+)/(\\d+)").Groups[2].Value));
                        break;
                    case 'p':
                        Partner(ref arr, char.Parse(Regex.Match(command, "p(\\w+)/(\\w+)").Groups[1].Value), char.Parse(Regex.Match(command, "p(\\w+)/(\\w+)").Groups[2].Value));
                        break;
                }
            }
            return new string(arr);

        }

        public override string Part2(string input, object args)
        {
            var arr = Enumerable.Range('a', int.Parse(((int[])args)[0].ToString())).Select(c => (char)c).ToArray();
            var loopi = 0;
            var inputarr = input.Split(',');
            var res = new List<string>();
            var reps = ((int[])args)[1];
            var original = new string(Enumerable.Range('a', int.Parse(((int[])args)[0].ToString())).Select(c => (char)c).ToArray());
            for (var i =0; i< reps ; i++)
            {
                res.Add(new string(arr));
                Run(ref arr, inputarr);
                if (new string(arr) == original)
                {
                    loopi = i;
                    break;
                }
            }
            if(loopi!=0)
                return res[reps % (loopi+1)];


            return new string(arr);
        }

        private static void Spin (ref char[] arr, int no)
        {
            arr = arr.Shift(no);
        }

        private static void Exchange (ref char[] arr, int position1, int position2)
        {
            var t = arr[position1];
            arr[position1] = arr[position2];
            arr[position2] = t;
        }

        private static void Partner (ref char[] arr, char program1, char program2)
        {
            var position1 = 0;
            var position2 = 0;
            for (var i = 0; i<arr.Length;i++)
            {
                if (program1.ToString().ToLower() == arr[i].ToString().ToLower()) position1 = i;
                if (program2.ToString().ToLower() == arr[i].ToString().ToLower()) position2 = i;
            }
            Exchange(ref arr, position1, position2);
        }
    }
}