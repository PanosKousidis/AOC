using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day05 : DayBase
    {

        public override string Part1(string input, object args)
        {
            var pass = new StringBuilder("");

            for (var i = 0; pass.Length < 8; i++)
            {
                var h = CalculateMD5Hash(input + i);
                if (h.StartsWith("00000"))
                {
                    var c = h.Substring(5, 1);
                    pass.Append(c);
                    
                }
            }
            return pass.ToString();
        }


        public override string Part2(string input, object args)
        {
            var pass = new StringBuilder("________");
            var found = 0;
            for (var i = 0; found < 8; i++)
            {
                var h = CalculateMD5Hash(input + i);
                if (h.StartsWith("00000"))
                {
                    var b = int.TryParse(h.Substring(5, 1), out var res);
                    if (b && res >= 0 && res <= 7)
                    {
                        var c = h.Substring(6, 1)[0];
                        if (pass[res] == '_')
                        {
                            pass[res] = c;
                            found++;
                        }
                    }
                }
            }
            return pass.ToString();
        }

        public static string CalculateMD5Hash(string input)

        {
            // step 1, calculate MD5 hash from input
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }


    }
}
