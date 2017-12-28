using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day07Test: DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("1", TestPart1("abba[mnop]qrst"));
            Assert.AreEqual("0", TestPart1("abcd[bddb]xyyx"));
            Assert.AreEqual("0", TestPart1("aaaa[qwer]tyui"));
            Assert.AreEqual("1", TestPart1("ioxxoj[asdfgh]zxcvbn"));
            Assert.AreEqual("115", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("1", TestPart2("aba[bab]xyz"));
            Assert.AreEqual("0", TestPart2("xyx[xyx]xyx"));
            Assert.AreEqual("1", TestPart2("aaa[kek]eke"));
            Assert.AreEqual("1", TestPart2("zazbz[bzb]cdb"));
            Assert.AreEqual("231", TestPart2(null));
        }

    }
}