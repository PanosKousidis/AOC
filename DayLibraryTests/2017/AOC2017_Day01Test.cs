using System.Threading;
using AoC;
using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
    [TestFixture]
    public class AoC2017Day01Test : DayTest
    {
       
        [Test]
        public void TestPart1()
        {
            Assert.AreEqual(TestPart1("1122"), "3");
            Assert.AreEqual(TestPart1("1111"), "4");
            Assert.AreEqual(TestPart1("1234"), "0");
            Assert.AreEqual(TestPart1("91212129"), "9");
            Assert.AreEqual(TestPart1(null), "1158");
        }

        [Test]
        public void TestPart2()
        {
            Assert.AreEqual(TestPart2("1212"), "6");
            Assert.AreEqual(TestPart2("1221"), "0");
            Assert.AreEqual(TestPart2("123425"), "4");
            Assert.AreEqual(TestPart2("123123"), "12");
            Assert.AreEqual(TestPart2("12131415"), "4");
            Assert.AreEqual(TestPart2(null), "1132");
        }
    }
}