using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day05Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("5", TestPart1("0\r\n3\r\n0\r\n1\r\n-3\r\n"));
            Assert.AreEqual("354121", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("10", TestPart2("0\r\n3\r\n0\r\n1\r\n-3\r\n"));
            Assert.AreEqual("27283023", TestPart2(null));
        }
    }
}