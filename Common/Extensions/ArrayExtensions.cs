using System;
using System.Collections.Generic;
using System.Linq;
using Common.Enum;

namespace Common.Extensions
{
    public static class ArrayHelper
    {
        public static string[][] StringTo2ArrayOfArrays(this string input, string columnDelimiter)
        {
            var lines = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            var ret = new string[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var columns = lines[i].Split(new[] { columnDelimiter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                ret[i] = new string[columns.Length];
                for (var j = 0; j < columns.Length; j++)
                {
                    ret[i][j] = columns[j];
                }
            }
            return ret;
        }

        public static string[,] InvertArray(this string[][] inputArr)
        {
            var ret = new string[inputArr.Length, inputArr.Length];

            for (var i = 0; i < inputArr.Length; i++)
            {
                for (var j = 0; j < inputArr[i].Length; j++)
                {
                    ret[j, inputArr.GetUpperBound(0) - i] = inputArr[i][j];
                }
            }
            return ret;
        }
      
    }
}
