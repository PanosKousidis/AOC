using Common.Extensions;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

namespace DayLibrary
{
    public class AoC2017Day25 : DayBase
    {
        public override string Part1(string input, object args)
        {
            var t = new TuringMachine(input);
            t.RunCheckSum();
            return t.CheckSum.ToString();
        }

        public override string Part2(string input, object args)
        {
            return null;
        }
    }
    public class Actions
    {
        public bool Write { get; set; }
        public bool MoveRight { get; set; }
        public string NewState { get; set; }
    }
    public class TuringMachine
    {
        public string CurrentState { get; set; }
        private long _checksumNo;
        public int Cursor { get; set; }
        private MovingIn2D M { get; set; } = new MovingIn2D() { Map = new Dictionary<System.Drawing.Point, object>() };
        public Dictionary<string, Dictionary<bool, Actions>> Rules { get; set; }
        public int CheckSum => M.Map.Count(x => (string)x.Value == "1");
        public TuringMachine(string input)
        {
            var commands = input.Split(new[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            (CurrentState, _checksumNo) = GetFirstPart(commands[0]);
            Rules = ParseRules(commands);

        }
        public (string, long) GetFirstPart(string command)
        {
            var r = new Regex("state (\\w)[\\D]+(\\d+)");
            var match = r.Match(command);
            return (match.Groups[1].Value, long.Parse(match.Groups[2].Value));
        }

        public Dictionary<string, Dictionary<bool, Actions>> ParseRules(string[] commands)
        {
            var stateRules = new Dictionary<string, Dictionary<bool, Actions>>();
            for (var i = 1; i < commands.Length; i++)
            {
                var commandLines = commands[i].Lines();
                var state = Regex.Match(commandLines[0], "state (\\w)").Groups[1].Value;
                var bitRules = new Dictionary<bool, Actions>();
                for (var r = 0; r < 2; r++)
                {
                    var bitvalue = Regex.Match(commandLines[1 + r * 4], "(\\d)").Groups[1].Value;
                    var write = Regex.Match(commandLines[2 + r * 4], "(\\d)").Groups[1].Value;
                    var move = Regex.Match(commandLines[3 + r * 4], "(left|right)").Groups[1].Value;
                    var cont = Regex.Match(commandLines[4 + r * 4], "state (\\w)").Groups[1].Value;
                    bitRules.Add(bitvalue == "1", new Actions() { Write = write == "1", MoveRight = move == "right", NewState = cont });
                }
                stateRules.Add(state, bitRules);
            }
            return stateRules;
        }
        public void RunCheckSum()
        {
            Run(_checksumNo);
        }
        public void Run(long times)
        {
            for (var i = 0; i < times; i++)
            {
                var stateRule = Rules[CurrentState];
                var bitRule = stateRule[M.MapValue == "1"];
                M.Write(bitRule.Write?"1":"0");
                M.LocationX = M.LocationX + (bitRule.MoveRight ? 1 : -1);
                CurrentState = bitRule.NewState;
            }
        }
    }
}