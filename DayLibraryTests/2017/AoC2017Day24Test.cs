using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day24Test : DayTest
    {
        private const string Input = @"0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("31", TestPart1(Input));
            //Assert.AreEqual(null, TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(null, TestPart2(Input));
            //Assert.AreEqual(null, TestPart2(null));
        }
    }
}