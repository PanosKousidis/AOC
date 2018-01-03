using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day22Test : DayTest
    {
        private const string Input = @"..#
#..
...";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("5", TestPart1(Input, 7));
            Assert.AreEqual("41", TestPart1(Input, 70));
            Assert.AreEqual("5587", TestPart1(Input, 10000));
            Assert.AreEqual("5411", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("26", TestPart2(Input,100));
            Assert.AreEqual("2511416", TestPart2(null));
        }
    }
}