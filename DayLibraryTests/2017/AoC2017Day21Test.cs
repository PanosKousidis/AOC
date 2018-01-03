using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day21Test : DayTest
    {
        private const string Input = @"../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("12", TestPart1(Input, 2));
            Assert.AreEqual("184", TestPart1(null, 5));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("2810258", TestPart2(null, 18));
        }
    }
}