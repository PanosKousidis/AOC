using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day04Test: DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("aaaaa-bbb-z-y-x-123[abxyz]"), "123");
            Assert.AreEqual(TestPart1("a-b-c-d-e-f-g-h-987[abcde]"), "987");
            Assert.AreEqual(TestPart1("not-a-real-room-404[oarel]"), "404");
            Assert.AreEqual(TestPart1("totally-real-room-200[decoy]"), "0");
            Assert.AreEqual(TestPart1(null), "137896");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2(null), "501");
        }

    }
}