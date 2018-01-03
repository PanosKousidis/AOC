using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day09 : DayBase
    {
        
        public override string Part1(string input, object args)
        {
            var z = new ZippedFile() { ZippedString = input };
            var u = z.UnzippedStringV1;
            return u.Length.ToString();
        }

        public override string Part2(string input, object args)
        {
            var z = new ZippedFile() { ZippedString = input };
            var l = z.UnzippedStringV2Length;
            return l.ToString();
        }
       
    }


    public class ZippedFile
    {
        public string ZippedString { get; set; }
        public string UnzippedStringV1 => UnzipStringV1(ZippedString);
        public long UnzippedStringV2Length => UnzipStringV2Length(ZippedString);

        private static string UnzipStringV1(string zipped)
        {
            var index = 0;
            var str = new StringBuilder();
            while (index < zipped.Length)
            {
                if (zipped[index] == '(')
                {
                    var endofmarkerindex = zipped.IndexOf(')', index) + 1;
                    var marker = new Marker(zipped.Substring(index, endofmarkerindex - index));
                    index = endofmarkerindex;
                    for (var i = 0; i < marker.Times; i++)
                    {
                        str.Append(zipped.Substring(index, marker.Chars));
                    }
                    index += marker.Chars;
                }
                else
                {
                    str.Append(zipped[index]);
                    index++;
                }
            }
            return str.ToString();
        }

        private static long UnzipStringV2Length(string zipped)
        {
            long length = 0;
            var index = 0;
            while (index < zipped.Length)
            {
                if (zipped[index] == '(')
                {
                    var endofmarkerindex = zipped.IndexOf(')', index) + 1;
                    var marker = new Marker(zipped.Substring(index, endofmarkerindex - index));
                    index = endofmarkerindex;
                    length += marker.Times * UnzipStringV2Length(zipped.Substring(index, marker.Chars));
                    index += marker.Chars;
                }
                else
                {
                    length++;
                    index++;
                }
            }
            return length;
        }
    }
    public class Marker
    {
        public int Chars { get; }
        public int Times { get; }

        public Marker(string s)
        {
            var x = s.IndexOf('x');
            Chars = int.Parse(s.Substring(1, x - 1));
            Times = int.Parse(s.Substring(x + 1, s.Length - x - 2));

        }
    }
}
