using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day08 : DayBase
    {
        
        public override string Part1(string input, object args)
        {
            var k = new Keypad(6, 50);
            Console.WriteLine(k.Print());
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                k.Execute(Instruction.Parse(line));
                Console.Clear();
                Console.WriteLine(k.Print());
            }
            return k.LightsLit.ToString();
        }

        public override string Part2(string input, object args)
        {
            var k = new Keypad(6, 50);
            Console.WriteLine(k.Print());
            foreach (var line in input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                k.Execute(Instruction.Parse(line));
            }
            return k.Print();
        }

    }

    public class Instruction
    {
        public InstructionTypes InstructionType { get; set; }
        public int First { get; set; }
        public int Second { get; set; }
        public enum InstructionTypes
        {
            Rect,
            RotateRow,
            RotateColumn
        }
        public static Instruction Parse(string s)
        {
            InstructionTypes type;
            var first = 0;
            var second = 0;
            var r = new Regex("^([a-z =])*");
            var m = r.Match(s).Groups[0].Value;
            switch (m)
            {
                case "rect ":
                    type = InstructionTypes.Rect;
                    r = new Regex("([0-9]*)x");
                    first = int.Parse(r.Match(s).Groups[1].Value);
                    r = new Regex("x([0-9]*)");
                    second = int.Parse(r.Match(s).Groups[1].Value);
                    break;
                case "rotate row y=":
                    type = InstructionTypes.RotateRow;
                    r = new Regex("([0-9]*) by");
                    first = int.Parse(r.Match(s).Groups[1].Value);
                    r = new Regex("by ([0-9]*)");
                    second = int.Parse(r.Match(s).Groups[1].Value);
                    break;
                case "rotate column x=":
                    type = InstructionTypes.RotateColumn;
                    r = new Regex("([0-9]*) by");
                    first = int.Parse(r.Match(s).Groups[1].Value);
                    r = new Regex("by ([0-9]*)");
                    second = int.Parse(r.Match(s).Groups[1].Value);
                    break;
                default: throw new NotSupportedException();
            }
            return new Instruction(type, first, second);
        }
        private Instruction(InstructionTypes type, int first, int second)
        {
            InstructionType = type;
            First = first;
            Second = second;
        }
    }
    public class Keypad
    {
        private readonly bool[,] _keypad;
        public Keypad(int rows, int columns)
        {
            _keypad = new bool[rows, columns];
        }
        public void Execute(Instruction inst)
        {
            switch (inst.InstructionType)
            {
                case Instruction.InstructionTypes.Rect:
                    for (var i = 0; i <= inst.First - 1; i++)
                    {
                        for (var j = 0; j <= inst.Second - 1; j++)
                        {
                            _keypad[j, i] = true;
                        }
                    }
                    break;
                case Instruction.InstructionTypes.RotateRow:
                    var temparr = new bool[_keypad.GetUpperBound(1) + 1 + inst.Second];
                    for (var i = 0; i <= _keypad.GetUpperBound(1); i++)
                    {
                        temparr[i + inst.Second] = _keypad[inst.First, i];
                    }
                    for (var i = 0; i <= inst.Second - 1; i++)
                    {
                        temparr[i] = temparr[i + _keypad.GetUpperBound(1) + 1];
                    }
                    for (var i = 0; i <= _keypad.GetUpperBound(1); i++)
                    {
                        _keypad[inst.First, i] = temparr[i];
                    }
                    break;
                case Instruction.InstructionTypes.RotateColumn:
                    var temparr2 = new bool[_keypad.GetUpperBound(0) + 1 + inst.Second];
                    for (var i = 0; i <= _keypad.GetUpperBound(0); i++)
                    {
                        temparr2[i + inst.Second] = _keypad[i, inst.First];
                    }
                    for (var i = 0; i <= inst.Second - 1; i++)
                    {
                        temparr2[i] = temparr2[i + _keypad.GetUpperBound(0) + 1];
                    }
                    for (var i = 0; i <= _keypad.GetUpperBound(0); i++)
                    {
                        _keypad[i, inst.First] = temparr2[i];
                    }
                    break;
                default:
                    throw new NotSupportedException();
            }
        }
        public int LightsLit
        {
            get
            {
                var c = 0;
                for (var i = 0; i <= _keypad.GetUpperBound(0); i++)
                {
                    for (var j = 0; j <= _keypad.GetUpperBound(1); j++)
                    {
                        if (_keypad[i, j]) c++;
                    }
                }
                return c;
            }
        }
        public string Print()
        {
            var s = new StringBuilder();
            for (var i = 0; i <= _keypad.GetUpperBound(0); i++)
            {
                for (var j = 0; j <= _keypad.GetUpperBound(1); j++)
                {
                    s.Append(_keypad[i, j] ? "X" : ".");
                }
                s.AppendLine();
            }
            return s.ToString();
        }
    }

}
