using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day01Test : DayTest
    {
       
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual("3", TestPart1("1122"));
            Assert.AreEqual("4", TestPart1("1111"));
            Assert.AreEqual("0", TestPart1("1234"));
            Assert.AreEqual("9", TestPart1("91212129"));
            Assert.AreEqual("1158", TestPart1(null));
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual("6", TestPart2("1212"));
            Assert.AreEqual("0", TestPart2("1221"));
            Assert.AreEqual("4", TestPart2("123425"));
            Assert.AreEqual("12", TestPart2("123123"));
            Assert.AreEqual("4", TestPart2("12131415"));
            Assert.AreEqual("1132", TestPart2(null));
        }
    }
}