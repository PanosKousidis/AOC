using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Common.Extensions
{
    public static class ArrayHelper
    {
        public static string[][] StringTo2ArrayOfArrays(this string input, string columnDelimiter)
        {
            var lines = input.Lines();

            var ret = new string[lines.Length][];
            for (var i = 0; i < lines.Length; i++)
            {
                var columns = columnDelimiter=="" ? lines[i].ToCharArray().Select(c=> c.ToString()).ToArray() : lines[i].Split(new[] { columnDelimiter }, StringSplitOptions.RemoveEmptyEntries).ToArray();
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
            var ret = new string[inputArr[0].Length, inputArr.Length];

            for (var y = 0; y < inputArr.Length; y++)
            {
                for (var x = 0; x < inputArr[0].Length; x++)
                {
                     ret[x, inputArr.GetUpperBound(0) - y] = inputArr[y][x];
                }
            }
            return ret;
        }

        public static Dictionary<Point,object> ToDictionaryOfPointObject(this string[][] arr)
        {
            var dic = new Dictionary<Point, object>();
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[i].Length; j++)
                {
                    dic.Add(new Point(i,j),arr[i][j]);
                }
            }
            return dic;
        }
        public static Dictionary<Point, object> ToDictionaryOfPointObject(this string[,] arr)
        {
            var dic = new Dictionary<Point, object>();
            for (var i = 0; i <= arr.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= arr.GetUpperBound(1); j++)
                {
                    dic.Add(new Point(i, j), arr[i,j]);
                }
            }
            return dic;
        }

        public static char Shift(this string word, char c, int n)
        {
            return word[(word.IndexOf(c) + n) % word.Length];
        }
        public static char[] Shift(this char[] arr, int number)
        {
            var arr2 = new char[arr.Length];
            for(var i = 0; i<arr.Length;i++)
            {
                arr2[i] = arr[(arr.Length - number + i) % arr.Length];
            }
            return arr2;
        }

        public static int GetIndexWithMaxValue(this int[] e)
        {
            var max = 0;
            var index = 0;

            for (var i = 0; i < e.Length; i++)
            {
                if (e[i] <= max) continue;
                max = e[i];
                index = i;
            }
            return index;
        } 
    }

}
