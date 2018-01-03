namespace DayLibrary
{
    public class AoC2017Day09 : DayBase
    {
        public override string Part1(string input, object args)
        {
            return Process(input).Item1.ToString();
        }
      
        public override string Part2(string input, object args)
        {
            return Process(input).Item2.ToString();
        }

        private static (int, int) Process(string input)
        {
            var inGarbage = false;
            var escapeNext = false;
            var currentGroupValue = 0;
            var sum = 0;
            var garbage = 0;

            foreach (var c in input)
            {
                if (escapeNext)
                {
                    escapeNext = false; continue;
                }
                if (inGarbage)
                {
                    switch (c)
                    {
                        case '>': inGarbage = false; continue;
                        case '!': escapeNext = true; continue;
                        default: garbage += 1; continue;
                    }
                }
                switch (c)
                {
                    case '{': currentGroupValue += 1; continue;
                    case '}': sum += currentGroupValue; currentGroupValue -= 1; continue;
                    case '<': inGarbage = true; continue;
                    case '!': escapeNext = true; continue;
                    default: continue;
                }
            }
            return (sum, garbage);
        }
    }
}