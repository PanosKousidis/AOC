using System;
using System.Linq;

namespace DayLibrary
{
    public class AoC2017Day05 : DayBase
    {

        public override string Part1(string input)
        {
            var dic = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            var currentIndex = 0;
            var currentSteps = 0;
            try
            {
                while (true)
                {
                    var tmp = currentIndex;
                    currentIndex += dic[currentIndex];
                    dic[tmp] += 1;
                    currentSteps += 1;
                }
            }
            catch (IndexOutOfRangeException)
            {
                //result found
            }
            return currentSteps.ToString();
        }
      
        public override string Part2(string input)
        {
            var dic = input.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            var currentIndex = 0;
            var currentSteps = 0;
            try
            {
                while (true)
                {
                    var tmp = currentIndex;
                    currentIndex += dic[currentIndex];
                    dic[tmp] += dic[tmp] >= 3 ? -1 : 1;
                    currentSteps += 1;
                }
            }
            catch (IndexOutOfRangeException)
            {
                //result found
            }
            return currentSteps.ToString();
        }
    }

   
}
