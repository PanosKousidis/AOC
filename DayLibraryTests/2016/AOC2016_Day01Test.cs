using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day01Test:DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("R2, L3"), "5");
            Assert.AreEqual(TestPart1("R2, R2, R2"), "2");
            Assert.AreEqual(TestPart1("R5, L5, R5, R3"), "12");
            Assert.AreEqual(TestPart1(null), "262");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("R8, R4, R4, R8"), "4");
            Assert.AreEqual(TestPart2(null), "131");
        }

    }
}