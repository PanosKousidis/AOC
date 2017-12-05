using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day05Test : AoC2017Day05
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result("0\r\n3\r\n0\r\n1\r\n-3\r\n"), 5);
            Assert.AreEqual(Part1Result(Resources.AoC2017_Day05_Input), 354121);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("0\r\n3\r\n0\r\n1\r\n-3\r\n"), 10);
            Assert.AreEqual(Part2Result(Resources.AoC2017_Day05_Input), 27283023);
        }
    }
}