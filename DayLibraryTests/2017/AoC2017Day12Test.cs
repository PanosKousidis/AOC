using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day12Test : DayTest
    {
        private const string Input = @"0 <-> 2
1 <-> 1
2 <-> 0, 3, 4
3 <-> 2, 4
4 <-> 2, 3, 6
5 <-> 6
6 <-> 4, 5
";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("6", TestPart1(Input));
            Assert.AreEqual("288", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("2", TestPart2(Input));
            Assert.AreEqual("211", TestPart2(null));
        }
    }
}