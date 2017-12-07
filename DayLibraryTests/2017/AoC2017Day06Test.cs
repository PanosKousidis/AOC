using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day06Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("5", TestPart1("0\t2\t7\t0"));
            Assert.AreEqual("14029", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("4", TestPart2("0\t2\t7\t0"));
            Assert.AreEqual("2765", TestPart2(null));
        }
    }
}