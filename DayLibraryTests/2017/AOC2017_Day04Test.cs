using DayLibrary;
using DayLibrary.Properties;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day04Test : AoC2017Day04
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(Part1Result("aa bb cc dd ee"),1);
            Assert.AreEqual(Part1Result("aa bb cc dd aa"), 0);
            Assert.AreEqual(Part1Result("aa bb cc dd aaa"), 1);
            Assert.AreEqual(Part1Result("aa bb cc dd ee\r\naa bb cc dd aa\r\naa bb cc dd aaa"), 2);
            Assert.AreEqual(Part1Result(Resources.AoC2017_Day04_Input), 386);
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(Part2Result("abcde fghij"), 1);
            Assert.AreEqual(Part2Result("abcde xyz ecdab"), 0);
            Assert.AreEqual(Part2Result("a ab abc abd abf abj"), 1);
            Assert.AreEqual(Part2Result("iiii oiii ooii oooi oooo"), 1);
            Assert.AreEqual(Part2Result("oiii ioii iioi iiio"), 0);
            Assert.AreEqual(Part2Result("abcde fghij\r\nabcde xyz ecdab\r\na ab abc abd abf abj\r\niiii oiii ooii oooi oooo\r\noiii ioii iioi iiio"), 3);
            Assert.AreEqual(Part2Result(Resources.AoC2017_Day04_Input), 208);
        }
    }
}