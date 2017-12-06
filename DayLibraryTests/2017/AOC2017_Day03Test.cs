using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day03Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("1"),"0");
            Assert.AreEqual(TestPart1("12"), "3");
            Assert.AreEqual(TestPart1("23"), "2");
            Assert.AreEqual(TestPart1("1024"), "31");
            Assert.AreEqual(TestPart1(null), "326");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2(null), "363010");
        }
    }
}