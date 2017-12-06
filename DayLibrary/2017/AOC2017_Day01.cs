namespace DayLibrary
{
    public class AoC2017Day01:DayBase
    {

        public override string Part1(string input)
        {
            return CyclicSequence(input, 1).ToString();
        }

        public override string Part2(string input)
        {
            return CyclicSequence(input, input.Length / 2).ToString();
        }

       protected static int CyclicSequence(string input, int feed)
        {
            var sum = 0;
            for (var i = 0; i < input.Length; i++)
            {
                var firstchar = input[i];
                var j = (i + feed) % input.Length;
                var secondchar = input[j];
                if (firstchar == secondchar)
                {
                    sum += int.Parse(firstchar.ToString());
                }
            }
            return sum;
        }
    }

    
}
