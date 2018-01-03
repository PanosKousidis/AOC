using Common.Extensions;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace DayLibrary
{
    public class AoC2017Day23 : DayBase
    {

        public override string Part1(string input)
        {
            List<long> reQ = null;
            List<long> seQ = null;
            var m = new AssemblyProgram(1, ref reQ, ref seQ, input);
            m.RunProgram(false);
            return m.mulInvoked.ToString();

        }
        public override string Part2(string input)
        {
            List<long> reQ = null;
            List<long> seQ = null;
            var m = new AssemblyProgram(1, ref reQ, ref seQ, input);
            m._registers.Add("a", 1);
            m.RunProgram(false);
            return m._registers["h"].ToString(); ;
        }

        public override string Part1(string input, object args)
        {
            return null;
        }

        public override string Part2(string input, object args)
        {
            return null;
        }

        public class AssemblyProgram
        {
            private int Id { get; set; }
            private List<long> ReceiveQ { get; set; }
            private List<long> SendQ { get; set; }
            public bool IsRunning { get; set; }
            public long LastFrequencySent { get; set; }

            public readonly Dictionary<string, long> _registers;
            private long _nextLineToProcess = 0;
            private bool IsOnHold { get; set; } = false;
            private readonly string[] _commands;
            public int MessagesSent { get; set; }
            public bool SentMsgToQ { get; set; }
            public int mulInvoked { get; set; }
            public AssemblyProgram(int id, ref List<long> receiveQ, ref List<long> sendQ, string input)
            {
                Id = id;
                ReceiveQ = receiveQ;
                SendQ = sendQ;
                _registers = new Dictionary<string, long> { { "p", id } };
                _commands = input.Lines();
                IsRunning = true;
            }

            bool isPrime(int number)
            {

                if (number == 1) return false;
                if (number == 2) return true;

                for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
                {
                    if (number % i == 0) return false;
                }

                return true;

            }
            public void RunProgram(bool stopWhenRecover)
            {
                SentMsgToQ = false;
                IsOnHold = false;
                var count = 0;
                for (var i = 106500; i<=123500;i+=17)
                {
                    if (!isPrime(i))
                        count++;
                    else
                    {

                    }
                }

                for (long lineNo = _nextLineToProcess; lineNo < _commands.Length; lineNo++)
                {
                    
                    var m = Regex.Match(_commands[lineNo], "(\\w+)\\s(\\w)\\s*(-*\\w*)");
                    var cmd = m.Groups[1].Value;
                    var arg1 = m.Groups[2].Value;
                    long arg2 = m.Groups.Count > 2 ? GetValue(m.Groups[3].Value) : 0;
                    if (cmd != "snd" && !_registers.ContainsKey(m.Groups[2].Value)) _registers.Add(arg1, 0);

                    switch (cmd)
                    {
                        case "sub":
                            _registers[arg1] -= arg2;
                            break;
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
                            mulInvoked++;
                            break;
                        case "mod":
                            _registers[arg1] %= arg2;
                            break;
                        case "rcv":
                            if (GetValue(arg1) != 0 && stopWhenRecover)
                                return;

                            if (ReceiveQ.Count == 0)
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
                        case "jnz":
                            if (GetValue(arg1) != 0) lineNo += arg2 - 1;
                            break;
                         default:
                            throw new NotSupportedException();
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
}