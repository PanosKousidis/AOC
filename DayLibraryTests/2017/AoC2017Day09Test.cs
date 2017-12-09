using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day09Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("1", TestPart1("{}"));
            Assert.AreEqual("6", TestPart1("{{{}}}"));
            Assert.AreEqual("5", TestPart1("{{},{}}"));
            Assert.AreEqual("16", TestPart1("{{{},{},{{}}}}"));
            Assert.AreEqual("1", TestPart1("{<a>,<a>,<a>,<a>}"));
            Assert.AreEqual("9", TestPart1("{{<ab>},{<ab>},{<ab>},{<ab>}}"));
            Assert.AreEqual("9", TestPart1("{{<!!>},{<!!>},{<!!>},{<!!>}}"));
            Assert.AreEqual("3", TestPart1("{{<a!>},{<a!>},{<a!>},{<ab>}}"));
            Assert.AreEqual("7616", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("0", TestPart2("<>"));
            Assert.AreEqual("17", TestPart2("<random characters>"));
            Assert.AreEqual("3", TestPart2("<<<<>"));
            Assert.AreEqual("2", TestPart2("<{!>}>"));
            Assert.AreEqual("0", TestPart2("<!!>"));
            Assert.AreEqual("0", TestPart2("<!!!>>"));
            Assert.AreEqual("10", TestPart2("<{o\"i!a,<{i<a>"));
            Assert.AreEqual("3838", TestPart2(null));
        }
    }
}