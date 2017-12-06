using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day06Test : AoC2017Day06
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result("0\t2\t7\t0"), 5);
            Assert.AreEqual(Part1Result(Resources.AoC2017_Day06_Input), 14029);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("0\t2\t7\t0"), 4);
            Assert.AreEqual(Part2Result(Resources.AoC2017_Day06_Input), 2765);
        }
    }
}