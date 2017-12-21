using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day04 : DayBase
    {

        public override string Part1(string input)
        {
            return input.Lines()
                .Select(Room.CreateRoom).Where(room => room.IsReal).Sum(room => room.SectorId).ToString();
        }

        public override string Part2(string input)
        {
            foreach (var line in input.Lines())
            {
                var room = Room.CreateRoom(line);
                if (!room.IsReal) continue;
                var decryptedName = room.DecryptedName;
                if (decryptedName.ToLower().Contains("north"))
                {
                    return room.SectorId.ToString();
                }
            }
            return "";
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
