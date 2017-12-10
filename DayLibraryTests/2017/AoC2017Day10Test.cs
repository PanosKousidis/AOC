using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day10Test : DayTest
    {

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("12", TestPart1("3,4,1,5","5"));
            Assert.AreEqual("826", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("a2582a3a0e66e6e86e3812dcb672a272", TestPart2(""));
            Assert.AreEqual("33efeb34ea91902bb2f59c9920caa6cd", TestPart2("AoC 2017"));
            Assert.AreEqual("3efbe78a8d82f29979031a4aa0b16a9d", TestPart2("1,2,3"));
            Assert.AreEqual("63960835bcdc130f0b66d7ff4f6a5a8e", TestPart2("1,2,4"));
            Assert.AreEqual("d067d3f14d07e09c2e7308c3926605c4", TestPart2(null));
        }
    }
}