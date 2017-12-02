using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class ArrayHelper
    {
        public static IEnumerable<string[]> StringTo2ArrayOfArrays(this string input, string columnDelimiter)
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
    }
}
