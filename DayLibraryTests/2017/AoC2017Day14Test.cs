using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day14Test : DayTest
    {
        private const string Input = @"flqrgnkx";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("8108", TestPart1(Input));
            Assert.AreEqual("8230", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("1242", TestPart2(Input));
            Assert.AreEqual("1103", TestPart2(null));
        }
    }
}