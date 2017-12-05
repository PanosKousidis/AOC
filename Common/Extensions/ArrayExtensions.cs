﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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

    }

}
