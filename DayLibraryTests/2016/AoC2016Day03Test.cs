using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2016Day03Test : DayTest

    {
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("0", TestPart1("5 10 25"));
            Assert.AreEqual("917", TestPart1(null));
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("6", TestPart2("101 301 501\r\n102 302 502\r\n103 303 503\r\n201 401 601\r\n202 402 602\r\n203 403 603"));
            Assert.AreEqual("1649", TestPart2(null));
        }
    }
}