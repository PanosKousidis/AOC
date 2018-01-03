using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day07 : DayBase
    {
        
        public override string Part1(string input, object args)
        {
            var supportsTls = 0;
            foreach (var line in input.Lines())
            {
                var ip7 = new Ipv7(line);
                if (ip7.SupportsTls) supportsTls++;
            }
            return supportsTls.ToString();
        }

        public override string Part2(string input, object args)
        {
            var supportsSsl = 0;
            foreach (var line in input.Lines())
            {
                var ip7 = new Ipv7(line);
                if (ip7.SupportsSsl) supportsSsl++;
            }
            return supportsSsl.ToString();
        }
       
    }

    public class Ipv7
    {
        private string[] AutonomousCodes { get; set; }
        private string[] HypernetSequences { get; set; }
        public Ipv7(string line)
        {
            var r = new Regex("\\[(.*?)\\]");
            HypernetSequences = r.Matches(line).Cast<Match>().Select(m => m.Groups[1].Value).ToArray();
            r = new Regex("\\w+(?![^[]*\\])");
            AutonomousCodes = r.Matches(line).Cast<Match>().Select(m => m.Groups[0].Value).ToArray();
        }
        public bool SupportsTls => ContainsAbba(AutonomousCodes) && !ContainsAbba(HypernetSequences);
        public bool SupportsSsl => ContainsAba(HypernetSequences, FindAbaPatterns(AutonomousCodes));

        public IEnumerable<string> FindAbaPatterns(IEnumerable<string> seqs)
        {
            var aba = new List<string>();
            foreach (var seq in seqs)
            {
                for (var i = 0; i <= seq.Length - 3; i++)
                {
                    if (seq[i] == seq[i + 2] && seq[i] != seq[i + 1]) aba.Add(seq.Substring(i, 3));
                }
            }
            return aba;
        }

        private static bool ContainsAba(IEnumerable<string> seqs, IEnumerable<string> arr)
        {
            return (from seq in seqs
                    from aba in arr
                    let bab = new string(new[] { aba[1], aba[0], aba[1] })
                    where seq.Contains(bab)
                    select seq).Any();
        }

        private static bool ContainsAbba(IEnumerable<string> arr)
        {
            foreach (var value in arr)
            {
                for (var i = 0; i <= value.Length - 4; i++)
                {
                    var checkvalue = value.Substring(i, 4);
                    if (IsAbba(checkvalue))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool IsAbba(string s)
        {
            var firstpart = s.Substring(0, s.Length / 2);
            var secondpart = new string(s.Substring(s.Length / 2).Reverse().ToArray());
            return firstpart == secondpart && firstpart[0] != firstpart[1];
        }

    }

}
