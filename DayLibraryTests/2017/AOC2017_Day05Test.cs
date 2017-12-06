using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day05Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("0\r\n3\r\n0\r\n1\r\n-3\r\n"), "5");
            Assert.AreEqual(TestPart1(null), "354121");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("0\r\n3\r\n0\r\n1\r\n-3\r\n"), "10");
            Assert.AreEqual(TestPart2(null), "27283023");
        }
    }
}