using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day03Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("0", TestPart1("1"));
            Assert.AreEqual("3", TestPart1("12"));
            Assert.AreEqual("2", TestPart1("23"));
            Assert.AreEqual("31", TestPart1("1024"));
            Assert.AreEqual("326", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("363010", TestPart2(null));
        }
    }
}