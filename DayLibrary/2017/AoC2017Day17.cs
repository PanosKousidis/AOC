using System.Collections.Generic;

namespace DayLibrary
{
    public class AoC2017Day17 : DayBase
    {

        public override string Part1(string input, object args)
        {
            var arr = new List<int>() { 0 };
            var reps = (int)args;
            var steps = int.Parse(input);
            var index = 0;
            for (var i = 0; i < reps; i++)

            {
                var position = (index + steps) % arr.Count;
                if (position == arr.Count - 1)
                    arr.Add(i + 1);
                else
                    arr.Insert(position + 1, i + 1);
                index = position + 1;
            }
            return arr[index + 1].ToString();
        }
             
        public override string Part2(string input, object args)
        {
            var arr = new List<int>() { 0 };
            var reps = (int)args;
            var steps = int.Parse(input);
            var index = 0;
            var lastvalue = 0;
            for (var i = 0; i < reps; i++)
            {
                var position = (index + steps) % (i + 1);
                if (position == 0)
                    lastvalue = i + 1;
                index = position + 1;
            }
            return lastvalue.ToString();
        }
    }
}