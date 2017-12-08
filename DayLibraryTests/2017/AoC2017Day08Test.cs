using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day08Test : DayTest
    {
        private const string Input = @"b inc 5 if a > 1
a inc 1 if b < 5
c dec -10 if a >= 1
c inc -20 if c == 10";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("1", TestPart1(Input));
            Assert.AreEqual("4832", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("10", TestPart2(Input));
            Assert.AreEqual("5443", TestPart2(null));
        }
    }
}