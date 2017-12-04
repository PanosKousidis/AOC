using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day02Test:AoC2016Day02
    {
        [Test]
        public void TestPart1()
        {
           Assert.AreEqual(Part1Result("ULL\r\n" +
                        "RRDDD\r\n" + 
                        "LURDL\r\n" + 
                        "UUUUD"),"1985");
            Assert.AreEqual(Part1Result(Resources.AoC2016_Day02_Input),"47978");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("ULL\r\n" +
                                        "RRDDD\r\n" +
                                        "LURDL\r\n" +
                                        "UUUUD"), "5DB3");
            Assert.AreEqual(Part2Result(Resources.AoC2016_Day02_Input), "659AD");

        }

    }
}