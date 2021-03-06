using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day17Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("638", TestPart1("3", 2017));
            Assert.AreEqual("419", TestPart1(null, 2017));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("46038988", TestPart2(null, 50000000));
        }
    }
}