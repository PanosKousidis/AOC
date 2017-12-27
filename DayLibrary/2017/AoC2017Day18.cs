using System.Collections.Generic;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2017Day18 : DayBase
    {

        public override string Part1(string input)
        {
            var rq = new List<long>();
            var sq = new List<long>();
            var p0 = new AssemblyProgram(0, ref rq, ref sq, input);
            p0.RunProgram(true);
            return p0.LastFrequencySent.ToString();
        }

        public override string Part2(string input)
        {
            var q0 = new List<long>();
            var q1 = new List<long>();
            var p0 = new AssemblyProgram(0, ref q0, ref q1, input) ;
            var p1 = new AssemblyProgram(1, ref q1, ref q0, input) ;

            do
            {
                p0.RunProgram(false);
                p1.RunProgram(false);
            } while (p0.SentMsgToQ || p1.SentMsgToQ);

            return p1.MessagesSent.ToString();
        }

    }

    public class AssemblyProgram
    {
        private int Id { get; set; }
        private List<long> ReceiveQ { get; set; }
        private List<long> SendQ { get; set; }
        public bool IsRunning { get; set; }
        public long LastFrequencySent { get; set; }

        private readonly Dictionary<string, long> _registers;
        private long _nextLineToProcess = 0;
        private bool IsOnHold { get; set; } = false;
        private readonly string[] _commands ;
        public int MessagesSent { get; set; }
        public bool SentMsgToQ { get; set; }

        public AssemblyProgram(int id, ref List<long> receiveQ, ref List<long> sendQ, string input)
        {
            Id = id;
            ReceiveQ = receiveQ;
            SendQ = sendQ;
            _registers = new Dictionary<string, long> { { "p", id } };
            _commands = input.Lines();
            IsRunning = true;
        }

        public void RunProgram(bool stopWhenRecover)
        {
            SentMsgToQ = false;
            IsOnHold = false;
            for (long lineNo = _nextLineToProcess; lineNo < _commands.Length; lineNo++)
            {
                var m = Regex.Match(_commands[lineNo], "(\\w+)\\s(\\w)\\s*(-*\\w*)");
                var cmd = m.Groups[1].Value;
                var arg1 = m.Groups[2].Value;
                long arg2 = m.Groups.Count > 2 ? GetValue(m.Groups[3].Value) : 0;
                if (cmd !="snd" && !_registers.ContainsKey(m.Groups[2].Value)) _registers.Add(arg1, 0);

                switch (cmd)
                {
                    case "snd":
                        SendQ.Add(GetValue(arg1));
                        LastFrequencySent = GetValue(arg1);
                        SentMsgToQ = true;
                        MessagesSent++;
                        break;
                    case "set":
                        _registers[arg1] = arg2;
                        break;
                    case "add":
                        _registers[arg1] += arg2;
                        break;
                    case "mul":
                        _registers[arg1] *= arg2;
                        break;
                    case "mod":
                        _registers[arg1] %= arg2;
                        break;
                    case "rcv":
                        if (GetValue(arg1) != 0 && stopWhenRecover)
                            return;

                        if (ReceiveQ.Count==0)
                        {
                            _nextLineToProcess = lineNo;
                            IsOnHold = true;
                            return;
                        }
                        else
                        {
                            _registers[arg1] = ReceiveQ[0];
                            ReceiveQ.RemoveAt(0);
                        }
                        break;
                    case "jgz":
                        if (GetValue(arg1) > 0) lineNo += arg2 - 1;
                        break;
                }
            }
            IsRunning = false;
        }
        private long GetValue(string c)
        {
            if (long.TryParse(c, out _))
                return long.Parse(c);
            if (_registers.ContainsKey(c))
                return _registers[c];
            return 0;
        }

    }
}