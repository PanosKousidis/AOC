using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day12 : DayBase
    {

        public override string Part1(string input, object args)
        {
            var a = new Assembunny() { Code = input };
            a.Run();
            return a.Registers["a"].ToString();
        }

        public override string Part2(string input, object args)
        {
            var a = new Assembunny() { Code = input };
            a.Registers["c"] = 1;
            a.Run();
            return a.Registers["a"].ToString();
        }
    }

    public class Assembunny
    {
        public string Code { get; set; }
        public Dictionary<string, int> Registers { get; set; } = new Dictionary<string, int>();
        int _currentLine;

        public void Run()
        {
            _currentLine = 0;
            var commands = Code.Lines();
            while (_currentLine < commands.Length)
            {
                var command = commands[_currentLine].Split(' ');
                switch (command[0])
                {
                    case "cpy":
                        Cpy(command[1], command[2]);
                        break;
                    case "inc":
                        Inc(command[1]);
                        break;
                    case "dec":
                        Dec(command[1]);
                        break;
                    case "jnz":
                        Jnz(command[1], int.Parse(command[2]));
                        break;
                    default: throw new NotSupportedException();
                }
                _currentLine++;
            }
        }

        public Assembunny()
        {
            Registers.Add("a", 0);
            Registers.Add("b", 0);
            Registers.Add("c", 0);
            Registers.Add("d", 0);
        }
        public void Cpy(string source, string destination)
        {
            if (!int.TryParse(source, out int no))
            {
                no = Registers[source];
            }
            Registers[destination] = no;
        }
        public void Inc(string register)
        {
            Registers[register]++;
        }
        public void Dec(string register)
        {
            Registers[register]--;
        }
        public void Jnz(string register, int move)
        {
            if (!int.TryParse(register, out int no))
            {
                no = Registers[register];
            }
            if (no != 0) _currentLine += move - 1;
        }

    }

}