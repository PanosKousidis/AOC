using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;
using Common.Helpers;
using DayLibrary.Properties;

namespace DayLibrary
{
    public class AoC2016Day04 : DayBase
    {
        private readonly string _input = Resources.AoC2016_Day04_Input;
        protected override string InputPart1 => _input;
        protected override string InputPart2 => _input;
        protected override void Part1(string input)
        {
            var p = Part1Result(input);
            Console.WriteLine(p);
        }

        protected static int Part1Result(string input)
        {
            return input.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(Room.CreateRoom).Where(room => room.IsReal).Sum(room => room.SectorId);
        }

        protected override void Part2(string input)
        {
            var p = Part2Result(input);
            Console.WriteLine(p);
        }
        protected static int Part2Result(string input)
        {
            var realRoomSectorIds = 0;

            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                var room = Room.CreateRoom(line);
                if (!room.IsReal) continue;
                realRoomSectorIds += room.SectorId;
                var decryptedName = room.DecryptedName;
                if (decryptedName.ToLower().Contains("north"))
                {
                    return room.SectorId;
                }
            }
            return 0;
        }

        private class Room
        {
            private string EncryptedName { get; set; }
            private string HashCode { get; set; }
            public int SectorId { get; set; }

            public static Room CreateRoom(string code)
            {
                var r = new Regex("\\[(.*?)\\]");
                var hashCode = r.Match(code).Groups[1].Value;
                r = new Regex("-([0-9]+)");
                var sectorId = r.Match(code).Groups[1].Value;
                r = new Regex("(.*)-");
                var encryptedName = r.Match(code).Groups[1].Value;
                return new Room()
                {
                    EncryptedName = encryptedName,
                    HashCode = hashCode,
                    SectorId = int.Parse(sectorId),
                };
            }

            private string GenerateHash()
            {
                var dictionary = new Dictionary<char, int>();
                foreach (var c in EncryptedName.Replace("-", ""))
                {
                    if (dictionary.ContainsKey(c))
                    {
                        dictionary[c]++;
                    }
                    else
                    {
                        dictionary.Add(c, 1);
                    }
                }
                dictionary = dictionary.OrderByDescending(x => x.Value).ThenBy(x => x.Key)
                    .ToDictionary(x => x.Key, x => x.Value);
                var ret = string.Join("", dictionary.Keys).Substring(0, 5);
                return ret;
            }

            public bool IsReal => HashCode == GenerateHash();

            public string DecryptedName
            {
                get
                {
                    var decryptedText = new StringBuilder();
                    foreach (var c in EncryptedName)
                    {
                        if (c == '-')
                        {
                            decryptedText.Append(" ");
                            continue;
                        }
                        decryptedText.Append(Alphabet.Shift(c, SectorId));
                    }
                    return decryptedText.ToString();
                }
            }
            private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        }



    }
}
