using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day02Test : DayTest
    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("5\t1\t9\t5\r\n7\t5\t3\r\n2\t4\t6\t8"), "18");
            Assert.AreEqual(TestPart1(null), "21845");
        }
        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("5\t9\t2\t8\r\n9\t4\t7\t3\r\n3\t8\t6\t5"), "9");
            Assert.AreEqual(TestPart2(null), "191");
        }
    }
}