using System;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string[] Lines(this string s) => s.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

    }
}
