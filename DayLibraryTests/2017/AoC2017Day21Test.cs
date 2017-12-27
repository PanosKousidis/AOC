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
            Assert.AreEqual(null, TestPart1(null, 5));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(null, TestPart2(Input));
            //Assert.AreEqual(null, TestPart2(null));
        }
    }
}