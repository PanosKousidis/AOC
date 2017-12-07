using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day04Test: DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("123", TestPart1("aaaaa-bbb-z-y-x-123[abxyz]"));
            Assert.AreEqual("987", TestPart1("a-b-c-d-e-f-g-h-987[abcde]"));
            Assert.AreEqual("404", TestPart1("not-a-real-room-404[oarel]"));
            Assert.AreEqual("0", TestPart1("totally-real-room-200[decoy]"));
            Assert.AreEqual("137896", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("501", TestPart2(null));
        }

    }
}