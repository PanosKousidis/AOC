using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day04Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("aa bb cc dd ee"),"1");
            Assert.AreEqual(TestPart1("aa bb cc dd aa"), "0");
            Assert.AreEqual(TestPart1("aa bb cc dd aaa"), "1");
            Assert.AreEqual(TestPart1("aa bb cc dd ee\r\naa bb cc dd aa\r\naa bb cc dd aaa"), "2");
            Assert.AreEqual(TestPart1(null), "386");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("abcde fghij"), "1");
            Assert.AreEqual(TestPart2("abcde xyz ecdab"), "0");
            Assert.AreEqual(TestPart2("a ab abc abd abf abj"), "1");
            Assert.AreEqual(TestPart2("iiii oiii ooii oooi oooo"), "1");
            Assert.AreEqual(TestPart2("oiii ioii iioi iiio"), "0");
            Assert.AreEqual(TestPart2("abcde fghij\r\nabcde xyz ecdab\r\na ab abc abd abf abj\r\niiii oiii ooii oooi oooo\r\noiii ioii iioi iiio"), "3");
            Assert.AreEqual(TestPart2(null), "208");
        }
    }
}