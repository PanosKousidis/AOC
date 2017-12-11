using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day11Test : DayTest
    {
        private const string Input = @"";

        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("3", TestPart1("ne,ne,ne"));
            Assert.AreEqual("0", TestPart1("ne,ne,sw,sw"));
            Assert.AreEqual("2", TestPart1("ne,ne,s,s"));
            Assert.AreEqual("3", TestPart1("se,sw,se,sw,sw"));
            Assert.AreEqual("784", TestPart1(null));
            Assert.AreEqual("6", TestPart1("se,ne,se,ne,se,ne"));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("1558", TestPart2(null));
        }
    }
}