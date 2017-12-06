using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day02Test:DayTest
    {
        [Test]
        public void TestPart1()
        {
           Assert.AreEqual(TestPart1("ULL\r\n" +
                        "RRDDD\r\n" + 
                        "LURDL\r\n" + 
                        "UUUUD"),"1985");

            Assert.AreEqual(TestPart1(null), "47978");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("ULL\r\n" +
                                        "RRDDD\r\n" +
                                        "LURDL\r\n" +
                                        "UUUUD"), "5DB3");
            Assert.AreEqual(TestPart2(null), "659AD");
        }

    }
}