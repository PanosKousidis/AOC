using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day13Test : DayTest
    {
        private const string Input = @"0: 3
1: 2
4: 4
6: 4";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("24", TestPart1(Input));
            Assert.AreEqual("2384", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("10", TestPart2(Input));
            Assert.AreEqual("3921270", TestPart2(null));
        }
    }
}