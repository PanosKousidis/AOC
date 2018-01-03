using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day05Test: DayTest
    {
        private const string Input = @"abc";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("18F47A30", TestPart1(Input));
            Assert.AreEqual("1A3099AA", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("05ACE8E3", TestPart2(Input));
            Assert.AreEqual("694190CD", TestPart2(null));
        }

    }
}