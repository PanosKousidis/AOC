namespace DayLibrary
{
    public abstract class DayBase
    {
        public virtual string Part1(string input)
        {
            return Part1(input, null);
        }
        public virtual string Part2(string input)
        {
            return Part2(input, null);
        }
        public abstract string Part1(string input, object args);

        public abstract string Part2(string input, object args);

    }

}