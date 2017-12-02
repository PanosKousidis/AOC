namespace DayLibrary
{
    public abstract class DayBase
    {
        protected abstract string InputPart1 { get; }
        protected abstract string InputPart2 { get; }

        public void RunPart1()
        {
            Part1(InputPart1);
        }

        public void RunPart2()
        {
            Part2(InputPart2);
        }

        protected abstract void Part1(string input);
        protected abstract void Part2(string input);

    }
}