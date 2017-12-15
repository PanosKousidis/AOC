using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day15Test : DayTest
    {
        private const string Input = @"Generator A starts with 65
Generator B starts with 8921";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("1", TestPart1(Input,5));
            Assert.AreEqual("588", TestPart1(Input, 40000000));
            Assert.AreEqual("569", TestPart1(null, 40000000));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("1", TestPart2(Input, 1200));
            Assert.AreEqual("309", TestPart2(Input, 5000000));
            Assert.AreEqual("298", TestPart2(null,5000000));
        }
    }
}