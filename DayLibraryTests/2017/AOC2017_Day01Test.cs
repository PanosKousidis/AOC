using DayLibrary;
using NUnit.Framework;

namespace DayLibraryTests
{
        [TestFixture]
        public class AOC2017_Day01Test : AOC2017_Day01
        {
            [Test]
            public void TestPart1()
            {
                Assert.AreEqual(CyclicSequence("1122", 1), 3);
                Assert.AreEqual(CyclicSequence("1111", 1), 4);
                Assert.AreEqual(CyclicSequence("1234", 1), 0);
                Assert.AreEqual(CyclicSequence("91212129", 1), 9);
            }

            [Test]
            public void TestPart2()
            {
                Assert.AreEqual(CyclicSequence("1212", 4/2), 6);
                Assert.AreEqual(CyclicSequence("1221", 4/2), 0);
                Assert.AreEqual(CyclicSequence("123425", 6/2), 4);
                Assert.AreEqual(CyclicSequence("123123", 6/2), 12);
                Assert.AreEqual(CyclicSequence("12131415", 8/2), 4);
            }
    }
}