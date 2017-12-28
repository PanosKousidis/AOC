using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Common.Extensions;

namespace DayLibrary
{
    public class AoC2016Day10 : DayBase
    {
        private Bot _comparingBot = null;
        private bool _comparingBotFound = false;
        private int _chip1;
        private int _chip2;

        public override string Part1(string input)
        {
            return Part1(input, new object[] { 61, 17 });
        }

        public override string Part2(string input)
        {
            return Part2(input, new[] { 0, 1, 2 });
        }
        public override string Part1(string input, object args)
        {
            var pool = new ReceiverPool();
            var arr = args as int[];
            _chip1 = arr[0];
            _chip2 = arr[1];

            Instructions.OnBotComparing += Instructions_OnBotComparing;
            foreach (var line in input.Lines())
            {
                Instructions.ApplyInstruction(pool, line);
                if (_comparingBotFound) break;
            }

            return _comparingBot.Id.ToString();
        }

        public override string Part2(string input, object args)
        {
            var pool = new ReceiverPool();
            foreach (var line in input.Lines())
            {
                Instructions.ApplyInstruction(pool, line);
            }

            var arr = args as int[];
            var res = 1;
            foreach(var outp in arr)
            {
                res *= pool.Outputs[outp].Chips[0];
            }
            return res.ToString();


        }

        private void Instructions_OnBotComparing(Bot bot, List<int> chips)
        {
            if (chips.Any(x=>x==_chip1) && chips.Any(x=>x==_chip2))
            {
                _comparingBot = bot;
                _comparingBotFound = true;
            }
        }
    }


    public class ReceiverPool
    {
        public Dictionary<int, Bot> Bots { get; }

        public Dictionary<int, Output> Outputs { get; }
        public ReceiverPool()
        {
            Bots = new Dictionary<int, Bot>();
            Outputs = new Dictionary<int, Output>();
        }

        public Bot GetBot(int id)
        {
            if (Bots.ContainsKey(id)) return Bots[id];
            var r = new Bot(id);
            Bots.Add(id, r);
            return r;
        }
        public Output GetOutput(int id)
        {
            if (Outputs.ContainsKey(id)) return Outputs[id];
            var r = new Output(id);
            Outputs.Add(id, r);
            return r;
        }

    }
    public abstract class Receiver
    {

        protected Receiver(int id)
        {
            Id = id;
        }
        public List<int> Chips { get; set; } = new List<int>();
        public int Id { get; set; }

        public virtual void Receive(int x)
        {
            Chips.Add(x);
        }

        public void Remove()
        {
            Chips.Clear();
        }
    }
    public class Output : Receiver
    {
        public Output(int id) : base(id) { }
    }
    public class Bot : Receiver
    {
        private Receiver LowReceiver;
        private Receiver HighReceiver;
        public Bot(int id) : base(id) { }
        private bool HasInstructions => LowReceiver != null && HighReceiver != null;
        public void SetInstructions(Receiver low, Receiver high)
        {
            LowReceiver = low;
            HighReceiver = high;
            if (HasInstructions && Chips.Count == 2) Deliver();
        }

        public override void Receive(int x)
        {
            base.Receive(x);
            if (Chips.Count != 2 || !HasInstructions) return;
            Deliver();
            Remove();
        }
        public delegate void ComparingBotCallback(Bot sender, List<int> chips);
        public event ComparingBotCallback OnComparingBot;

        public void Deliver()
        {
            OnComparingBot(this, Chips);
            LowReceiver.Receive(Chips.Min(x => x));
            HighReceiver.Receive(Chips.Max(x => x));
        }

    }
    public static class Instructions
    {
        public static void ApplyInstruction(ReceiverPool pool, string s)
        {
            if (s.StartsWith("bot"))
            {
                var botno = int.Parse(s.Substring(4, s.IndexOf("gives") - 4));
                var low = s.Substring(s.IndexOf("low to") + 6, s.IndexOf("and") - s.IndexOf("low to") - 6).Trim();
                var lowtype = low.Split(' ')[0];
                var lowid = int.Parse(low.Split(' ')[1].Trim());
                var high = s.Substring(s.IndexOf("high to") + 8).Trim();
                var hightype = high.Split(' ')[0];
                var highid = int.Parse(high.Split(' ')[1].Trim());

                var bot = pool.GetBot(botno);
                bot.OnComparingBot += Bot_OnComparingBot;
                bot.SetInstructions(lowtype == "bot" ? (Receiver)pool.GetBot(lowid) : pool.GetOutput(lowid),
                    hightype == "bot" ? (Receiver)pool.GetBot(highid) : pool.GetOutput(highid));
            }
            else
            {
                var chipno = int.Parse(s.Substring(6, s.IndexOf("goes") - 6).Trim());
                var botno = int.Parse(s.Substring(s.IndexOf("bot") + 4));
                pool.GetBot(botno).Receive(chipno);
            }
        }

        private static void Bot_OnComparingBot(Bot sender, List<int> chips)
        {
            if (!(OnBotComparing is null))
                OnBotComparing(sender, chips);
        }
        public delegate void OnBotComparingCallback(Bot bot, List<int> chips);
        public static event OnBotComparingCallback OnBotComparing;
    }
}
