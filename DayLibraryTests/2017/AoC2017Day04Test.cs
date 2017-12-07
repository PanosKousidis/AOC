using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day04Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("1", TestPart1("aa bb cc dd ee"));
            Assert.AreEqual("0", TestPart1("aa bb cc dd aa"));
            Assert.AreEqual("1", TestPart1("aa bb cc dd aaa"));
            Assert.AreEqual("2", TestPart1("aa bb cc dd ee\r\naa bb cc dd aa\r\naa bb cc dd aaa"));
            Assert.AreEqual("386", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("1", TestPart2("abcde fghij"));
            Assert.AreEqual("0", TestPart2("abcde xyz ecdab"));
            Assert.AreEqual("1", TestPart2("a ab abc abd abf abj"));
            Assert.AreEqual("1", TestPart2("iiii oiii ooii oooi oooo"));
            Assert.AreEqual("0", TestPart2("oiii ioii iioi iiio"));
            Assert.AreEqual("3", TestPart2("abcde fghij\r\nabcde xyz ecdab\r\na ab abc abd abf abj\r\niiii oiii ooii oooi oooo\r\noiii ioii iioi iiio"));
            Assert.AreEqual("208", TestPart2(null));
        }
    }
}