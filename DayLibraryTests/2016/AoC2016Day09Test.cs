using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day09Test: DayTest
    {
        private const string Input = @"";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("6", TestPart1("ADVENT"));
            Assert.AreEqual("7", TestPart1("A(1x5)BC"));
            Assert.AreEqual("9", TestPart1("(3x3)XYZ"));
            Assert.AreEqual("11", TestPart1("A(2x2)BCD(2x2)EFG"));
            Assert.AreEqual("6", TestPart1("(6x1)(1x3)A"));
            Assert.AreEqual("18", TestPart1("X(8x2)(3x3)ABCY"));
            Assert.AreEqual("74532", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("9", TestPart2("(3x3)XYZ"));
            Assert.AreEqual("20", TestPart2("X(8x2)(3x3)ABCY"));
            Assert.AreEqual("241920", TestPart2("(27x12)(20x12)(13x14)(7x10)(1x12)A"));
            Assert.AreEqual("445", TestPart2("(25x3)(3x3)ABC(2x3)XY(5x2)PQRSTX(18x9)(3x2)TWO(5x7)SEVEN"));
            Assert.AreEqual("11558231665", TestPart2(null));
        }

    }
}