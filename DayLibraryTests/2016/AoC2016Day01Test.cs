using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day01Test:DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("5", TestPart1("R2, L3"));
            Assert.AreEqual("2", TestPart1("R2, R2, R2"));
            Assert.AreEqual("12", TestPart1("R5, L5, R5, R3"));
            Assert.AreEqual("262", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("4", TestPart2("R8, R4, R4, R8"));
            Assert.AreEqual("131", TestPart2(null));
        }

    }
}