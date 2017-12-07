using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day02Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("18", TestPart1("5\t1\t9\t5\r\n7\t5\t3\r\n2\t4\t6\t8"));
            Assert.AreEqual("21845", TestPart1(null));
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("9", TestPart2("5\t9\t2\t8\r\n9\t4\t7\t3\r\n3\t8\t6\t5"));
            Assert.AreEqual("191", TestPart2(null));
        }
    }
}