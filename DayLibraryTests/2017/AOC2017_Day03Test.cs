using DayLibrary;
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
        }
        [Test]
        public void TestPart2()
        {
            //Assert.AreEqual(Part2Result(1000), 1024);
            //Assert.AreEqual(Part2Result(2), 1);
            //Assert.AreEqual(Part2Result(3), 2);
            //Assert.AreEqual(Part2Result(4), 4);
            //Assert.AreEqual(Part2Result(5), 5);
        }
    }
}