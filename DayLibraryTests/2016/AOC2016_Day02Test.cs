using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AOC2016_Day02Test:AOC2016_Day02
    {
        [Test]
        public void TestPart1()
        {
           Assert.AreEqual(Part1Result("ULL\r\n" +
                        "RRDDD\r\n" + 
                        "LURDL\r\n" + 
                        "UUUUD"),"1985");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("ULL\r\n" +
                                        "RRDDD\r\n" +
                                        "LURDL\r\n" +
                                        "UUUUD"), "5DB3");
        }

    }
}