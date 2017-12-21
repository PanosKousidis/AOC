using Common.Extensions;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day21 : DayBase
    {
        private TransformationMatrix _matrix;
        public override string Part1(string input)
        {
            return Part1(input, 5);
        }
        public override string Part2(string input)
        {
            return Part2(input, null);
        }

        public override string Part1(string input, object args)
        {
            _matrix = TransformationMatrix.Parse(input);
            var iterations = (int)args;
            var arr = new string[3, 3] { { ".", "#", "." },
                                      { ".", ".", "#" },
                                      { "#", "#", "#" } };
            for(var i = 0; i < iterations; i++)
                arr = Iterate(arr);
            return Count(arr,'#').ToString();
        }

        private string[,] Iterate(string[,] arr)
        {
            if (arr.Length % 2 == 0)
            {
                var hRes = new string[(arr.Length / 2) ^ 2, (arr.Length / 2) ^ 2];
                var vRes = new string[(arr.Length / 2) ^ 2, (arr.Length / 2) ^ 2];

                for (var y = 0; y < arr.Length ; y += 2)
                {
                    for (var x = 0; x < arr.Length; x += 2)
                    {
                        var tmp = new string[2, 2];
                        tmp[0, 0] = arr[x, y];
                        tmp[0, 1] = arr[x, y + 1];
                        tmp[1, 0] = arr[x + 1, y];
                        tmp[1, 1] = arr[x + 1, y + 1];
                        var r = _matrix.Rules[tmp];
                        hRes = hRes.CombineArrays(r, true);

                    }
                    vRes = vRes.CombineArrays(hRes, false);
                }
            }
            else
            {
                var hRes = new string[(arr.Length / 3) ^ 2, (arr.Length / 3) ^ 2];
                var vRes = new string[(arr.Length / 3) ^ 2, (arr.Length / 3) ^ 2];

                for (var y = 0; y < arr.Length; y += 3)
                {
                    for (var x = 0; x < arr.Length; x += 3)
                    {
                        var tmp = new string[3, 3];
                        tmp[0, 0] = arr[x, y];
                        tmp[0, 1] = arr[x, y + 1];
                        tmp[0, 2] = arr[x, y + 2];
                        tmp[1, 0] = arr[x + 1, y];
                        tmp[1, 1] = arr[x + 1, y + 1];
                        tmp[1, 2] = arr[x + 1, y + 2];
                        tmp[2, 0] = arr[x + 2, y];
                        tmp[2, 1] = arr[x + 2, y + 1];
                        tmp[2, 2] = arr[x + 2, y + 2];

                        var r = _matrix.Rules[tmp.ToCustomString()];
                        hRes = hRes.CombineArrays(r, true);

                    }
                    vRes = vRes.CombineArrays(hRes, false);
                }
            }



            return null;
        }

        private static int Count(string [,] arr, char c)
        {
            return 0;
        }
        public override string Part2(string input, object args)
        {
            return null;
        }
    }

    public class TransformationMatrix
    {
        public Dictionary<string[,], string[,]> Rules { get; set; } = new Dictionary<string[,], string[,]>();
        public static TransformationMatrix Parse (string input)
        {
            var matrix = new TransformationMatrix();

            foreach (var line in input.Lines())
            {
                var det = line.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries)[0];
                var res = line.Split(new[] { " => " }, StringSplitOptions.RemoveEmptyEntries)[1];
                var arr = det.StringTo2DimensionalArray("","/");
                var arrRes = res.StringTo2DimensionalArray("","/");

                matrix.Rules.Add(arr, arrRes);
                arr = arr.InvertArray();
                matrix.Rules.Add(arr, arrRes);
                arr = arr.InvertArray();
                matrix.Rules.Add(arr, arrRes);
                arr = arr.InvertArray();
                matrix.Rules.Add(arr, arrRes);
            }
            return matrix;
        }
    }
}