using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day06Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("0\t2\t7\t0"), "5");
            Assert.AreEqual(TestPart1(null), "14029");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("0\t2\t7\t0"), "4");
            Assert.AreEqual(TestPart2(null), "2765");
        }
    }
}