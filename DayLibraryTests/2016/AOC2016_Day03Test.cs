using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day03Test:AoC2016Day03
    {
        [Test]
        public void TestPart1()
        {
           Assert.AreEqual(Part1Result("5 10 25"), 0);
           Assert.AreEqual(Part1Result(Resources.AoC2016_Day03_Input), 917);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result(Resources.AoC2016_Day03_Input), 1649);
            Assert.AreEqual(Part2Result("101 301 501\r\n102 302 502\r\n103 303 503\r\n201 401 601\r\n202 402 602\r\n203 403 603"), 6);
        }

    }
}