using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day02Test:DayTest
    {
        [Test]
        public void TestPart1()
        {
           Assert.AreEqual("1985", TestPart1("ULL\r\n" +
                        "RRDDD\r\n" + 
                        "LURDL\r\n" + 
                        "UUUUD"));

            Assert.AreEqual("47978", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("5DB3", TestPart2("ULL\r\n" +
                                        "RRDDD\r\n" +
                                        "LURDL\r\n" +
                                        "UUUUD"));
            Assert.AreEqual("659AD", TestPart2(null));
        }

    }
}