using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AOC2017_Day03Test : AOC2017_Day03
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result(1),0);
            Assert.AreEqual(Part1Result(12), 3);
            Assert.AreEqual(Part1Result(23), 2);
            Assert.AreEqual(Part1Result(1024), 31);

            Assert.AreEqual(Part1Result(int.Parse(Resources.AOC2017_Day03_Input)), 326);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result(int.Parse(Resources.AOC2017_Day03_Input)), 363010);
        }
    }
}